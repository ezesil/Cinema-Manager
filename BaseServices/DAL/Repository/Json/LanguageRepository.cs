using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using BaseServices.Domain;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain.Exceptions;
using BaseServices.Services;

namespace BaseServices.DAL.Repository.Json
{
    /// <summary>
    /// Clase gestora del repositorio de lenguajes. Implementa la interfaz ILanguageRepository.
    /// </summary>
    internal class LanguageRepository : ILanguageRepository
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        LogService _logger = ServiceContainer.Get<LogService>();

        /// <summary>
        /// Busca y carga un archivo de lenguaje de formato JSON. La carpeta de busca por defecto es \locale\.
        /// </summary>
        /// <param name="Language">Nombre corto del lenguaje. Ejemplo: "es" para español, "en" para inglés.</param>
        /// <returns>Retorna un diccionario que contiene las traducciones del lenguaje indicado.</returns>
        public Dictionary<string, string> GetLanguageFile(string Language)
        {
            try
            {
                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory().ToString() + "\\locale\\" + "localization-" + Language + ".json");

                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());

                sr.Close();

                return values;
            }
            catch(Exception ex)
            {
                _exhandler.Handle(ex as DALException);
                return new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Busca el archivo JSON que contiene un diccionario con los lenguajes soportados. Si el archivo falla en cargarse,
        /// el lenguaje por defecto será Español.
        /// </summary>
        /// <returns>Retorna un diccionario de lenguajes soportados.</returns>
        public Dictionary<string, string> GetSupportedLanguages()
        {
            try
            {
                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory().ToString() + "\\locale\\" + "supportedlanguages" + ".json");

                var json = sr.ReadToEnd();

                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                sr.Close();

                return values;
            }
            catch (Exception ex)
            {

                _exhandler.Handle(ex as DALException);
                return null;
            }
        }



        /// <summary>
        /// Escribe un archivo de lenguaje. Si existe, lo sobreescribe.
        /// </summary>
        public void WriteLanguageFile(string langshortname, Dictionary<string, string> traducciones)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory().ToString() + "\\locale\\" + "localization-" + langshortname + ".json");

                var algo = JsonConvert.SerializeObject(traducciones);

                sw.Write(algo.ToString());

                sw.Close();
            }
            
            catch(Exception ex)
            {
                _exhandler.Handle(ex as DALException);
            }
        }


        public void WriteSupportedLanguagesFile(Dictionary<string, string> langlist)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory().ToString() + "\\locale\\" + "supportedlanguages" + ".json");

                var item = JsonConvert.SerializeObject(langlist);

                sw.Write(item);

                sw.Close();
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex as DALException);
            }
        }









    }
}
