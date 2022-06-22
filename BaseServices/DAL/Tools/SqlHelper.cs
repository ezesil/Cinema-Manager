using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BaseServices.Domain;
using System.Runtime.CompilerServices;
using BaseServices.Services;
using BaseServices.Domain.Settings;

namespace BaseServices.DAL.Tools
{
    internal static class SqlHelper
    {
        static ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        static LogService _logger = ServiceContainer.Get<LogService>();

        static string conString;
        readonly static string _logConString;
        readonly static string _sqlConString;
        readonly static string _sqlProfileConString;

        static SqlConnection sqlConnection;
        static SqlTransaction transaction;

        public static string logConString
        {
            get => _logConString;
        }

        public static string sqlConString
        {
            get => _sqlConString;
        }

        public static string sqlProfileConString { get => _sqlProfileConString; }

        static SqlHelper()
        {
            _logConString = ApplicationSettings.Instance.SqlLogConnString;
            _sqlConString = ApplicationSettings.Instance.SqlConnString;
            conString = logConString;
            _sqlProfileConString = ApplicationSettings.Instance.SqlConnString;
        }

        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect 
                        // type is only for OLE DB.  
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                return 0;
            }
        }


        /// <summary>
        /// Ejecuta un query dentro de una transaccion. No puede utilizarse si la transacion no esta abierta o si la conexion está cerrada.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Int32 ExecuteNonQueryOnTran(String commandText,
                CommandType commandType, params SqlParameter[] parameters)
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                throw new Exception("La conexion esta cerrada.");
            }

            using (SqlCommand cmd = new SqlCommand(commandText, sqlConnection, transaction))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Intenta abrir la conexion con la cadena de conexion default en ApplicationSettings. Si falla, lanza una excepcion de tipo SqlException.
        /// </summary>
        public static void Open()
        {
            sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
        }

        /// <summary>
        /// Comienza una transaccion con la conexión default. Si la conexion está cerrada, este metodo lanzará una excepción de tipo DALException.
        /// </summary>
        public static void BeginTransaction()
        {
            try
            {
                if (SqlHelper.sqlConnection.State == ConnectionState.Closed)
                    throw new Exception("La conexión está cerrada.");

                transaction = sqlConnection.BeginTransaction();
            }


            catch (Exception ex)
            {
                _exhandler.Handle(ex);
            }
        }

        /// <summary>
        /// Efectúa un Commit en la transaccion actual. Si falla, debe ser manejado con un rollback.
        /// </summary>
        public static void Commit()
        {
            transaction.Commit();

        }

        /// <summary>
        /// Cierra la conexion.
        /// </summary>
        public static void Close()
        {
            sqlConnection.Close();
        }

        /// <summary>
        /// Metodo para efectuar un Rollback en la base de datos si la transaccion falla.
        /// </summary>
        public static void Rollback()
        {
            try
            {
                if (transaction != null)
                    transaction.Rollback();

                else
                {
                    throw new Exception("Hubo un problema de conexion con la base de datos. Codigo: BSD01");
                }
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                throw;
            }
        }

        /// <summary>
        /// Guarda un punto de la transaccion.
        /// </summary>
        /// <param name="name">Nombre del punto de guardado.</param>
        public static void SavePoint(string name)
        {
            transaction.Save(name);
        }

        public static void SetLogMode()
        {
            conString = logConString;
        }

        public static void SetSqlMode()
        {
            conString = sqlConString;
        }

        public static void SetSqlProfileMode()
        {
            conString = sqlProfileConString;
        }

        public static void SetSqlMode(string db)
        {
            conString = sqlConString.Replace("AnuncioDB", db);
        }

        public static void SetMasterMode()
        {
            conString = sqlConString.Replace("AnuncioDB", "master");
        }



        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, string Conn, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conn))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect 
                        // type is only for OLE DB.  
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }

            catch(Exception ex)
            {
                _exhandler.Handle(ex);
                return 0;
            }
        }



        /// <summary>
        /// Set the connection, command, and then execute the command and only return one value.
        /// </summary>
        public static Object ExecuteScalar(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }

            catch (Exception ex)
            {
                _exhandler.Handle(ex);
                return null;
            }

        }

        /// <summary>
        /// Set the connection, command, and then execute the command with query and return the reader.
        /// </summary>
        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                SqlConnection conn = new SqlConnection(conString);

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                    // IDataReader is closed.
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    return reader;
                }
            }

            catch (SqlException ex)
            {
                _exhandler.Handle(ex);
                return null;
            }
        }

        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, string Conn, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(Conn);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                // IDataReader is closed.
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}
