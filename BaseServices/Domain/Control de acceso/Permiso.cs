using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain.Control_de_acceso
{
    /// <summary>
    /// Representa un permiso utilizado para control de acceso a formularios.
    /// </summary>
    /// <summary>
    /// Tipos de permisos.
    /// </summary>
    public enum Permission
    {     
        /// <summary>
        /// Permisos de administrador del sistema.
        /// </summary>
        [Description("Cinema.Administrator")]
        Administrator,

        /// <summary>
        /// Permisos de administrador del sistema.
        /// </summary>
        [Description("Cinema.Manager")]
        Manager,

        /// <summary>
        /// Permisos de administrador del sistema.
        /// </summary>
        [Description("Cinema.Receptionist")]
        Receptionist,
    }
    public class Permiso
    {


        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Permiso()
        {

        }

        /// <summary>
        /// Constructor que recibe un codigo de permiso como parametro.
        /// </summary>
        /// <param name="permission"></param>
        public Permiso(string permission)
        {
            Codigo = permission;
        }

        /// <summary>
        /// Representa un codigo unico de permiso
        /// </summary>
        /// 

        public string Codigo { get; private set; }





    }
}
