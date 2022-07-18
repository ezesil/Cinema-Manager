using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
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

        private string connString { get => RepositoryType == RepoType.Cinema ? ApplicationSettings.Instance.SqlConnString : ApplicationSettings.Instance.SqlLogConnString; }

        private TAdapter? genericAdapter { get; set; }

        private ExceptionHandler exceptionHandler { get; }
        private Logger logService { get; }

        private RepoType RepositoryType { get; set; }



        public SqlRepository(string deleteQuery, string selectAllQuery, string selectQuery, string insertQuery, string updateQuery, RepoType type = RepoType.Cinema)
        {
            RepositoryType = type;
            DeleteQuery = deleteQuery;
            SelectAllQuery = selectAllQuery;
            SelectQuery = selectQuery;
            InsertQuery = insertQuery;
            UpdateQuery = updateQuery;
            exceptionHandler = ServiceContainer.Get<ExceptionHandler>();
            logService = ServiceContainer.Get<Logger>();
            genericAdapter = new TAdapter();
        }


        public virtual int Delete(string query, object parameters)
        {
            return Delete(parameters, query);
        }
        public virtual int Delete(object parameters, string queryOverride = "")
        {
            try
            {
                var query = DeleteQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;

                if (genericAdapter == null)
                    genericAdapter = new TAdapter();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters));

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
            if (queryOverride != null && queryOverride != "")
                query = queryOverride;

            if (genericAdapter == null)
                genericAdapter = new TAdapter();

            SqlConnection conn = new SqlConnection(connString);
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    object[] values = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        yield return genericAdapter.Adapt(values);
                    }
                }
            }
        }


        public virtual TEntity GetOne(string query, object parameters)
        {
            return GetOne(parameters, query);
        }
        public virtual TEntity GetOne(object parameters, string queryOverride = "")
        {
            try
            {
                var query = SelectQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;

                if (genericAdapter == null)
                    genericAdapter = new TAdapter();

                SqlConnection conn = new SqlConnection(connString);
                SqlDataReader reader;
                object[]? values = null;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                        values = new object[reader.FieldCount];

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

        public virtual int Insert(string query, object parameters)
        {
            return Insert(parameters, query);
        }
        public virtual int Insert(object parameters, string queryOverride = "")
        {
            var query = InsertQuery;
            if (queryOverride != null && queryOverride != "")
                query = queryOverride;

            if (genericAdapter == null)
                genericAdapter = new TAdapter();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters, query));

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

        public virtual int Update(string query, object parameters)
        {
            return Update(parameters, query);
        }
        public virtual int Update(object parameters, string queryOverride = "")
        {
            try
            {
                var query = UpdateQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;

                if (genericAdapter == null)
                    genericAdapter = new TAdapter();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters));

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

        public bool ExecuteStoreProcedure(SqlParameter[] parameters, string storedName)
        {
            Object[] values;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(storedName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }


    }

    public static class SqlRepository
    {
        private static string connString { get => ApplicationSettings.Instance.SqlConnString; }

        internal static SqlParameter[] GetParameters(object args)
        {
            Type myType = args.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            var parameters = new List<SqlParameter>();

            int i = 0;
            foreach (PropertyInfo prop in props)
            {
                parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(args, null)));
                i++;
            }

            return parameters.ToArray();
        }

        internal static SqlParameter[] GetParameters(object args, string query)
        {
            Type myType = args.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            var parameters = new List<SqlParameter>();

            int i = 0;
            foreach (PropertyInfo prop in props)
            {
                if (query.Contains("@" + prop.Name))
                {
                    parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(args, null)));
                }
                i++;
            }

            return parameters.ToArray();
        }

        public static bool ExecuteStoreProcedure(object parameters, string storedName)
        {
            Object[] values;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(storedName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(GetParameters(parameters));
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
    }

    public enum RepoType
    {
        Cinema,
        Log
    }
}
