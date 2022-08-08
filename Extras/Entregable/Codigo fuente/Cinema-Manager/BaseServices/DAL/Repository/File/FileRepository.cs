using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Factory;
using BaseServices.DAL.Repository.File.Adapter;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.Domain;

namespace BaseServices.DAL.Repository.File
{
    /// <summary>
    /// Clase de tipo repositorio
    /// </summary>
    public class FileRepository : IGenericLogRepository<Log>
    {

        string FilePath;
        string LogPath;
        StreamWriter sw;
        StreamReader sr;
        FileStream stream;


        /// <summary>
        /// Constructor por defecto con un inicializador.
        /// </summary>
        public FileRepository()
        {
            Init();
        }
        
        private void Init()
        {
            try
            {
                FilePath = ApplicationSettings.Instance.FileLogRepository;
                if (FilePath == "default")
                {
                    FilePath = Directory.GetCurrentDirectory() + @"\Logs\";
                    LogPath = FilePath;

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);                       
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    }

                    else
                    {
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    }
                }

                else
                {
                    FilePath = Path.GetFullPath(FilePath);

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    }

                    else
                    {
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    }
                }
            }

            catch(Exception ex)
            {

                Console.WriteLine("Error en la configuracion de la aplicacion. Codigo de error: DRFL01");
                Console.ReadKey();
                throw;
            }        
        }

        /// <summary>
        /// Escribe un evento Log en un archivo plano.
        /// </summary>
        /// <param name="log">Bitacora.</param>
        public void Insert(Log log)
        {

            stream = new FileStream(FilePath, FileMode.Append);
            

            using (sw = new StreamWriter(stream, Encoding.UTF8))
            {
                sw.WriteLine("# System: " + log.Message);
                sw.WriteLine("$ Date: [" + DateTime.Now.ToLocalTime().ToString() + "]");
                sw.WriteLine("$ Severity: " + log.SeverityLevel.ToString());
                sw.WriteLine("$ StackTrace: " + log.StackTrace + "\n");                  
            }
        }


        /// <summary>
        /// Obtiene todas las bitacoras existentes en formato de archivo plano.
        /// </summary>
        /// <returns>Retorna un IEnumerable de bitacoras.</returns>
        public IEnumerable<Log> SelectAll()
        {
            var Dirs = Directory.GetFiles(LogPath);
            foreach (var item in Dirs)
            { 
                using (sr = new StreamReader(item))
                {
                    foreach(string log in sr.ReadToEnd().Split('#'))
                    {
                        if (log != "" && log != null && log.Length > 10)
                        {
                            string[] items = log.Split('$');
                            if (items.Length == 4)
                                yield return LogFileAdapter.Instance.Adapt(items);
                        }
                            
                    }
                }
            }           
        }
    
    }
}
