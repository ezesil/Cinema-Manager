using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Exceptions
{
    /// <summary>
    /// Representa errores de lenguajes no cargados. 
    /// </summary>
    public class LanguageNotLoadedException : Exception
    {
        /// <summary>
        /// constructor que toma otra excepción como mensaje.
        /// </summary>
        /// <param name="ex"></param>
        public LanguageNotLoadedException(Exception ex) : base(ex.Message)
        {

        }
    }
}
