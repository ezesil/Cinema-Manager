using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para los repositorios de tipo DVV.
    /// </summary>
    internal interface IGenericDVVRepository
    {
        /// <summary>
        /// Obtiene el DVV del ID de entidad especificada.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        int SelectOne(int o);

        /// <summary>
        /// Modifica el DVV de una entidad especificada
        /// </summary>
        /// <param name="id">ID de la entidad.</param>
        /// <param name="o">Valor actualizado de DVV.</param>
        /// <returns></returns>
        void Update(int id, int o);

    }
}
