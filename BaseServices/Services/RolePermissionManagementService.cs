using BaseServices.BLL;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    public class RolePermissionManagementService
    {
        //IGenericRepository<Rol, int> _rolrepo = DAL.Factory.FactoryDAL.RolRepository;
        //IGenericRepository<Permiso, int> _permrepo = DAL.Factory.FactoryDAL.PermisoRepository;
        //IGenericRepository<RolPermisoRelation, int> _rolpermrepo = DAL.Factory.FactoryDAL.RolPermisoRepository;

        

        public RolePermissionManagementService()
        {

        }

        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ObtenerListaDePermisos()
        {
            return PermissionBLL.Current.ObtenerListaDePermisos();
        }

        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ObtenerListaDePermisos(Rol r)
        {
            return PermissionBLL.Current.ObtenerListaDePermisos(r);
        }

        /// <summary>
        /// Permite modificar el registro de un Rol.
        /// </summary>
        public void ModificarPermiso(Permiso R)
        {
            PermissionBLL.Current.ModificarPermiso(R);
        }

        // select all, select one, insert, delete, update
        /// <summary>
        /// Obtiene la informacion de un rol a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        public Permiso ObtenerPermiso(int id)
        {
            return PermissionBLL.Current.ObtenerPermiso(id);
        }

        /// <summary>
        /// Permite crear un rol del sistema.
        /// </summary>
        /// <param name="R"></param>
        public void CrearPermiso(Permiso R)
        {
            PermissionBLL.Current.CrearPermiso(R);
        }

        /// <summary>
        /// Permite eliminar un rol del sistema.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarPermiso(int id)
        {
            PermissionBLL.Current.EliminarPermiso(id);
        }

        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<Rol> ObtenerListaDeRoles()
        {
            return RoleBLL.Current.ObtenerListaDeRoles();
        }

        /// <summary>
        /// Permite modificar el registro de un Rol.
        /// </summary>
        public void ModificarRol(Rol R)
        {
            RoleBLL.Current.ModificarRol(R);
        }

        // select all, select one, insert, delete, update
        /// <summary>
        /// Obtiene la informacion de un rol a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        public Rol ObtenerRol(int id)
        {
            return RoleBLL.Current.ObtenerRol(id);
        }

        /// <summary>
        /// Permite crear un rol del sistema.
        /// </summary>
        /// <param name="R"></param>
        public void CrearRol(Rol R)
        {
            RoleBLL.Current.CrearRol(R);
        }

        /// <summary>
        /// Permite eliminar un rol del sistema.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarRol(int id)
        {
            RoleBLL.Current.EliminarRol(id);
        }

        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<RolPermisoRelation> ObtenerListaDeRelaciones()
        {
            return RolePermissionBLL.Current.ObtenerListaDeRelaciones();
        }

        /// <summary>
        /// Permite modificar el registro de un Rol.
        /// </summary>
        public void ModificarRolPermisoRelation(RolPermisoRelation R)
        {
            RolePermissionBLL.Current.ModificarRolPermisoRelation(R);
        }

        // select all, select one, insert, delete, update
        /// <summary>
        /// Obtiene la informacion de una relacion rol-permiso a partir de su ID de rol.
        /// </summary>
        /// <param name="id"></param>
        public RolPermisoRelation ObtenerRolPermisoRelation(int id)
        {
            return RolePermissionBLL.Current.ObtenerRolPermisoRelation(id);
        }

        /// <summary>
        /// Permite crear una relacion rol-permiso del sistema.
        /// </summary>
        /// <param name="R"></param>
        public void CrearRolPermisoRelation(RolPermisoRelation R)
        {
            RolePermissionBLL.Current.CrearRolPermisoRelation(R);
        }

        /// <summary>
        /// Permite eliminar una relacion rol-permiso del sistema.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarRolPermisoRelation(RolPermisoRelation R)
        {
            RolePermissionBLL.Current.EliminarRolPermisoRelation(R);
        }

    }
}
