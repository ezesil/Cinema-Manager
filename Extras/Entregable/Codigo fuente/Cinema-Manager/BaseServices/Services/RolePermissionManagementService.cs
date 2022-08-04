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
    /// <summary>
    /// Servicio de manejo de relaciones entre roles y permisos.
    /// </summary>
    public class RolePermissionManagementService
    {
        //IGenericRepository<Rol, int> _rolrepo = DAL.Factory.FactoryDAL.RolRepository;
        //IGenericRepository<Permiso, int> _permrepo = DAL.Factory.FactoryDAL.PermisoRepository;
        //IGenericRepository<RolPermisoRelation, int> _rolpermrepo = DAL.Factory.FactoryDAL.RolPermisoRepository;

        
        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public RolePermissionManagementService()
        {

        }

        /// <summary>
        /// Obtiene todos los permisos por rol.
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ObtenerListaDePermisos()
        {
            return PermissionBLL.Current.ObtenerListaDePermisos();
        }

        /// <summary>
        /// Tiene todos los permisos por rol a través del roll.
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
        /// Obtine todos los roles.
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
        /// Obtiene todas las relaciones.
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
        /// <param name="R"></param>
        public void EliminarRolPermisoRelation(RolPermisoRelation R)
        {
            RolePermissionBLL.Current.EliminarRolPermisoRelation(R);
        }

    }
}
