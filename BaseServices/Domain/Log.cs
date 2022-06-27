using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices.Domain
{
    /// <summary>
    /// Clase base para las bitacoras.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Mensaje del evento.
        /// </summary>
        public string Message;

        /// <summary>
        /// Nivel de severidad del evento.
        /// </summary>
        public Severity SeverityLevel;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Log()
        {

        }

        /// <summary>
        /// Constructor que toma como parametros un mensaje y el nivel de severidad del evento.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="SeverityLevel"></param>
        public Log(string Message, Severity SeverityLevel)
        {
            this.Message = Message;
            this.SeverityLevel = SeverityLevel;
        }

        /// <summary>
        /// Constructor que toma como parametros un mensaje, el nivel de severidad y la traza completa del evento.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="SeverityLevel"></param>
        /// <param name="StackTrace"></param>
        public Log(string Message, Severity SeverityLevel, string StackTrace)
        {
            this.Message = Message;
            this.SeverityLevel = SeverityLevel;
            this.StackTrace = StackTrace;
        }

        /// <summary>
        /// Valor de severidad para el evento.
        /// </summary>
        public enum Severity
        {
            /// <summary>
            /// Valor de severidad nulo.
            /// </summary>
            None,
            /// <summary>
            /// Valor de severidad bajo.
            /// </summary>
            Low,
            /// <summary>
            /// Valor de severidad medio.
            /// </summary>
            Medium,
            /// <summary>
            /// Valor de severidad alto.
            /// </summary>
            High,
            /// <summary>
            /// Valor de severidad critico.
            /// </summary>
            Critical,
            /// <summary>
            /// Valor de severidad fatal.
            /// </summary>
            Fatal,
            /// <summary>
            /// Valor de severidad desconocido.
            /// </summary>
            Unknown,
            /// <summary>
            /// Valor de severidad de error logico.
            /// </summary>
            LogicError,
            /// <summary>
            /// Valor de severidad de acceso a datos.
            /// </summary>
            DataAccessError,
            /// <summary>
            /// Valor de severidad de informacion de depuracion. 
            /// </summary>
            DebugInformation,
        }

        /// <summary>
        /// Valor que indica donde debe guardarse la bitacora. Obsoleto.
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// Valor que indica que debe guardarse en archivo plano.
            /// </summary>
            File,
            /// <summary>
            /// Valor que indica que debe guardarse en una base de datos de Sql Server.
            /// </summary>
            Sql
        }

        /// <summary>
        /// Contiene informacion de la traza. Util para la depuracion.
        /// </summary>
        public string StackTrace { get; set; }

        public string Fecha { get; set; }

    }
}
