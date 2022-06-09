﻿using BaseServices.DAL.Factory;
using BaseServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    /// <summary>
    /// Provee herramientas para la ejecucion de copias de seguridad y restauracion de bases de datos.
    /// </summary>
    internal class BackupManager
    {

        #region Singleton
        private readonly static BackupManager _instance = new BackupManager();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static BackupManager Current
        {
            get
            {
                return _instance;
            }
        }

        private BackupManager()
        {

        }
        #endregion


        IBackupRestoreRepository repo = FactoryDAL.BackupRestoreRepository;

        /// <summary>
        /// Efectúa una copia de seguridad de la base de datos especificada.
        /// </summary>
        /// <param name="nombredb"></param>
        /// <param name="path"></param>
        /// <returns>Retorna un valor entero -1 si la operacion fué un exito.</returns>
        public int PerformBackup(string nombredb, string path)
        {
            if(nombredb.Length > 3 && path.Length > 3)
                return repo.Backup(nombredb, path);
            return 0;
        }

        /// <summary>
        /// Efectúa una restauracion de una base de datos.
        /// </summary>
        /// <param name="nombredb"></param>
        /// <param name="fullpath"></param>
        /// <returns>Retorna un valor entero -1 si la operacion fue un exito.</returns>
        public int PerformRestore(string nombredb, string fullpath)
        {
            if (nombredb.Length > 3 && fullpath.Length > 3)
                return repo.Restore(nombredb, fullpath);

            return 0;
        }






    }
}
