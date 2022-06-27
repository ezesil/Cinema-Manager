using BaseServices.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
using BaseServices.Services;
using BaseServices.Domain;

namespace Cinema.UI.Services
{
    /// <summary>
    /// Servicio de soporte para multiples lenguajes.
    /// </summary>
    public class ControlTranslationService
    {
        /// <summary>
        /// Delegado para el refresco de traducciones.
        /// </summary>
        public delegate void LanguageRefresh();

        /// <summary>
        /// Instancia del refrescador de lenguaje. Invocar para traducir todos los formularios y controles suscritos.
        /// </summary>
        public static LanguageRefresh refresher;

        private static string currentlanguage = ApplicationSettings.Instance.LastLanguage;
        private List<string> failedcodes = new List<string>();
        private Logger _logger;
        

        public ControlTranslationService(Logger logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Verifica el estado de traduccion del formulario.
        /// </summary>
        /// <param name="controls"></param>
        /// <returns>Retorna dos listados. El primer listado corresponde al listado de codigos utilizados. El segundo listado correponde al listado de controles sin traduccion.</returns>
        public List<string>[] CheckControlsTranslationStatus(IList<Control> controls)
        {
            List<string>[] translatecodes = new List<string>[2] 
            {
                new List<string>(),
                new List<string>()
            };


            foreach (Control item in controls)
            {
                if (item.Tag != null && item.Tag.ToString().Contains('_'))
                {
                    translatecodes[0].Add(item.Tag.ToString());
                }

                else
                {
                    translatecodes[1].Add(item.Name);
                }
            }

            return translatecodes;
        }

        /// <summary>
        /// Permite traducir un codigo al idioma actual.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string TranslateCode(string code)
        {
            return LanguageBLL.GetTranslation(currentlanguage, code);
        }

        /// <summary>
        /// Intenta traducir una colección de controles.
        /// </summary>
        /// <param name="f"></param>
        public void TryTranslateForm(ControlCollection f)
        {

            foreach (Control item in f)
            {
                if (item.Tag != null)
                {
                    if (item.Controls.Count > 0)
                        TryTranslateForm(item.Controls);

                    string traduccion = TranslateCode(item.Tag.ToString());

                    if (traduccion == item.Tag?.ToString())
                        failedcodes.Add(item.Tag?.ToString());

                    if (traduccion.Length > 1)
                        item.Text = traduccion;
                }
            }

            if (failedcodes.Count > 0)
                _logger.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes));
            failedcodes.Clear();

        }

        /// <summary>
        /// Intenta traducir un formulario
        /// </summary>
        /// <param name="form"></param>
        public void TryTranslateForm(Form form)
        {

            string trad = TranslateCode(form.Tag?.ToString());
            if (trad == form.Tag?.ToString())
            {
                failedcodes.Add("" + form.Tag.ToString());
            }
            else if (form.Tag is null)
            {
                form.Text = "NULL";
            }

            else
            {
                form.Text = trad;
            }
            foreach (Control item in form.Controls)
            {
                if (item.Tag != null)
                {
                    if (item.Controls.Count > 0)
                        TryTranslateForm(item.Controls);

                    string traduccion = TranslateCode(item.Tag.ToString());

                    if (traduccion == item.Tag.ToString())
                        failedcodes.Add(item.Tag.ToString());

                    if (traduccion.Length > 1)
                        item.Text = traduccion;
                }
            }

            if (failedcodes.Count > 0)
                _logger.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes));
            failedcodes.Clear();

        }

        /// <summary>
        /// Intenta traducir un formulario
        /// </summary>
        /// <param name="form"></param>
        public void TryTranslateForm(UserControl form)
        {

            string trad = TranslateCode(form.Tag?.ToString());
            if (form.Tag != null && trad == form.Tag?.ToString())
            {
                failedcodes.Add("" + form.Tag?.ToString());
            }
            else if (form.Tag is null)
            {
                form.Text = "NULL";
            }

            else
            {
                form.Text = trad;
            }
            foreach (Control item in form.Controls)
            {
                if (item.Tag != null)
                {
                    if (item.Controls.Count > 0)
                        TryTranslateForm(item.Controls);

                    string traduccion = TranslateCode(item.Tag.ToString());

                    if (traduccion == item.Tag.ToString() && item.Tag.ToString().Length > 3)
                        failedcodes.Add(item.Tag.ToString());

                    if (traduccion.Length > 1)
                        item.Text = traduccion;
                }
            }

            if (failedcodes.Count > 0)
                _logger.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes));

            failedcodes.Clear();

        }

        /// <summary>
        /// Intenta traducir un formulario
        /// </summary>
        /// <param name="form"></param>
        public void TryTranslateForm(FlowLayoutPanel form)
        {

            string trad = TranslateCode(form.Tag?.ToString());
            if (trad == form.Tag?.ToString())
            {
                failedcodes.Add("" + form.Tag?.ToString());
            }
            else if (form.Tag is null)
            {
                form.Text = "NULL";
            }

            else
            {
                form.Text = trad;
            }
            foreach (UserControl item in form.Controls)
            {
                if (item.Tag != null)
                {
                    if (item.Controls.Count > 0)
                        TryTranslateForm(item.Controls);

                    string traduccion = TranslateCode(item.Tag.ToString());

                    if (traduccion == item.Tag.ToString())
                        failedcodes.Add(item.Tag.ToString());

                    if (traduccion.Length > 1)
                        item.Text = traduccion;
                }
            }

            if (failedcodes.Count > 0)
                _logger.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes));
            failedcodes.Clear();

        }


        /// <summary>
        /// Intenta traducir una colección de controles.
        /// </summary>
        /// <param name="f"></param>
        public void TryTranslateForm(IList<Control> f)
        {

            foreach (Control item in f)
            {
                if (item.Tag != null)
                {
                    if (item.Controls.Count > 0)
                        TryTranslateForm(item.Controls);

                    string traduccion = TranslateCode(item.Tag.ToString());

                    if (traduccion == item.Tag?.ToString())
                        failedcodes.Add(item.Tag?.ToString());

                    if (traduccion.Length > 1)
                        item.Text = traduccion;
                }
            }

            if (failedcodes.Count > 0)
                _logger.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes));
            failedcodes.Clear();

        }
 
        /// <summary>
        /// Obtiene los lenguajes soportados.
        /// </summary>
        /// <returns>Retorna un diccionario con las claves y nombres de los lenguajes.</returns>
        public Dictionary<string, string> GetSupportedLanguages()
        {
            return LanguageBLL.GetSupportedLanguages();
        }

        /// <summary>
        /// Establece el nuevo lenguaje utilizando una version abreviada de su nombre.
        /// </summary>
        /// <param name="nuevolenguaje">Ejemplo: "es" para español, "en" para inglés.</param>
        /// <returns>Retorna True si el lenguaje está soportado. De lo contrario, retorna False.</returns>
        public bool SetLanguage(string nuevolenguaje)
        {

            if (LanguageIsSupported(nuevolenguaje))
            {
                CurrentLanguage = nuevolenguaje;
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si el lenguaje está soportado y cargado en el sistema.
        /// </summary>
        /// <param name="nuevolenguaje"></param>
        /// <returns>Retorna True si el lenguaje está en la lista de idiomas soportados. De lo contrario, retorna False.</returns>
        public bool LanguageIsSupported(string nuevolenguaje)
        {

            foreach (string language in LanguageBLL.GetSupportedLanguages().Keys.ToArray())
            {
                if (nuevolenguaje == language)
                {
                    CurrentLanguage = ApplicationSettings.Instance.LastLanguage;
                    return true;
                }

            }

            return false;
        }


        /// <summary>
        /// Obtiene el lenguaje actual.
        /// </summary>
        public string CurrentLanguage
        {
            get
            {
                return currentlanguage;
            }

            protected set
            {
                ApplicationSettings.Instance.LastLanguage = value.ToString();
                currentlanguage = ApplicationSettings.Instance.LastLanguage;
            }
        }


        /// <summary>
        /// Obtiene todos los controles que no poseen una traduccion
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public List<string> GetNonTranslatedControls(List<Control> controls)
        {
            List<string> nontranslatedcontrols = new List<string>();

            foreach (var item in controls)
            {
                if (!item.Tag.ToString().Contains("_"))
                {
                    nontranslatedcontrols.Add(item.Name);
                }
            }

            return nontranslatedcontrols;
        }

    }
}
