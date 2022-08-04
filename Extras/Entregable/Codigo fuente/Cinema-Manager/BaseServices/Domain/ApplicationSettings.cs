using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BaseServices.Domain
{
    /// <summary>
    /// Clase que encapsula la configuracion de la aplicacion. Las configuraciones son extraídas de AppSettings.
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Direccion de archivos.
        /// </summary>
        protected readonly string _FilePath;

        /// <summary>
        /// String de conexión de Sql Server.
        /// </summary>
        protected readonly string _SqlConnString;

        /// <summary>
        /// String de conexión de Sql Server para base master.
        /// </summary>
        protected readonly string _MasterConnString;

        /// <summary>
        /// String que indica la ubicacion de los repositorios de archivos.
        /// </summary>
        protected readonly string _FileRepository;

        /// <summary>
        /// String que indica la ubicacion de los repositorios de Sql Server.
        /// </summary>
        protected readonly string _SqlRepository;

        /// <summary>
        /// String que indica la ubicacion de los repositorios de archivos planos para las bitacoras.
        /// </summary>
        protected readonly string _FileLogRepository;

        /// <summary>
        /// String que indica la ubicacion de los repositorios de Sql Server para las bitacoras.
        /// </summary>
        protected readonly string _SqlLogRepository;

        /// <summary>
        /// String de conexion para las bitacoras en Sql Server.
        /// </summary>
        protected readonly string _SqlLogConnString;

        /// <summary>
        /// String que indica la ubicacion de los repositorios de JSON.
        /// </summary>
        protected readonly string _JsonRepository;

        /// <summary>
        /// Ultimo lenguaje seleccionado/utilizado.
        /// </summary>
        protected string _LastLanguage;

        /// <summary>
        /// Ubicacion de los repositorios SQL en los servicios de base.
        /// </summary>
        protected string _BaseSqlRepository;

        /// <summary>
        /// Ubicacion de los repositorios SQL de negocio.
        /// </summary>
        protected string _repository;

        /// <summary>
        /// 
        /// </summary>
        protected Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// Instancia interna de ApplicationSettings.
        /// </summary>
        protected static ApplicationSettings _instance = new ApplicationSettings();

        /// <summary>
        /// Constructor protegido por defecto.
        /// </summary>
        protected ApplicationSettings()
        {

            _FileLogRepository = ConfigurationManager.AppSettings["FileLogs"];
            _repository = ConfigurationManager.AppSettings["Repository"];
            _SqlLogRepository = ConfigurationManager.AppSettings["SqlLogs"];
            _FilePath = ConfigurationManager.AppSettings["FilePath"];
            _FileRepository = ConfigurationManager.AppSettings["FileRepository"].ToString();
            _SqlRepository = ConfigurationManager.AppSettings["SqlServerRepository"].ToString();
            _JsonRepository = ConfigurationManager.AppSettings["JsonRepository"].ToString();
            _LastLanguage = ConfigurationManager.AppSettings["LastLang"].ToString();
            _BaseSqlRepository = ConfigurationManager.AppSettings["BaseSqlServerRepository"].ToString();

            _SqlLogConnString = ConfigurationManager.ConnectionStrings["SqlLogConnString"].ConnectionString;
            _SqlConnString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
            _MasterConnString = ConfigurationManager.ConnectionStrings["MasterConnString"].ConnectionString;

        }

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static ApplicationSettings Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Direccion de archivos.
        /// </summary>
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
        }

        /// <summary>
        /// String de conexión de Sql Server.
        /// </summary>
        public string SqlConnString
        {
            get
            {
                return _SqlConnString;
            }
        }

        /// <summary>
        /// String que indica la ubicacion de los repositorios de archivos.
        /// </summary>
        public string Repository
        {
            get
            {
                return _repository;
            }
        }

        /// <summary>
        /// String que indica la ubicacion de los repositorios de archivos.
        /// </summary>
        public string FileRepository
        {
            get
            {
                return _FileRepository;
            }
        }

        /// <summary>
        /// String que indica la ubicacion de los repositorios de Sql Server.
        /// </summary>
        public string SqlRepository
        {
            get
            {
                return _SqlRepository;
            }
        }

        /// <summary>
        /// String que indica la ubicacion de los repositorios de archivos planos para las bitacoras.
        /// </summary>
        public string FileLogRepository
        {
            get
            {
                return _FileLogRepository;
            }
        }

        /// <summary>
        /// String que indica la ubicacion de los repositorios de Sql Server para las bitacoras.
        /// </summary>
        public string SqlLogRepository
        {
            get
            {
                return _SqlLogRepository;
            }
        }

        /// <summary>
        /// String de conexion para las bitacoras en Sql Server.
        /// </summary>
        public string SqlLogConnString
        {
            get
            {
                return _SqlLogConnString;
            }
        }

        /// <summary>
        /// String que indica la ubicacion de los repositorios de JSON.
        /// </summary>
        public string JsonRepository
        {
            get
            {
                return _JsonRepository;
            }
        }

        /// <summary>
        /// Ultimo lenguaje seleccionado/utilizado.
        /// </summary>
        public string LastLanguage
        {
            get
            {
                return _LastLanguage;
            }

            set
            {
                _LastLanguage = value.ToLower();
                configuration.AppSettings.Settings["LastLang"].Value = value.ToLower();
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        /// <summary>
        /// Ubicacion de los repositorios Sql server en los servicios de base.
        /// </summary>
        public string BaseSqlRepository
        {
            get
            {
                return _BaseSqlRepository;
            }
        }

        /// <summary>
        /// String de conexión de Sql Server para base master.
        /// </summary>
        public string MasterConnString
        {
            get 
            { 
                return _MasterConnString; 
            }
        }
    }
}
