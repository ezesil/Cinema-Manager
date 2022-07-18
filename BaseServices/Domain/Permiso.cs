using BaseServices.Services.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    /// <summary>
    /// Representa un permiso utilizado para control de acceso a formularios.
    /// </summary>
    /// <summary>
    /// Tipos de permisos.
    /// </summary>
    public enum PermissionType
    {

        None,

        /// <summary>
        /// Permisos de administrador del sistema.
        /// </summary>
        [Description("Cinema.Administrator")]
        Administrator,

        /// <summary>
        /// Permisos del gerente del sistema.
        /// </summary>
        [Description("Cinema.Manager")]
        Manager,

        /// <summary>
        /// Permisos del recepcionista del sistema.
        /// </summary>
        [Description("Cinema.Receptionist")]
        Receptionist,
    }
    public class Permiso
    {
        Dictionary<string, PermissionType> permissions;

        /// <summary>
        /// Constructor que recibe un codigo de permiso como parametro.
        /// </summary>
        /// <param name="permission"></param>
        public Permiso(PermissionType permission)
        {
            SetupPermissions();
            Type = permission;
            Codigo = permission.ToTextCode();
        }

        /// <summary>
        /// Constructor que recibe un codigo de permiso como parametro.
        /// </summary>
        /// <param name="permission"></param>
        public Permiso(string permission)
        {
            SetupPermissions();
            Type = permissions[permission];
            Codigo = permission;
        }

        /// <summary>
        /// Representa un codigo unico de permiso
        /// </summary>
        public PermissionType Type { get; private set; }

        /// <summary>
        /// Representa un codigo unico interno de permiso
        /// </summary>
        public string Codigo { get; private set; }

        private void SetupPermissions()
        {
            foreach (PermissionType type in Enum.GetValues(typeof(PermissionType)))
            {
                permissions = new Dictionary<string, PermissionType>();
                permissions.Add(type.ToTextCode(), type);
            }

        }

        /// <summary>
        /// Permite obtener un permiso a partir de su codigo de texto.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PermissionType GetPermissionType(string code)
        {
            return permissions[code];
        }
    }
}
