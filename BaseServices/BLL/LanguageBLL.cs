using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;
using BaseServices.Services;
using BaseServices.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace BaseServices.BLL
{
    /// <summary>
    /// Gestor del sistema de multiples lenguajes.
    /// </summary>
    public static class LanguageBLL
    {
        static ExceptionHandler _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
        static Services.Logger _logger = ServiceContainer.Instance.GetService<Services.Logger>();

        /// <summary>
        /// Repositorio de lenguajes.
        /// </summary>
        readonly static ILanguageRepository langrepo;

        /// <summary>
        /// Lenguajes cargados y listos para ser utilizados.
        /// </summary>
        static Dictionary<string, Dictionary<string, string>> langs;

        /// <summary>
        /// Lenguajes soportados.
        /// </summary>
        static Dictionary<string, string> supportedlanguages;

        /// <summary>
        /// Constructor estatico del gestor de lenguajes.
        /// </summary>
        static LanguageBLL()
        {
            langrepo = BaseServices.DAL.Factory.FactoryDAL.LanguageRepository;
            Init();          
        }

        private static void Init()
        {
            supportedlanguages = new Dictionary<string, string>();

            langs = new Dictionary<string, Dictionary<string, string>>();

            Dictionary<string, string> _loadedlanguages = langrepo.GetSupportedLanguages();

            Dictionary<string, string> item = new Dictionary<string, string>();

            foreach (var supplang in _loadedlanguages)
            {
                item = new Dictionary<string, string>(langrepo.GetLanguageFile(supplang.Key));

                if (item.Count >= 1)
                {
                    langs.Add(supplang.Key, item);
                    supportedlanguages.Add(supplang.Key, supplang.Value);
                }
            }
        }





        /// <summary>
        /// Obtiene el lenguaje especificado si está cargado en memoria.
        /// </summary>
        /// <param name="shortname"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetLanguageFromMemory(string shortname)
        {
            if(langs.Keys.Contains<string>(shortname))
            {
                return langs[shortname];
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el lenguaje especificado si existe el archivo.
        /// </summary>
        /// <param name="shortname"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetLanguageFromFile(string shortname)
        {            
            return langrepo.GetLanguageFile(shortname);          
        }

        /// <summary>
        /// Aplica los cambios en memoria al lenguaje especificado. 
        /// </summary>
        /// <param name="shortname"></param>
        /// <param name="lang"></param>
        public static void SaveLanguageInMemory(string shortname, Dictionary<string, string> lang)
        {
            langs[shortname] = lang;
        }

        /// <summary>
        /// Guarda un archivo de idioma en el archivo correspondiente al lenguaje especificado.
        /// </summary>
        /// <param name="shortname"></param>
        /// <param name="lang"></param>
        public static void SaveLanguageInFile(string shortname, Dictionary<string, string> lang)
        {
            langrepo.WriteLanguageFile(shortname, lang);
        }

        /// <summary>
        /// Escribe el archivo de lenguajes soportados.
        /// </summary>
        /// <param name="lang"></param>
        public static void SaveSupportedLanguagesFile(Dictionary<string, string> lang)
        {
            langrepo.WriteSupportedLanguagesFile(lang);
        }

        public static void CreateLanguage(string shortname, string name)
        {
            Dictionary<string, string> lang = new Dictionary<string, string>();
            SaveLanguageInFile(shortname, lang);
            var item = GetSupportedLanguages();
            item[shortname] = name;
            SaveSupportedLanguagesFile(item);           
        }

        public static void ReloadLanguages()
        {
            Init();
        }


        public static void RemoveLanguageSupport(string shortname)
        {
            var item = GetSupportedLanguages();
            item.Remove(shortname);
            supportedlanguages = item;
            SaveSupportedLanguagesFile(item);
        }

        public static void AddLanguageSupport(string shortname, string name, Dictionary<string, string> lang)
        {
            var item = GetSupportedLanguages();
            item[shortname] = name;
            SaveSupportedLanguagesFile(item);
            SaveLanguageInFile(shortname, lang);
        }


        /// <summary>
        /// Obtiene la traducción para una determinada clave.
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetTranslation(string lang, string key)
        {         
            try
            {
                if (key == null)
                    return null;

                if(langs[lang].Keys.Contains<string>(key))
                    return langs[lang][key];

                return key;
            }

            catch(Exception ex)
            {
                ExceptionBLL.Current.Handle(ex as BLLException);
                return key;
            }
        }


        /// <summary>
        /// Obtiene un diccionario con las claves y nombres de los lenguajes soportados y cargados correctamente.
        /// </summary>
        /// <returns>Devuelve un diccionario con clave y valor de tipo string.</returns>
        public static Dictionary<string, string> GetSupportedLanguages()
        {
            try
            {
                return supportedlanguages;
            }
            
            catch(Exception ex)
            {
                ExceptionBLL.Current.Handle(ex as BLLException); // TODO: Crear excepcion especifica
                var i = new Dictionary<string, string>();
                i.Add("es", "Español");
                return i;
            }
        }

        /// <summary>
        /// Establece y guarda la configuracion del nuevo lenguaje seleccionado..
        /// </summary>
        /// <param name="value"></param>
        public static void SetLanguage(string value)
        {
            ApplicationSettings.Instance.LastLanguage = value;
        }
    }
}
