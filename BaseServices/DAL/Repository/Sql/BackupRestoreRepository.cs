using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Tools;
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



        public int Backup(string name, string path)
        {
            try
            {
                SqlHelper.SetMasterMode();

                var parameters = new SqlParameter[2] {
                    new SqlParameter("@name", name),
                    new SqlParameter("@path", path)
                };

                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(BackupStatement, CommandType.StoredProcedure, parameters));


            }

            catch (Exception ex)
            {
                ExceptionManagerService.Handle(ex);
                return 0;
            }
            

        }

        public int Restore(string name, string path)
        {
            try
            {
                SqlHelper.SetMasterMode();

                var parameters = new SqlParameter[2] {
                new SqlParameter("@name", name),
                new SqlParameter("@path", path)
                };


                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(RestoreStatement, CommandType.StoredProcedure, parameters));
            }

            catch(Exception ex)
            {
                ExceptionManagerService.Handle(ex);
                return 0;
            }
        }
    }
}
