using BaseServices.Domain;
using BaseServices.Services;
using Cinema.DAL.Interfaces;
using Cinema.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql
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

        private TAdapter? genericAdapter { get; set; }

        private ExceptionHandler exceptionHandler { get; }
        private Logger logService { get; }



        public SqlRepository(string deleteQuery, string selectAllQuery, string selectQuery, string insertQuery, string updateQuery)
        {
            DeleteQuery = deleteQuery;
            SelectAllQuery = selectAllQuery;
            SelectQuery = selectQuery;
            InsertQuery = insertQuery;
            UpdateQuery = updateQuery;
            exceptionHandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
            logService = ServiceContainer.Instance.GetService<Logger>();
            genericAdapter = new TAdapter();
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
                        cmd.Parameters.AddRange(GetParameters(parameters));

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

        public virtual IEnumerable<TEntity> GetAll(object paramss = null, string queryOverride = "")
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
                if (paramss != null)
                {
                    cmd.Parameters.AddRange(GetParameters(paramss));
                    cmd.Parameters.Add(new SqlParameter("@Filter", "1"));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@Filter", "0"));
                }

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
                    cmd.Parameters.AddRange(GetParameters(parameters));
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
                        cmd.Parameters.AddRange(GetParameters(parameters));

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
                        cmd.Parameters.AddRange(GetParameters(parameters));

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

        private SqlParameter[] GetParameters(object args)
        {
            Type myType = args.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            var parameters = new SqlParameter[props.Count];

            int i = 0;
            foreach (PropertyInfo prop in props)
            {   
                parameters[i] = new SqlParameter("@" + prop.Name, prop.GetValue(args,null));
                object propValue = prop.GetValue(args, null);
                i++;
            }

            return parameters;
        }
    }
}
