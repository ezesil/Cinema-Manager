using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
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

namespace BaseServices.DAL.Repository.Sql
{
    /// <summary>
    /// Clase abstracta que contiene la implementacion necesaria para el tratamiento de repositorios.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
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

        private ExceptionHandler? exceptionHandler { get; }
        private Logger? logService { get; }

        private RepoType RepositoryType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deleteQuery"></param>
        /// <param name="selectAllQuery"></param>
        /// <param name="selectQuery"></param>
        /// <param name="insertQuery"></param>
        /// <param name="updateQuery"></param>
        /// <param name="type"></param>
        public SqlRepository(string deleteQuery, string selectAllQuery, string selectQuery, string insertQuery, string updateQuery, RepoType type = RepoType.Cinema)
        {
            RepositoryType = type;
            DeleteQuery = deleteQuery;
            SelectAllQuery = selectAllQuery;
            SelectQuery = selectQuery;
            InsertQuery = insertQuery;
            UpdateQuery = updateQuery;
            exceptionHandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
            logService = ServiceContainer.Instance.GetService<Logger>();
            genericAdapter = new TAdapter();
        }

        /// <summary>
        /// Metodo para borrar un objeto.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int Delete(string query, object parameters)
        {
            try
            {
                return Delete(parameters, query);
            }
            catch (Exception ex)
            {
                throw exceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// Metodo para borrar una base de datos.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
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
                        cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters, query));

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw exceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// Obtiene todos los elementos especificados en la query.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll(object parameters = null, string queryOverride = "")
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
                if (parameters != null)
                    cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters, query));
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

        /// <summary>
        /// Obtiene un elemento de la base de datos.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual TEntity GetOne(string query, object parameters)
        {
            return GetOne(parameters, query);
        }

        /// <summary>
        /// Obtiene un elemento de la base de datos.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
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
                    if(parameters != null)
                        cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters, query));
                    conn.Open();
                    using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        values = new object[reader.FieldCount];

                        if (!reader.HasRows)
                        {
                            return null;
                        }

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
                throw exceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// Inserta un objeto en la base de datos.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int Insert(string query, object parameters)
        {
            return Insert(parameters, query);
        }

        /// <summary>
        /// Inserta un objeto en la base de datos.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
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
                throw exceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// Actualiza un objeto en la base de datos.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int Update(string query, object parameters)
        {
            return Update(parameters, query);
        }

        /// <summary>
        /// Actualiza un objeto en la base de datos.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
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
                        cmd.Parameters.AddRange(SqlRepository.GetParameters(parameters, query));

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw exceptionHandler.Handle(ex);
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="storedName"></param>
        /// <returns></returns>
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

    /// <summary>
    /// Clase estatica con herramientas para obtener los parametros necesarios de un objeto, utilizando opcionalmente su query para la filtracion.
    /// </summary>
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

        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="storedName"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static bool ExecuteStoreProcedure(object parameters, string storedName, string connectionString = null)
        {
            Object[] values;
            var connstring = connectionString ?? connString;

            using (SqlConnection conn = new SqlConnection(connstring))
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

    /// <summary>
    /// Representa un tipo de repositorio.
    /// </summary>
    public enum RepoType
    {
        /// <summary>
        /// Repositorio de tipo Cine.
        /// </summary>
        Cinema,

        /// <summary>
        /// Repositorio de Logs.
        /// </summary>
        Log
    }
}
