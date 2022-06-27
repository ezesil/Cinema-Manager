using BaseServices.Domain.Exceptions;
using BaseServices.Domain.Settings;
using BaseServices.Services;
using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.SqlServer
{
    public abstract class SqlRepository<TEntity, TAdapter>
        where TEntity : class, new()
        where TAdapter : IGenericAdapter<TEntity>, new()
    { 
        private string DeleteQuery { get; set; }
        private string SelectAllQuery { get; set; }
        private string SelectQuery { get; set; }
        private string InsertQuery { get; set; }
        private string UpdateQuery { get; set; }

        private string connString { get => ApplicationSettings.Instance.SqlConnString; }

        private TAdapter? genericAdapter { get; }

        private ExceptionHandler exceptionHandler { get; }
        private LogService logService { get; }



        public SqlRepository(string deleteQuery, string selectAllQuery, string selectQuery, string insertQuery, string updateQuery)
        {
            DeleteQuery = deleteQuery;
            SelectAllQuery = selectAllQuery;
            SelectQuery = selectQuery;
            InsertQuery = insertQuery;
            UpdateQuery = updateQuery;
            exceptionHandler = ServiceContainer.Get<ExceptionHandler>();
            logService = ServiceContainer.Get<LogService>();
            genericAdapter = default(TAdapter);
        }

        public virtual int Delete(SqlParameter[] parameters, string queryOverride = "")
        {
            try
            {
                var query = DeleteQuery;
                if (queryOverride == null || queryOverride == "")
                    query = queryOverride;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(parameters);

                        conn.Open();
                        return cmd.ExecuteNonQuery();                       
                    }
                }
            }
            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
                throw;
            }
        }

        public virtual IEnumerable<TEntity> GetAll(string queryOverride = "")
        {
            var query = SelectAllQuery;
            if (queryOverride == null || queryOverride == "")
                query = queryOverride;

            SqlConnection conn = new SqlConnection(connString);
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    Object[] values = new Object[reader.FieldCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        yield return genericAdapter?.Adapt(values); ;
                    }
                }                 
            }       
        }

        public virtual TEntity GetOne(SqlParameter[] parameters, string queryOverride = "")
        {
            try
            {
                var query = SelectQuery;
                if (queryOverride == null || queryOverride == "")
                    query = queryOverride;

                SqlConnection conn = new SqlConnection(connString);
                SqlDataReader reader;
                Object[]? values = null;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        values = new Object[reader.FieldCount];

                        while (reader.Read())
                        {
                            reader.GetValues(values);                           
                        }
                    }
                }
                return genericAdapter?.Adapt(values);
            }

            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
                throw;
            }
        }

        public virtual int Insert(SqlParameter[] parameters, string queryOverride = "")
        {
            var query = InsertQuery;
            if (queryOverride == null || queryOverride == "")
                query = queryOverride;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
                throw;
            }
        }

        public virtual int Update(SqlParameter[] parameters, string queryOverride = "")
        {
            try
            {
                var query = UpdateQuery;
                if (queryOverride == null || queryOverride == "")
                    query = queryOverride;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                exceptionHandler.Handle(ex);
                throw;
            }
        }


    }
}
