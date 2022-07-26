using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    internal interface IRolePermissionRepository
    {
        int InsertPermission(int IdRol, int IdPermiso);
        int InsertPermissions(int IdRol, List<Permiso> permisos);
        int InsertPermissions(List<RolPermisoRelation> permisos);

        int DeletePermission(int IdRol, int IdPermiso);
        int DeletePermissions(int IdRol, List<Permiso> permisos);
        int DeletePermissions(List<RolPermisoRelation> relation);
        int DeleteAllPermissionsFromRole(int IdRol);
        int DeleteAllPermissions(int IdPermiso);




    }
}
