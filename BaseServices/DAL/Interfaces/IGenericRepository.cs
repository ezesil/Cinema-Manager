using BaseServices.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para repositorios genericos.
    /// </summary>
    internal interface IGenericRepository<T> where T: class, new()
    {
        /// <summary>
        /// Inserta un objeto en el repositorio.
        /// </summary>
        /// <param name="o"></param>
        void Insert(T o);

        /// <summary>
        /// Actualiza un registro en el repositorio.
        /// </summary>
        /// <param name="o"></param>
        void Update(T o);

        /// <summary>
        /// Obtiene todos los registros del repositorio.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Obtiene un registro del repositorio.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        T GetOne(Guid g);

        /// <summary>
        /// Elimina un registro del repositorio.
        /// </summary>
        /// <param name="g"></param>
        void Delete(Guid g);


    }
}
