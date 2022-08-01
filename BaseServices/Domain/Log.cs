using BaseServices.Services.Extensions;
using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaseServices.Domain
{
    /// <summary>
    /// Clase base para las bitacoras.
    /// </summary>
    public class Log
    {

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
        public Log(string Message, LogLevel SeverityLevel)
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
        public Log(string Message, LogLevel SeverityLevel, string StackTrace)
        {
            this.Message = Message;
            this.SeverityLevel = SeverityLevel;
            this.StackTrace = StackTrace;
        }


        [VisibleOnGrid("text_date")]
        public string Fecha { get; set; } = DateTime.Now.ToString();

        /// <summary>
        /// Mensaje del evento.
        /// </summary>
        [VisibleOnGrid("text_message")]
        public string Message { get; set; } = "";


        [VisibleOnGrid("text_severityname")]
        public string SeverityName
        {
            get
            {
                return SeverityLevel.ToTextCode();
            }
            set
            {
                SeverityLevel = (LogLevel)Enum.Parse(typeof(LogLevel), value);
            }
        }

        /// <summary>
        /// Contiene informacion de la traza. Util para la depuracion.
        /// </summary>
        [VisibleOnGrid("text_stacktrace")]
        public string StackTrace { get; set; } = "";


        /// <summary>
        /// Nivel de severidad del evento.
        /// </summary>
        public LogLevel SeverityLevel { get; set; } = LogLevel.Unknown;

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
    /// Valor de severidad para el evento.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Valor de severidad nulo.
        /// </summary>
        [Description("None")]
        None,
        /// <summary>
        /// Valor de severidad bajo.
        /// </summary>
        [Description("Low")]
        Low,
        /// <summary>
        /// Valor de severidad medio.
        /// </summary>
        [Description("Medium")]
        Medium,
        /// <summary>
        /// Valor de severidad alto.
        /// </summary>
        [Description("High")]
        High,
        /// <summary>
        /// Valor de severidad critico.
        /// </summary>
        [Description("Critical")]
        Critical,
        /// <summary>
        /// Valor de severidad fatal.
        /// </summary>
        [Description("Fatal")]
        Fatal,
        /// <summary>
        /// Valor de severidad desconocido.
        /// </summary>
        [Description("Unknown")]
        Unknown,
        /// <summary>
        /// Valor de severidad de error logico.
        /// </summary>
        [Description("LogicError")]
        LogicError,
        /// <summary>
        /// Valor de severidad de acceso a datos.
        /// </summary>
        [Description("DataAccessError")]
        DataAccessError,
        /// <summary>
        /// Valor de severidad de informacion de depuracion. 
        /// </summary>
        [Description("DebugInformation")]
        DebugInformation,
    }
}
