using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseServices.Contracts;
using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Factory;
using BaseServices.Domain.Logs;

namespace BaseServices.BLL.Logger
{
    /// <summary>
    /// Gestor del registro de bitacoras en Sql Server.
    /// </summary>
    internal class SqlLogger : ILogger
    {

        private IGenericLogRepository<Log> SqlLog = FactoryDAL.SqlLogRepository;

        #region single
        private readonly static SqlLogger _instance = new SqlLogger();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static SqlLogger Instance
            {
                get
                {
                    return _instance;
                }
            }

        private SqlLogger()
        {
                
        }
        #endregion

        /// <summary>
        /// Obtiene todas las bitacoras.
        /// </summary>
        /// <returns>Retorna una lita de bitacoras.</returns>
        public List<Log> GetAll()
        {
            if (SqlLog == null)
                SqlLog = FactoryDAL.SqlLogRepository;
            return SqlLog.SelectAll().ToList();
        }

        /// <summary>
        /// Almacena una bitacora.
        /// </summary>
        /// <param name="L"></param>
        public void Store(Log L)
        {
            if(SqlLog == null)
                SqlLog = FactoryDAL.SqlLogRepository;
            SqlLog.Insert(L);
        }
    }
}
