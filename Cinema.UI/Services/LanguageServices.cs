using BaseServices.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.Domain.Logs;
using BaseServices.Domain.RepoSettings;
using System.Windows.Forms;

namespace BaseServices.Services
{
    /// <summary>
    /// Servicio de soporte para multiples lenguajes.
    /// </summary>
    public class LanguageServices
    {
        #region Singleton
        private readonly static LanguageServices _instance = new LanguageServices();

        /// <summary>
        /// Delegado para el refresco de traducciones.
        /// </summary>
        public delegate void LanguageRefresh();

        /// <summary>
        /// Instancia del refrescador de lenguaje. Invocar para traducir todos los formularios y controles suscritos.
        /// </summary>
        public static LanguageRefresh refresher;

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static LanguageServices Current
        {
            get
            {
                return _instance;
            }
        }

        private LanguageServices()
        {

        }
        #endregion

        /// <summary>
        /// Lenguaje actual, extraído de Application settings como "ultimo lenguaje".
        /// </summary>
        private static string currentlanguage = ApplicationSettings.Instance.LastLanguage;
        private static List<string> failedcodes = new List<string>();
        //private static List<object> Controls = new List<object>();

        /// <summary>
        /// Verifica el estado de traduccion del formulario.
        /// </summary>
        /// <param name="controls"></param>
        /// <returns>Retorna dos listados. El primer listado corresponde al listado de codigos utilizados. El segundo listado correponde al listado de controles sin traduccion.</returns>
        public static List<string>[] CheckControlsTranslationStatus(Control.ControlCollection controls)
        {
            List<string>[] translatecodes = new List<string>[2] {

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
            return LanguageManager.GetTranslation(currentlanguage, code);
        }

        /// <summary>
        /// Intenta traducir un formulario
        /// </summary>
        /// <param name="form"></param>
        public void TryTranslateForm(CheckedListBoxControl form)
        {

            try
            {
                string trad = TranslateCode(form.Tag?.ToString());
                if (form.Tag != null && trad == form.Tag?.ToString())
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

                foreach (CheckedListBoxItem item in form.Items)
                {
                    if (item.Tag != null)
                    {
                        string traduccion = TranslateCode(item.Tag.ToString());

                        if (traduccion == item.Tag.ToString() && item.Tag.ToString().Length > 3)
                            failedcodes.Add(item.Tag.ToString());

                        if (traduccion.Length > 1)
                            item.Description = traduccion;
                    }
                }

                if (failedcodes.Count > 0)
                    Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

                failedcodes.Clear();
            }

            catch (Exception ex)
            {
                Security.LogServices.LogService.LogEvent(new Domain.Log(ex.Message, Log.Severity.DebugInformation, ex.StackTrace));
            }


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
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

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
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

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
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

            failedcodes.Clear();

        }


        /// <summary>
        /// Intenta traducir un objeto de tipo AccordionControl.
        /// </summary>
        /// <param name="form"></param>
        public void TryTranslateForm(AccordionControl form)
        {
            string trad = TranslateCode(form.Tag?.ToString());

            if (form.Tag is null)
            {
                form.Text = "NULL";
            }

            else if (trad == form.Tag?.ToString())
            {
                failedcodes.Add("" + form.Tag?.ToString());
            }

            else
            {
                form.Text = trad;
            }

            if (form.Elements.Count > 0)
                TryTranslateForm(form.Elements);

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
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

            failedcodes.Clear();

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
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

            failedcodes.Clear();

        }


        /// <summary>
        /// Intenta traducir un formulario. Analiza todos los controles de un formulario en busqueda de tags con codigos de traduccion validos.
        /// </summary>
        /// <param name="f"></param>
        public void TryTranslateForm(AccordionControlElementCollection f)
        {

            foreach (var item in f)
            {
                if (item.Elements.Count > 0)
                    TryTranslateForm(item.Elements);

                if (item.Tag != null)
                {
                    if (item.Tag.ToString().Contains("_"))
                    {
                        string traduccion = TranslateCode(item.Tag.ToString());

                        if (traduccion == item.Tag?.ToString())
                            failedcodes.Add(item.Tag?.ToString());

                        if (traduccion.Length > 1)
                            item.Text = traduccion;
                    }
                }

            }
            if (failedcodes.Count > 0)
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

            failedcodes.Clear();

        }


        /// <summary>
        /// Intenta traducir un formulario. Analiza todos los controles de un formulario en busqueda de tags con codigos de traduccion validos.
        /// </summary>
        /// <param name="f"></param>
        public void TryTranslateForm(AccordionControlElement f)
        {
            string trad = TranslateCode(f.Tag?.ToString());
            if (trad == f.Tag?.ToString())
            {
                failedcodes.Add("" + f.Tag?.ToString() + "\n");
            }
            else if (f.Tag is null)
            {
                f.Text = "NULL";
            }

            else
            {
                f.Text = trad;
            }

            foreach (var item in f.Elements)
            {
                if (item.Elements.Count > 0)
                    TryTranslateForm(item.Elements);

                if (item.Tag != null)
                {
                    if (item.Tag.ToString().Contains("_"))
                    {
                        string traduccion = TranslateCode(item.Tag.ToString());

                        if (traduccion == item.Tag.ToString())
                            failedcodes.Add(item.Tag.ToString());

                        if (traduccion.Length > 1)
                            item.Text = traduccion;
                    }
                }
            }
            if (failedcodes.Count > 0)
                Security.LogServices.LogService.LogEvent(new Domain.Log("Fallos de traduccion encontrados. Lenguaje actual: " + CurrentLanguage, Log.Severity.Low, string.Join(",\n", failedcodes)));

            failedcodes.Clear();

        }


        /// <summary>
        /// Intenta traducir un formulario. Analiza todos los controles de un formulario en busqueda de tags con codigos de traduccion validos.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="cleantext"></param>
        private void TryTranslateForm(AccordionControlElement f, bool cleantext)
        {
            foreach (var item in f.Elements)
            {
                if (cleantext)
                    item.Text = "";

                if (item.Tag != null)
                {
                    if (item.Tag.ToString().Contains("_"))
                    {
                        string traduccion = TranslateCode(item.Tag.ToString());

                        if (traduccion == item.Tag.ToString())
                            failedcodes.Add(item.Tag.ToString());

                        if (traduccion.Length > 1)
                            item.Text = traduccion;
                        else
                            item.Text = "Error";
                    }
                }
            }
        }


        /// <summary>
        /// Obtiene los lenguajes soportados.
        /// </summary>
        /// <returns>Retorna un diccionario con las claves y nombres de los lenguajes.</returns>
        public Dictionary<string, string> GetSupportedLanguages()
        {
            return LanguageManager.GetSupportedLanguages();
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

            foreach (string language in LanguageManager.GetSupportedLanguages().Keys.ToArray())
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
        /// Evalúa el estado de traduccion de una lista de controles de formulario.
        /// </summary>
        /// <param name="controls"></param>
        /// <returns>Retorna un vector de 2 listas. La primera lista corresponde a codigos de traduccion. La segunda lista corresponde a nombres de controles que no poseen un codigo de traduccion.</returns>
        public List<string>[] CheckControlsTranslationStatus(Control.ControlCollection controls)
        {
            return LanguageManager.CheckControlsTranslationStatus(controls);

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
