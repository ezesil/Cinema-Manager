using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para los repositorios de bitacoras genericos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IGenericLogRepository<T>
    {
        /// <summary>
        /// Inserta una bitacora para almacenarla.
        /// </summary>
        /// <param name="log">Bitacora.</param>
        void Insert(T log);

        /// <summary>
        /// Selecciona todas las bitacoras existentes y las retorna en un listado.
        /// </summary>
        /// <returns>Retorna un IEnumerable de bitacoras.</returns>
        IEnumerable<T> SelectAll();




    }
}
