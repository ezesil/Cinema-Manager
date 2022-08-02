using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz generica para los adaptadores de datos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericAdapter<T>
    {
        /// <summary>
        /// Metodo generico para adaptadores.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        T Adapt(object[] values);
    }
}
