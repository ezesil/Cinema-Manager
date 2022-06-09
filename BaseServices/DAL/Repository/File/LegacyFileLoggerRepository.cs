using BaseServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.ComponentModel;
using BaseServices.DAL.Repository.File.Adapter;
using BaseServices.Domain.Logs;

namespace BaseServices.DAL.Repository.File
{
    /// <summary>
    /// Repositorio de bitacoras en archivo plano. Las versiones marcadas como "legacy" estan obsoletas y no funcionan correctamente. Utilice las versiones no-legacy en su lugar.
    /// </summary>
    internal class LegacyFileLoggerRepository : IGenericLegacyRepository<Log>
    {
        string FilePath;
        string LogPath;
        StreamWriter sw;
        StreamReader sr;
        FileStream stream;

        /// <summary>
        /// Constructor que toma un string de conexión como parametro.
        /// </summary>
        /// <param name="_Conn"></param>
        public LegacyFileLoggerRepository(string _Conn)
        {
            FilePath = _Conn;
            Init();                  
        }
        
        /// <summary>
        /// Inicializador.
        /// </summary>
        private void Init()
        {
            try
            {
                if (FilePath == "default")
                {
                    FilePath = Directory.GetCurrentDirectory() + @"\Logs\";
                    LogPath = FilePath;

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);                       
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss") + ".txt";
                    }

                    else
                    {
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss") + ".txt";
                    }
                }

                else
                {
                    FilePath = Path.GetFullPath(FilePath);

                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss") + ".txt";
                    }

                    else
                    {
                        FilePath = FilePath + "Log - " + DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss") + ".txt";
                    }
                }
            }

            catch
            {
                Console.WriteLine("Error en la configuracion de la aplicacion. Codigo de error: DRFL01");
                Console.ReadKey();
                return;
            }        
        }

        /// <summary>
        /// Almacena una bitacora.
        /// </summary>
        /// <param name="Message"></param>
        public void Insert(string Message)
        {
            stream = new FileStream(FilePath, FileMode.OpenOrCreate);

            using (sw = new StreamWriter(stream, Encoding.UTF8))
            {
                sw.WriteLine(Message + " ; " + Log.Severity.None.ToString());
            }
        }

        /// <summary>
        /// Trae todas las bitacoras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> SelectAll()
        {
            var Dirs = Directory.GetFiles(LogPath);
            foreach (var item in Dirs)
            { 
                using (sr = new StreamReader(item))
                {
                    yield return LegacyLogFileAdapter.Instance.Adapt(sr.ReadLine().Split(';'));
                }
            }           
        }
    }
}
