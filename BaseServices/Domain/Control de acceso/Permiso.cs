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
    public class Permiso
    {

        /// <summary>
        /// Tipos de permisos.
        /// </summary>
        public enum PermissionType
        {
            /// <summary>
            /// Permisos de tipo Cliente.
            /// </summary>
            [Description("grupo_cliente")]
            Cliente,

            /// <summary>
            /// Permisos de tipo Anunciante.
            /// </summary>
            [Description("grupo_anunciante")]
            Anunciante,

            /// <summary>
            /// Permisos de tipo administrador de publicidad-
            /// </summary>
            [Description("grupo_adminpub")]
            AdminPub,

            /// <summary>
            /// Permisos de administrador del sistema.
            /// </summary>
            [Description("grupo_admin")]
            Administrator
        }

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
