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
    /// Repositorio legacy de bitacoras en Sql server. Las clases de tipo Legacy estan obsoletas y serán removidas en futuras versiones. Use las versiones no-legacy en su lugar.
    /// </summary>
    internal class LegacySqlLoggerRepository : IGenericLegacyRepository<Log>
    {
        #region Statements
        private string InsertString
        {
            get => "INSERT INTO [dbo].[Log] (log_message, severity) VALUES (@Mensaje, @Severidad)";
        }


        private string SelectAllString
        {
            get => "SELECT log_message, severity FROM [dbo].[Log]";
        }
        #endregion

        readonly string Conn;

        /// <summary>
        /// Constructor por defecto que requiere un string de conexión.
        /// </summary>
        /// <param name="_Conn"></param>
        public LegacySqlLoggerRepository(string _Conn)
        {
            Conn = _Conn;
        }


        /// <summary>
        /// Permite insertar un registro de bitacora en la base de datos de Sql Server.
        /// </summary>
        /// <param name="Message"></param>
        public void Insert(string Message)
        {
            SqlHelper.ExecuteNonQuery(InsertString, System.Data.CommandType.Text, Conn, new SqlParameter[]
            {
                new SqlParameter("@Mensaje", Message),
                new SqlParameter("@Severidad", Log.Severity.None.ToString()),
            });
        }

        /// <summary>
        /// Trae todos los registros de bitacoras almacenados en Sql Server.
        /// </summary>
        /// <returns>Retorna un IEnumerable de bitacoras.</returns>
        public IEnumerable<string> SelectAll()
        {
            SqlHelper.SetLogMode();
            using (var dr = SqlHelper.ExecuteReader(SelectAllString, System.Data.CommandType.Text, Conn))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return LegacySqlLoggerAdapter.Instance.Adapt(values);
                }
            }
        }
    }
}
