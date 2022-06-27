using BaseServices.BLL;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    /// <summary>
    /// Servicio de soporte para multiples lenguajes.
    /// </summary>
    public class LanguageService
    {
        #region Singleton

        /// <summary>
        /// Delegado para el refresco de traducciones.
        /// </summary>
        public delegate void LanguageRefresh();

        /// <summary>
        /// Instancia del refrescador de lenguaje. Invocar para traducir todos los formularios y controles suscritos.
        /// </summary>
        public LanguageRefresh refresher;

        private LanguageService()
        {

        }
        #endregion

        /// <summary>
        /// Lenguaje actual, extraído de Application settings como "ultimo lenguaje".
        /// </summary>
        private static string currentlanguage = ApplicationSettings.Instance.LastLanguage;

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

            foreach (string language in LanguageBLL.GetSupportedLanguages().Keys.ToArray<string>())
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
    }
}
