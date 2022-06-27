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
    internal class LogRepository : IGenericLogRepository<Log>
    {
        #region Statements
        private string InsertString
        {
            get => "INSERT INTO [Log] (log_message, severity, traza) VALUES (@Mensaje, @Severidad,@StackTrace)";
        }


        private string SelectAllString
        {
            get => "SELECT fecha_evento, log_message, severity, traza FROM [dbo].[Log]";
        }
        #endregion

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public LogRepository()
        {

        }

        /// <summary>
        /// Permite insertar una bitacora en la base de datos designada.
        /// </summary>
        /// <param name="log">Bitacora de tipo Log.</param>
        public void Insert(Log log)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite obtener un listado iterable de bitacoras.
        /// </summary>
        /// <returns>Retorna un IEnumerable de bitacoras.</returns>
        public IEnumerable<Log> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}
