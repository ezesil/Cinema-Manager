﻿using BaseServices.BLL;
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
        /// <summary>
        /// Delegado para el refresco de traducciones.
        /// </summary>
        public delegate void LanguageRefresh();

        /// <summary>
        /// Instancia del refrescador de lenguaje. Invocar para traducir todos los formularios y controles suscritos.
        /// </summary>
        public LanguageRefresh refresher;

        public LanguageService()
        {

        }

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

        /// <summary>
        /// Obtiene el lenguaje especificado si está cargado en memoria.
        /// </summary>
        /// <param name="shortname"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetLanguageFromMemory(string shortname)
        {
            return LanguageBLL.GetLanguageFromMemory(shortname);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReloadLanguages()
        {
            LanguageBLL.ReloadLanguages();
        }

        /// <summary>
        /// Obtiene el lenguaje especificado si existe el archivo.
        /// </summary>
        /// <param name="shortname"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetLanguageFromFile(string shortname)
        {
            return LanguageBLL.GetLanguageFromFile(shortname);
        }

        /// <summary>
        /// Aplica los cambios en memoria al lenguaje especificado. 
        /// </summary>
        /// <param name="shortname"></param>
        /// <param name="lang"></param>
        public void SaveLanguageInMemory(string shortname, Dictionary<string, string> lang)
        {
            LanguageBLL.SaveLanguageInMemory(shortname, lang);
        }

        /// <summary>
        /// Guarda un archivo de idioma en el archivo correspondiente al lenguaje especificado.
        /// </summary>
        /// <param name="shortname"></param>
        /// <param name="lang"></param>
        public void SaveLanguageInFile(string shortname, Dictionary<string, string> lang)
        {
            LanguageBLL.SaveLanguageInFile(shortname, lang);
        }

        /// <summary>
        /// Escribe el archivo de lenguajes soportados.
        /// </summary>
        /// <param name="lang"></param>
        public void SaveSupportedLanguagesFile(Dictionary<string, string> lang)
        {
            LanguageBLL.SaveSupportedLanguagesFile(lang);
        }

        public void CreateLanguage(string shortname, string name)
        {
            LanguageBLL.CreateLanguage(shortname, name);
        }


        public void RemoveLanguageSupport(string shortname)
        {
            LanguageBLL.RemoveLanguageSupport(shortname);
        }

        public void AddLanguageSupport(string shortname, string name, Dictionary<string, string> lang)
        {
            LanguageBLL.AddLanguageSupport(shortname, name, lang);
        }
    }
}
