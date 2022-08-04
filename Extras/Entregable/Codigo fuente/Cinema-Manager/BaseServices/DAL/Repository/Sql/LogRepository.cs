using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain;

namespace BaseServices.DAL.Repository.Sql
{
    /// <summary>
    /// Clase de tipo repositorio para bitacoras en Sql Server.
    /// </summary>
    internal class LogRepository : SqlRepository<Log, LogSqlAdapter>,IGenericLogRepository<Log>
    {

        private static string DeleteQuery
        { get => ""; }
        private static string SelectAllQuery
        { get => "SELECT fecha_evento, log_message, severity, traza FROM [dbo].[Log]"; }
        private static string InsertQuery
        { get => "INSERT INTO [Log] (log_message, severity, traza) VALUES (@Message, @SeverityName, @StackTrace)"; }
        private static string SelectQuery
        { get => ""; }
        private static string UpdateQuery
        { get => ""; }


        public LogRepository()
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery, RepoType.Log)
        {
        }

        /// <summary>
        /// Permite insertar una bitacora en la base de datos designada.
        /// </summary>
        /// <param name="log">Bitacora de tipo Log.</param>
        public void Insert(Log log)
        {
            log.Message = log.Message == null ? "" : log.Message;
            log.StackTrace = log.StackTrace == null ? "" : log.StackTrace;
            base.Insert(log);
        }

        /// <summary>
        /// Permite obtener un listado iterable de bitacoras.
        /// </summary>
        /// <returns>Retorna un IEnumerable de bitacoras.</returns>
        public IEnumerable<Log> SelectAll()
        {
            return base.GetAll();
        }
    }
}
