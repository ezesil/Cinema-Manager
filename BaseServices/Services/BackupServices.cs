using BaseServices.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    /// <summary>
    /// Provee una interfaz para utilizar los servicios de backup de base de datos.
    /// </summary>
    public class BackupServices
    {


        /// <summary>
        /// Efectúa un backup solamente en la base de datos.
        /// </summary>
        public void BackupDatabase(string dbname, string path)
        {
            BackupBLL.Current.PerformBackup(dbname, path);
        }


        /// <summary>
        /// Efectúa un backup solamente en la base de datos.
        /// </summary>
        public void RestoreDatabase(string dbname, string path)
        {
            BackupBLL.Current.PerformRestore(dbname, path);
        }
















    }
}
