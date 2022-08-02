using BaseServices.BLL.Logger;
using BaseServices.Contracts;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    /// <summary>
    /// Servicio para el registro de eventos.
    /// </summary>
    public class Logger
    {
        private Logger _logger;

        internal Logger GetInstance()
        {
            if( _logger == null )
                _logger = new Logger();

            return _logger;

        }

        /// <summary>
        /// Instancia para el registro de eventos en archivo plano.
        /// </summary>
        ILogger file_logger = FileLogger.Instance;

        /// <summary>
        /// Instancia para el registro de eventos en una base de datos de Sql Server.
        /// </summary>
        ILogger sql_logger = SqlLogger.Instance;

        /// <summary>
        /// Permite el registro de eventos en ambos origenes de datos (Archivo plano y Sql Server).
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <param name="stackTrace"></param>
        public void Log(string message, LogLevel severity = LogLevel.Low, string stackTrace = "")
        {
            var L = new Log(message, severity, stackTrace);
            WarningNotifier.Instance.ScanLogMessage(L);
            file_logger.Store(L);
            sql_logger.Store(L);
        }

        /// <summary>
        /// Obtiene todos los logs del sistema almacenados localmente en formato de archivo plano.
        /// </summary>
        /// <returns></returns>
        public List<Log> GetAllFileLogs()
        {
            return FileLogger.Instance.GetAll();
        }

        /// <summary>
        /// Obtiene todos los logs del sistema almacenados en una base de datos Sql Server.
        /// </summary>
        /// <returns></returns>
        public List<Log> GetAllSqlLogs()
        {
            return SqlLogger.Instance.GetAll();
        }
    }
}

