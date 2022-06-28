using BaseServices.DAL.Interfaces;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
{
    internal class BackupRestoreRepository : IBackupRestoreRepository
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Logger _logger = ServiceContainer.Get<Logger>();

        #region Statements
        private string BackupStatement
        {
            get => "dbo.BackupDB";
        }

        private string RestoreStatement
        {
            get => "dbo.RestoreDB";
        }

        #endregion


        public bool Backup(string name, string path)
        {
            try
            {
                return SqlRepository.ExecuteStoreProcedure(new {name, path}, BackupStatement);
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                return false;
            }          
        }

        public bool Restore(string name, string path)
        {
            try
            {
                return SqlRepository.ExecuteStoreProcedure(new { name, path }, RestoreStatement);
            }

            catch(Exception ex)
            {
                _exhandler.Handle(ex);
                return false;
            }
        }
    }
}
