using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.Contracts;
using System.IO;
using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Factory;
using BaseServices.Domain.Logs;
using BaseServices.Services;

namespace BaseServices.BLL.Logger
{
    /// <summary>
    /// Gestiona el almacenamiento y obtencion de bitacoras en archivos planos.
    /// </summary>
    internal class FileLogger : ILogger
    {

        /// <summary>
        /// Repositorio de archivos de bitacoras.
        /// </summary>
        private IGenericLogRepository<Log> FileLog = FactoryDAL.FileLogRepository;

        #region single
        
        private static FileLogger _instance = new FileLogger();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static FileLogger Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new FileLogger();
                return _instance;
            }
        }

        private FileLogger()
        {
            
        }
        #endregion

        /// <summary>
        /// Obtiene todas las bitacoras que existen en el repositorio.
        /// </summary>
        /// <returns>Retorna un listado de bitacoras. Retorna null si falla.</returns>
        public List<Log> GetAll()
        {           
            try
            {
                if (FileLog == null)
                    FileLog = FactoryDAL.SqlLogRepository;
                return FileLog.SelectAll().ToList();
            }
            catch (Exception ex)
            {
                InstanceManager.Get<ExceptionHandlerService>().Handle(ex);
                return null;
            }

        }

        /// <summary>
        /// Almacena la bitacora en archivo plano.
        /// </summary>
        /// <param name="L"></param>
        public void Store(Log L)
        {
            if(FileLog == null)
                FileLog = FactoryDAL.FileLogRepository;
            FileLog.Insert(L);
        }
    }
}
