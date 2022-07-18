using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    /// <summary>
    /// Interfaz para los repositorios de cuentas de usuario.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUserRepository<T> where T: class, new()
    {      
        /// <summary>
        /// Obtiene los datos personales del usuario por su ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Select(Guid Id);

        /// <summary>
        /// Obtiene los datos personales del usuario por su ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<T> SelectAll();

        /// <summary>
        /// Inserta un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Insert(User user);

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(User user);

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(Guid Id);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su nombre de usuario.
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        T SelectUserDataByUsername(string Username);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su direccion de correo electronico.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        T SelectUserDataByEmailAddress(string Email);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su nombre de usuario y contraseña hasheada.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        T SelectUserDataByUsernameAndPassword(string Username, string Password);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su direccion de correo electronico y contraseña hasheada.
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        T SelectUserDataByEmailAddressAndPassword(string Email, string Password);

        /// <summary>
        /// Actualiza el valor DVH almacenado en el repositorio.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DVH"></param>
        int UpdateDVH(Guid Id, int DVH);

    }
}
