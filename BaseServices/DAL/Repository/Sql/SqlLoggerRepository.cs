using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Tools;
using System.Data.SqlClient;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain.Logs;

namespace BaseServices.DAL.Repository.Sql
{
    /// <summary>
    /// Clase de tipo repositorio para bitacoras en Sql Server.
    /// </summary>
    internal class SqlLoggerRepository : IGenericLogRepository<Log>
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
        public SqlLoggerRepository()
        {

        }

        /// <summary>
        /// Permite insertar una bitacora en la base de datos designada.
        /// </summary>
        /// <param name="log">Bitacora de tipo Log.</param>
        public void Insert(Log log)
        {
            SqlHelper.SetLogMode();
            if (log.StackTrace == null)
                log.StackTrace = "NULL";
            SqlHelper.ExecuteNonQuery(InsertString, System.Data.CommandType.Text, new SqlParameter[]
            {
                new SqlParameter("@Mensaje", log.Message.Replace(Convert.ToChar("'"),'"')),
                new SqlParameter("@Severidad", log.SeverityLevel.ToString()),
                new SqlParameter("@StackTrace", log.StackTrace)

            });
        }

        /// <summary>
        /// Permite obtener un listado iterable de bitacoras.
        /// </summary>
        /// <returns>Retorna un IEnumerable de bitacoras.</returns>
        public IEnumerable<Log> SelectAll()
        {
            SqlHelper.SetLogMode();
            using (var dr = SqlHelper.ExecuteReader(SelectAllString, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return LogSqlAdapter.Instance.Adapt(values);
                }
            }
        }
      
    }
}
