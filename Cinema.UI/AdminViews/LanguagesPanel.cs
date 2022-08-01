using BaseServices.Services;
using Cinema.UI.Extensions;
using Cinema.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.AdminViews
{
    public partial class LanguagesPanel : UserControl
    {
        Logger _logger;
        LanguageService _languageService;
        ExceptionHandler _exhandler;
        ControlTranslationService _controlTranslationService;

        (string Abreviacion, string Nombre) CurrentIdiomaCargado = ("", "");
        (string Codigo, string Texto) CurrentTraduccion = ("", "");

        public LanguagesPanel(Logger logger,
            LanguageService languageService,
            ExceptionHandler exhandler,
            ControlTranslationService controlTranslationService)
        {
            InitializeComponent();

            this.Name = "text_lenguages";

            _logger = logger;
            _languageService = languageService;
            _exhandler = exhandler;
            _controlTranslationService = controlTranslationService;

            GridLenguajes.SetupBehaviour(GridLenguajesRowClicked);
            GridTraducciones.SetupBehaviour(GridTraduccionRowClicked, x => x.ReadOnly = false);

            UpdateLanguages();
        }

        private void UpdateLanguages()
        {
            try
            {
                GridLenguajes.Clear();

                var langs = _languageService.GetSupportedLanguages();

                langs.ToList().ForEach(x => GridLenguajes.Add(new { Abreviacion = x.Key, Nombre = x.Value }, false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void UpdateTraducciones()
        {
            if (CurrentIdiomaCargado.Abreviacion == null || CurrentIdiomaCargado.Abreviacion == "")
                return;

            GridTraducciones.Clear();

            var traducciones = _languageService.GetLanguageFromFile(CurrentIdiomaCargado.Abreviacion);

            traducciones.ToList().ForEach(x => GridTraducciones.Add(new { Codigo = x.Key, Traduccion = x.Value }, false));
        }

        private void GridTraduccionRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CurrentTraduccion = GridTraducciones.GetCellValues<(string, string)>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void GridLenguajesRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GridLenguajes.DataSource == null)
                    return;

                CurrentIdiomaCargado = GridLenguajes.GetCellValues<(string, string)>();

                TxtAbreviacion.Text = CurrentIdiomaCargado.Abreviacion;
                TxtNombre.Text = CurrentIdiomaCargado.Nombre;

                UpdateTraducciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void LanguagesPanel_Load(object sender, EventArgs e)
        {

        }

        private void TxtGuardarTodoYActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridTraducciones.DataSource == null)
                    return;

                Dictionary<string, string> lang = new Dictionary<string, string>();


                DataTable dt = GridTraducciones.DataSource as DataTable;

                dt.DefaultView.Sort = "Codigo ASC";

                foreach (DataRow row in dt.Rows)
                {
                    lang[row[0].ToString()] = row[1].ToString();
                }

                _languageService.SaveLanguageInFile(CurrentIdiomaCargado.Abreviacion, lang);
                _languageService.SaveLanguageInMemory(CurrentIdiomaCargado.Abreviacion, lang);

                _languageService.ReloadLanguages();

                _controlTranslationService.TriggerTranslation();

                UpdateLanguages();

                UpdateTraducciones();

                MessageBox.Show("Cambios guardados con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnAgregarLenguaje_Click(object sender, EventArgs e)
        {
            try
            {
                _languageService.AddLanguageSupport(TxtAbreviacion.Text, TxtNombre.Text, new Dictionary<string, string>());
                UpdateLanguages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnEliminarLenguaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentIdiomaCargado.Abreviacion != null && GridLenguajes.SelectedRows.Count > 0)
                    _languageService.RemoveLanguageSupport(CurrentIdiomaCargado.Abreviacion);

                UpdateLanguages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnAgregarTraduccion_Click(object sender, EventArgs e)
        {
            try
            {
                GridTraducciones.Add(new { Codigo = "", Traduccion = "" }, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnEliminarTraduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridTraducciones.DataSource == null || CurrentTraduccion.Codigo == null || CurrentTraduccion.Codigo == "")
                    return;

                DataTable dt = GridTraducciones.DataSource as DataTable;
               
                GridTraducciones.DataSource = null;

                try
                {
                    dt.Rows.Remove(dt.Rows.Find(CurrentTraduccion.Codigo));

                }
                catch (Exception)
                {
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["Codigo"] };
                    dt.Rows.Remove(dt.Rows.Find(CurrentTraduccion.Codigo));
                }
                GridTraducciones.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnGuardarCambiosTraducciones_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }
    }
}
