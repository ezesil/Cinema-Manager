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
    internal interface IUserRepository : IGenericRepository<User, Guid>
    {           
        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su nombre de usuario.
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        User SelectUserDataByUsername(string Username);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su direccion de correo electronico.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        User SelectUserDataByEmailAddress(string Email);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su nombre de usuario y contraseña hasheada.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        User SelectUserDataByUsernameAndPassword(string Username, string Password);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su direccion de correo electronico y contraseña hasheada.
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        User SelectUserDataByEmailAddressAndPassword(string Email, string Password);

        /// <summary>
        /// Actualiza el valor DVH almacenado en el repositorio.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DVH"></param>
        int UpdateDVH(Guid Id, int DVH);

    }
}
