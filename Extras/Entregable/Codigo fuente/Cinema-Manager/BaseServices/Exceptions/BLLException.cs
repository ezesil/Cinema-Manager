using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices.Exceptions
{
    /// <summary>
    /// Representa errores ocurridos durante la logica de negocio. Tambien puede ser una excepcion de tipo acceso a datos si es interna.
    /// </summary>
    public class BLLException : Exception
    {

        /// <summary>
        /// Indica si es una exception de logica de negocio.
        /// </summary>
        public bool IsBusinessException { get; private set; }

        /// <summary>
        /// Constructor que toma un valor booleano indicando si es una excepción de logica de negocio.
        /// </summary>
        /// <param name="IsBusinessException"></param>
        public BLLException(bool IsBusinessException = false)
        {
            this.IsBusinessException = IsBusinessException;
        }

        /// <summary>
        /// Constructor que toma un valor para el mensaje y un booleano indicando si es excepcion de logica de negocio.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="IsBusinessException"></param>
        public BLLException(string message, bool IsBusinessException = false) : base(message)
        {
            this.IsBusinessException = IsBusinessException;
        }

        /// <summary>
        /// Constructor que toma como parametros una excepcion y un booleano que indica si es una excepcion de logica de negocio.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="IsBusinessException"></param>
        public BLLException(Exception ex, bool IsBusinessException = false) : base(ex.Message, ex)
        {
            this.IsBusinessException = IsBusinessException;
        }

        /// <summary>
        /// Constructor que toma como parametros un mensaje, una excepcion y un booleano que indica si es una excepcion de logica de negocio.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="IsBusinessException"></param>
        public BLLException(string message, Exception ex, bool IsBusinessException = false) : base(message, ex)
        {
            this.IsBusinessException = IsBusinessException;
        }

        /// <summary>
        /// Constructor que toma como parametro un mensaje.
        /// </summary>
        /// <param name="Message"></param>
        public BLLException(string Message) : base(Message)
        {

        }

        /// <summary>
        /// Constructor que toma como parametros un mensaje y una excepcion interna.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="InnerException"></param>
        public BLLException(string Message, Exception InnerException) : base(Message, InnerException)
        {

        }


    }
}
