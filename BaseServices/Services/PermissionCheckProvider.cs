using BaseServices.BLL;
using BaseServices.Domain.Control_de_acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de creacion, modificacion y validacion de permisos de usuario.
    /// </summary>
    public class PermissionCheckProvider
    {
        /// <summary>
        /// Comprueba si el usuario posee el permiso especificado.
        /// </summary>
        /// <param name="CodigoPermiso"></param>
        /// <returns>Retorna un booleano indicando si el usuario posee o no los permisos. Retorna siempre false si no hay usuario logeado en el sistema.</returns>
        public bool HasPermission(Permiso.PermissionType CodigoPermiso)
        {
            Permiso permiso = new Permiso(PermissionExtractor.GetDescription(CodigoPermiso));

            if (SessionServiceProvider.Current.UserIsNull)
                return false;

            return PermissionManager.Current.HasRight(permiso);
        }

        /// <summary>
        /// Comprueba si el usuario posee todos los permisos especificados.
        /// </summary>
        /// <param name="CodigoPermiso"></param>
        /// <returns>Retorna un valor booleando indicando si posee los permisos necesarios.</returns>
        public bool HasPermission(Permiso.PermissionType[] CodigoPermiso)
        {
            List<Permiso> permisos = new List<Permiso>();
            foreach (var item in CodigoPermiso)
            {
                permisos.Add(new Permiso(PermissionExtractor.GetDescription(item)));
            }


            if (SessionServiceProvider.Current.UserIsNull)
                return false;

            return PermissionManager.Current.HasRight(permisos);
        }






    }
}
