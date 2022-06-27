using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain.Exceptions
{
    /// <summary>
    /// Representa un error de credenciales incorrectas.
    /// </summary>
    public class IncorrectCredentialsException : BLLException
    {

        /// <summary>
        /// Constructor que toma otra excepcion como parametro.
        /// </summary>
        /// <param name="ex"></param>
        public IncorrectCredentialsException(Exception ex) : base(ex.Message, ex)
        {

        }

        /// <summary>
        /// Constructor que toma un mensaje como parametro.
        /// </summary>
        /// <param name="message"></param>
        public IncorrectCredentialsException(string message) : base(message)
        {

        }
    }
}
