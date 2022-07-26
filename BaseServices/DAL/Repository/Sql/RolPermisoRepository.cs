using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.Domain;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
{
    internal class RolPermisoRepository : SqlRepository<RolPermisoRelation, RolePermissionAdapter>, IGenericRepository<RolPermisoRelation, int>
    {
        private static string DeleteQuery
        { get => "DELETE * FROM [CinemaDB].[dbo].[RolesXPermisos] WHERE id_rol = @IdRol AND id_permiso = @IdPermiso"; }     
        private static string SelectAllQuery
        { get => "SELECT [id_rol], [id_permiso] FROM [CinemaDB].[dbo].[RolesXPermisos]"; }
        private static string SelectAllByRoleQuery
        { get => "SELECT [id_rol], [id_permiso] FROM [CinemaDB].[dbo].[RolesXPermisos] WHERE id_rol = @IdRol"; }
        private static string SelectQuery
        { get => "SELECT [id_rol], [id_permiso] FROM [CinemaDB].[dbo].[RolesXPermisos] WHERE id_rol = @IdRol AND id_permiso = @IdPermiso"; }
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[RolesXPermisos] (id_rol, id_permiso) values (@IdRol, @IdPermiso)"; }
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[RolesXPermisos] SET [id_permiso] = @IdPermiso WHERE id_rol = @IdRol"; }


        private static string DeleteByRoleQuery
        { get => "DELETE * FROM RolesXPermisos WHERE id_rol = @IdRol"; }
        private static string DeleteByPermissionQuery
        { get => "DELETE * FROM RolesXPermisos WHERE id_permiso = @IdPermiso"; }

        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Logger _logger = ServiceContainer.Get<Logger>();

        public RolPermisoRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public int Insert(RolPermisoRelation o)
        {
            return base.Insert(o);
        }

        public int Update(RolPermisoRelation o)
        {
            return base.Update(o);
        }

        public IEnumerable<RolPermisoRelation> GetAll()
        {
            return base.GetAll().ToList();
        }

        public IEnumerable<RolPermisoRelation> GetAll(object args = null)
        {
            return base.GetAll(args).ToList();
        }

        public RolPermisoRelation GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }


        //public int DeletePermission(int IdRol, int IdPermiso) => base.Delete(new { IdRol, IdPermiso });
        //public int DeletePermissions(List<RolPermisoRelation> permisos)
        //{
        //    permisos.ForEach(x => base.Delete(new { IdRol = x.IdRol, IdPermiso = x.IdPermiso }));
        //    return 1;              
        //}
        //public int DeletePermissions(int IdRol, List<Permiso> permisos)
        //{
        //    permisos.ForEach(x => base.Delete(new { IdRol, IdPermiso = x.Id }));
        //    return 1;
        //}
        //public int DeleteAllPermissionsFromRole(int IdRol) => base.Delete(new { IdRol });
        //public int DeleteAllPermissions(int IdPermiso) => base.Delete(new { IdPermiso });

        //public int InsertPermission(int IdRol, int IdPermiso) => base.Insert( new { IdRol, IdPermiso } );

        //public int InsertPermissions(List<RolPermisoRelation> relation)
        //{
        //    relation.ForEach(relation => base.Insert(new { IdRol = relation.IdRol, IdPermiso = relation.IdPermiso }, InsertPermissionInRole));
        //    return 1;
        //}

        //public int InsertPermissions(int IdRol, List<Permiso> permisos)
        //{
        //    permisos.ForEach(permiso => base.Insert(new { IdRol, IdPermiso = permiso.Id }, InsertPermissionInRole));
        //    return 1;
        //}      
    }
}
