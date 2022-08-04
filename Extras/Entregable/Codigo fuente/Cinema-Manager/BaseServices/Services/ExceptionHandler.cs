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
        /// <summary>
        /// Exception generica. Error Desconocido.
        /// </summary>
        [Serializable]
        internal class GenericException : Exception
        {
            /// <summary>
            /// Constructor por defecto.
            /// </summary>
            public GenericException() : base("Ocurrió un error desconocido, contacte al administrador. \nEl error fue registrado.")
            {

            }
        }

        /// <summary>
        /// Representa a una excepcion manejada.
        /// </summary>
        [Serializable]
        public class HandledException : Exception
        {
            /// <summary>
            /// Constructor por defecto que recibe un string como mensaje.
            /// </summary>
            public HandledException(string message) : base(message)
            {

            }
        }

        private LanguageService _languageService;

        private Dictionary<Type, string> _exceptions { get; set; }
        
        /// <summary>
        /// Delegado para el manejo de eventos de logs.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <param name="stacktrace"></param>
        public delegate void LogEventHandler(string message, LogLevel severity = LogLevel.Low, string stacktrace = "");

        /// <summary>
        /// Evento para el manejo de logs.
        /// </summary>
        public event LogEventHandler OnExceptionHandled;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ExceptionHandler(LanguageService languageService)
        {
            if(_exceptions == null)
                _exceptions = new Dictionary<Type, string>();

            _languageService = languageService;

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
                if (ex.GetType() == typeof(HandledException) || ex.GetType() == typeof(GenericException))
                {
                    return ex;
                }

                string? result = null;
                if (_exceptions.TryGetValue(ex.GetType(), out result))
                {
                    result = _languageService.TranslateCode(result);
                    if (OnExceptionHandled != null)
                        OnExceptionHandled.Invoke(result == null ? ex.Message : result, ex.GetSeverityLevel(), ex.GetFullStackTrace());

                    return new HandledException(result);
                }
                else
                {
                    if(OnExceptionHandled != null)
                        OnExceptionHandled.Invoke(result == null ? ex.Message : result, ex.GetSeverityLevel(), ex.GetFullStackTrace());

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
