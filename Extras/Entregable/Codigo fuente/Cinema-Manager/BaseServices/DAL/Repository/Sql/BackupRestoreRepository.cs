using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using Microsoft.Extensions.DependencyInjection;
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
        ExceptionHandler _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
        Logger _logger = ServiceContainer.Instance.GetService<Logger>();

        #region Statements
        private string BackupStatement
        {
            get => "master.dbo.BackupDB";
        }

        private string RestoreStatement
        {
            get => "master.dbo.RestoreDB";
        }

        #endregion


        public bool Backup(string name, string path)
        {
            try
            {
                return SqlRepository.ExecuteStoreProcedure(new {name, path}, BackupStatement, ApplicationSettings.Instance.MasterConnString);
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
                return SqlRepository.ExecuteStoreProcedure(new { name, path }, RestoreStatement, ApplicationSettings.Instance.MasterConnString);
            }

            catch(Exception ex)
            {
                _exhandler.Handle(ex);
                return false;
            }
        }
    }
}
