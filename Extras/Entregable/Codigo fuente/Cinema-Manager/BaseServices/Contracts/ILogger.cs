using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.Domain;

namespace BaseServices.Contracts
{
    /// <summary>
    /// Interfaz para los repositorios de bitacora.
    /// </summary>
    internal interface ILogger
    {
        /// <summary>
        /// Metodo para el almacenamiento de bitacoras.
        /// </summary>
        /// <param name="L">Bitacora.</param>
        void Store(Log L);

        /// <summary>
        /// Metodo para la obtencion de todas las bitacoras en un listado.
        /// </summary>
        /// <returns>Retorna un listado de bicatoras.</returns>
        List<Log> GetAll();
    }

}
