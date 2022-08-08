using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para la gestion de roles de usuario.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IPermissionRepository<T> where T: class, new()
    {
        /// <summary>
        /// Obtiene todos los roles en el sistema.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> SelectAll();

        /// <summary>
        /// Obtiene un rol a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T SelectOne(int id);

        /// <summary>
        /// Inserta un rol en el repositorio.
        /// </summary>
        /// <param name="o"></param>
        void Insert(T o);
        
        /// <summary>
        /// Actualiza un rol en el repositorio.
        /// </summary>
        /// <param name="o"></param>
        void Update(T o);

        /// <summary>
        /// Remueve un rol del repositorio.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

    }
}
