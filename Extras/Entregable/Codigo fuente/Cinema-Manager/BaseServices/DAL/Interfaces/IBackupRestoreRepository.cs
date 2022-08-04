using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para los repositorios de comandos backup y restore.
    /// </summary>
    interface IBackupRestoreRepository
    {

        bool Backup(string db, string path);

        bool Restore(string db, string path);


    }
}
