using System.Collections.Generic;
using System.Linq;
using BaseServices.Contracts;
using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Factory;
using BaseServices.DAL.Repository.Sql;
using System;
using BaseServices.DAL.Repository.File;
using BaseServices.Services;
using BaseServices.Domain;

namespace BaseServices.BLL.Logger
{
    /// <summary>
    /// Permite el registro de eventos. Este gestor de bitacoras esta obsoleto y será removido. Utilice FileLogger y SqlLogger en su lugar.
    /// </summary>
    internal class Logger : ILogger
    {
        /// <summary>
        /// Tipo de origen de datos.
        /// </summary>
        Log.LogType SourceType; 

        /// <summary>
        /// String del origen de datos.
        /// </summary>
        string SourceString;

        /// <summary>
        /// Repositorio de registros en Sql server.
        /// </summary>
        private IGenericLogRepository<Log> SqlLog;

        /// <summary>
        /// Repositorio de registros en archivo plano.
        /// </summary>
        private IGenericLogRepository<Log> FileLog;


        /// <summary>
        /// Constructor para la clase Logger.
        /// </summary>
        /// <param name="_SourceType">Origen de datos de tipo Log.LogType. </param>
        /// <param name="_SourceString">String de origen de datos.</param>
        public Logger(Log.LogType _SourceType, string _SourceString)
        {
            SourceType = _SourceType;
            SourceString = _SourceString;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Message"></param>
        private void Write(string Message)
        {
            try
            { 
                if (SourceType is Log.LogType.Sql)
                {
                    //SqlLog = new LegacySqlLoggerRepository(SourceString);
                    //SqlLog.Insert(Message);
                }

                else if (SourceType is Log.LogType.File)
                {
                    //FileLog = new FileLoggerRepository(SourceString);
                    //FileLog.Insert(Message);
                }

                else
                {
                    throw new Exception("SourceType Error. Codigo de error: BSLO01");
                }
                throw new NotImplementedException();
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene todas las bitacoras segun el tipo.
        /// </summary>
        /// <returns>Retorna un vector de string representando a las bitacoras existentes.</returns>
        private string[] ReadAll()
        {
            try
            {
                if (SourceType is Log.LogType.Sql)
                {
                    //SqlLog = new LegacySqlLoggerRepository(SourceString);
                    //return SqlLog.SelectAll().ToArray();
                }

                else if (SourceType is Log.LogType.File)
                {
                    //FileLog = new FileLoggerRepository(SourceString);
                    //return FileLog.SelectAll().ToArray();
                }

                else
                {
                    throw new Exception("SourceType Error. Codigo de error: BSLO02");
                }

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                ServiceContainer.Get<ExceptionHandler>().Handle(ex);
                return null;
            }

            
        }



        /// <summary>
        /// Almacena una bitacora y la evalúa para notificacion urgente.
        /// </summary>
        /// <param name="L"></param>
        public void Store(Log L)
        {
            WarningNotifier.Instance.ScanLogMessage(L);
            Write(L.Message);
        }

        /// <summary>
        /// Interfaz para obtener todas las bitacoras.
        /// </summary>
        /// <returns></returns>
        public List<Log> GetAll()
        {         
            try
            {
                List<Log> L = new List<Log>();

                foreach (string item in ReadAll())
                {
                    L.Add(new Log { Message = item?.ToString() });
                }

                return L;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }
    }
}
