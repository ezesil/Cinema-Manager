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

        int Backup(string db, string path);

        int Restore(string db, string path);


    }
}
