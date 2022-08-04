using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para los repositorios de lenguaje.
    /// </summary>
    internal interface ILanguageRepository
    {
        /// <summary>
        /// Permite cargar un archivo de lenguaje.
        /// </summary>
        /// <param name="Language">Nombre corto del lenguaje. Ejemplo: "es" (español), "en" (inglés).</param>
        /// <returns>Devuelve un diccionario con las traducciones.</returns>
        Dictionary<string, string> GetLanguageFile(string Language);

        /// <summary>
        /// Permite cargar los lenguajes por defecto. Si falla, el lenguaje por defecto será Español (es).
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetSupportedLanguages();


        void WriteSupportedLanguagesFile(Dictionary<string, string> langlist);

        void WriteLanguageFile(string langshortname, Dictionary<string, string> traducciones);
    }
}
