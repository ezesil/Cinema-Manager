using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para repositorios de tipo "Legacy". El estado actual de esta interfaz es obsoleto. Use los repositorios no-legacy en lugar de este.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IGenericLegacyRepository<T> where T : class, new()
    {
        /// <summary>
        /// Selecciona todas las bitacoras como cadenas de string.
        /// </summary>
        /// <returns>Retorna un IEnumerable de strings.</returns>
        IEnumerable<string> SelectAll();

        /// <summary>
        /// Inserta una bitacora.
        /// </summary>
        /// <param name="Message">Mensaje de error de tipo string.</param>
        void Insert(string Message);





    }
}
