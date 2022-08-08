using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Domain
{
    /// <summary>
    /// Representa la relacion entre un rol y un permiso.
    /// </summary>
    public class RolPermisoRelation
    {
        /// <summary>
        /// ID del rol.
        /// </summary>
        public int IdRol { get; set; }
        /// <summary>
        /// ID del permiso.
        /// </summary>
        public int IdPermiso { get; set; }
    }
}
