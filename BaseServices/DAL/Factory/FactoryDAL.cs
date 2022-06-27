using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;
using ApplicationSettings = BaseServices.Domain.ApplicationSettings;
using BaseServices.Domain;

namespace BaseServices.DAL.Factory
{
    /// <summary>
    /// Clase de tipo Factory para los servicios de base.
    /// </summary>
    internal static class FactoryDAL
    {
        /// <summary>
        /// Ubicacion de los repositorios en archivo plano.
        /// </summary>
        readonly static string FileRepository;

        /// <summary>
        /// Ubicacion de los repositorios en Sql Server.
        /// </summary>
        readonly static string BaseSqlRepository;

        /// <summary>
        /// Ubicacion de los repositorios de bitacoras en SqlServer.
        /// </summary>
        readonly static string SqlLogRepositorio;

        /// <summary>
        /// Ubicacion de los repositorios de archivos JSON.
        /// </summary>
        readonly static string JsonRepository;

        /// <summary>
        /// Repositorio de DVV.
        /// </summary>
        public static IGenericDVVRepository DVVRepository { get; private set; }

        /// <summary>
        /// Instancia del repositorio de bitacoras en archivo plano.
        /// </summary>
        public static IGenericLogRepository<Log> FileLogRepository { get; private set; }

        /// <summary>
        /// Instancia del repositorio de bitacoras en SqlServer.
        /// </summary>
        public static IGenericLogRepository<Log> SqlLogRepository { get; private set; }

        /// <summary>
        /// Instancia del repositorio de Personas para los servicios de base.
        /// </summary>
        public static IGenericRepository<User> UserRepository { get; private set; }

        /// <summary>
        /// Instancia del repositorio del servicio de soporte de multi-lenguaje.
        /// </summary>
        public static ILanguageRepository LanguageRepository { get; private set; }

        /// <summary>
        /// Instancia del repositorio de backup y restore.
        /// </summary>
        public static IBackupRestoreRepository BackupRestoreRepository { get; private set; }

        /// <summary>
        /// Instancia del repositorio de permisos.
        /// </summary>
        public static IGenericRepository<Rol> RolRepository { get; private set; }


        static FactoryDAL()
        {
            FileRepository = ApplicationSettings.Instance.FileRepository;
            SqlLogRepositorio = ApplicationSettings.Instance.SqlLogRepository;
            BaseSqlRepository = ApplicationSettings.Instance.BaseSqlRepository;
            JsonRepository = ApplicationSettings.Instance.JsonRepository;


            RolRepository = CreateInstance<IGenericRepository<Rol>>("BaseServices." + BaseSqlRepository + ".RolRepository");
            BackupRestoreRepository = CreateInstance<IBackupRestoreRepository>("BaseServices." + BaseSqlRepository + ".BackupRestoreRepository");
            DVVRepository = CreateInstance<IGenericDVVRepository>("BaseServices." + BaseSqlRepository + ".DVVRepository");
            LanguageRepository = CreateInstance<ILanguageRepository>("BaseServices." + JsonRepository + ".LanguageRepository");
            UserRepository = CreateInstance<IGenericRepository<User>>("BaseServices." + BaseSqlRepository + ".UsersRepository");
            FileLogRepository = CreateInstance<IGenericLogRepository<Log>>("BaseServices." + FileRepository + ".FileRepository");
            SqlLogRepository = CreateInstance<IGenericLogRepository<Log>>("BaseServices." + SqlLogRepositorio + ".LogRepository");





            //BackupRestoreRepository = (IBackupRestoreRepository)Activator.CreateInstance(Type.GetType("BaseServices." + BaseSqlRepository + ".BackupRestoreRepository"));
            //DVVRepository = (IGenericDVVRepository)Activator.CreateInstance(Type.GetType("BaseServices." + BaseSqlRepository + ".DVVRepository"));
            //LanguageRepository = (ILanguageRepository)Activator.CreateInstance(Type.GetType("BaseServices." + JsonRepository + ".LanguageRepository" ));
            //PersonaRepository = (ILoginRepository<Persona>)Activator.CreateInstance(Type.GetType("BaseServices." + BaseSqlRepository + ".PersonaRepository"));
            //FileLogRepository = (IGenericLogRepository<Log>)Activator.CreateInstance(Type.GetType("BaseServices." + FileRepository + ".FileRepository"));
            //SqlLogRepository = (IGenericLogRepository<Log>)Activator.CreateInstance(Type.GetType("BaseServices." + SqlLogRepositorio + ".SqlLoggerRepository"));
        }


        private static T CreateInstance<T>(string type)
        {
            return (T)Activator.CreateInstance(Type.GetType(type));
        }



    }
}
