using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices.Exceptions
{
    /// <summary>
    /// Representa errores ocurridos durante el acceso a datos.
    /// </summary>
    public class DALException : Exception
    {

        /// <summary>
        /// Constructor que toma como parametro otra excepcion.
        /// </summary>
        /// <param name="ex"></param>
        public DALException(Exception ex) : base(ex.Message, ex)
        {

        }

        /// <summary>
        /// Constructor que toma como parametro un mensaje.
        /// </summary>
        /// <param name="Message"></param>
        public DALException(string Message) : base(Message)
        {

        }


    }
}
