using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BaseServices.BLL;
using BaseServices.Domain;
using BaseServices.Services.Extensions;

namespace BaseServices.Services
{
    /// <summary>
    /// Gestiona la recepcion de excepciones para su posterior manejo.
    /// </summary>
    public class ExceptionHandler
    {
        [Serializable]
        private class GenericException : Exception
        {
            public GenericException() : base("Ocurrió un error desconocido, contacte al administrador. \nEl error fue registrado.")
            {

            }         
        }

        [Serializable]
        private class HandledException : Exception
        {
            public HandledException(string message) : base(message)
            {

            }
        }

        private Dictionary<Type, string> _exceptions { get; set; }

        public delegate void LogEventHandler(string message, LogLevel severity = LogLevel.Low, string stacktrace = "");
        public event LogEventHandler OnExceptionHandled;

        public ExceptionHandler()
        {
            if(_exceptions == null)
                _exceptions = new Dictionary<Type, string>();

            Register<GenericException>();
        }

        /// <summary>
        /// Permite registrar una excepcion en el manejador de excepciones.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="message"></param>
        /// <exception cref="Exception"></exception>
        public void Register<TException>(string? message = null) where TException : Exception, new()
        {
            if(_exceptions.Count(x => x.Key.GetType() == typeof(TException)) > 0)
                throw new Exception("La excepcion ya fue registrada anteriormente.");
            
            var exception = new TException();
            _exceptions.Add(typeof(TException), message == null ? exception.Message : message);                   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="ex"></param>
        /// <returns></returns>
        public Exception Handle<TException>(TException ex) where TException : Exception, new()
        {
            try
            {
                string? result = null;
                if (_exceptions.TryGetValue(ex.GetType(), out result))
                {
                    return new HandledException(result);
                }
                else
                {
                    var stacktrace = "";

                    if(OnExceptionHandled != null)
                        OnExceptionHandled.Invoke(result, ex.GetSeverityLevel(), ex.GetFullStackTrace());

                    return new GenericException();
                }
            }
            catch(Exception exx)
            {
                return new HandledException(exx.Message);
            }         
        }       
    }
}
