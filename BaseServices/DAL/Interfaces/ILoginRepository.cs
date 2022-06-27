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
        /// Obtiene la contraseña almacenada utilizando el nombre de usuario.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Retorna un objeto que contiene los datos.</returns>
        T GetPassUsuario(T c);

        /// <summary>
        /// Obtiene la contraseña almacenada utilizando el correo del usuario.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Retorna un objeto que contiene los datos.</returns>
        T GetPassCorreo(T c);

        /// <summary>
        /// Obtiene los datos del usuario utillizando su nombre de usuario.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Devuelve un objeto de tipo T hidratado.</returns>
        T GetUserDataUsuario(T c);

        /// <summary>
        /// Obtiene los datos del usuario utilizando su correo.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Devuelve un objeto de tipo T hidratado.</returns>
        T GetUserDataCorreo(T c);

        /// <summary>
        /// Obtiene todos los datos de integridad.
        /// </summary>
        /// <returns>Retorna un IEnumerable de T</returns>
        IEnumerable<T> SelectAllIntegrityData();

        /// <summary>
        /// Obtiene los datos de integridad de una persona.
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        T SelectIntegrityData(Guid g);

        /// <summary>
        /// Actualiza el valor DVH almacenado en el repositorio.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="DVH"></param>
        void UpdateDVH(Guid g, int DVH);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su nombre de usuario.
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        T SelectUserDataByUsername(T P);

        /// <summary>
        /// Obtiene los datos personales del usuario utilizando su direccion de correo electronico.
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        T SelectUserDataByEmailAddress(T P);
    }
}
