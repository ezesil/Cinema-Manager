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
    internal class PermisoRepository : SqlRepository<Permiso, PermisoAdapter>, IGenericRepository<Permiso, int>
    {
        #region Statements
        private static string InsertQuery
        {
            get => "INSERT INTO [dbo].[Permisos] (id_permiso, codigo_permiso) VALUES (@Id, @Nombre)";
        }

        private static string UpdateQuery
        {
            get => "UPDATE [dbo].[Permisos] SET nombre_rol = @codigo_permiso WHERE id_permiso = @Id";
        }

        private static string DeleteQuery
        {
            get => "DELETE FROM [dbo].[Permisos] WHERE id_permiso = @Id";
        }

        private static string SelectQuery
        {
            get => "SELECT id_permiso, codigo_permiso FROM [dbo].[Permisos] WHERE id_permiso = @Id";
        }

        private static string SelectAllQuery
        {
            get => "SELECT id_permiso, codigo_permiso FROM [dbo].[Permisos]";
        }

        private static string SelectAllByRoleQuery
        {
            get => 
                "select per.id_permiso, per.codigo_permiso from Permisos per " +               
                "join RolesXPermisos rp on per.id_permiso = rp.id_permiso " +
                "where rp.id_rol = @IdRol";
        }
        #endregion

        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Logger _logger = ServiceContainer.Get<Logger>();

        public PermisoRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public int Insert(Permiso obj) => base.Insert(obj);
        public int Update(Permiso obj) => base.Update(obj);
        public IEnumerable<Permiso> GetAll() => base.GetAll();
        public IEnumerable<Permiso> GetAll(object args = null) => base.GetAll(args, SelectAllByRoleQuery);
        public Permiso GetOne(int Id) => base.GetOne(new { Id });
        public int Delete(int Id) => base.Delete(new { Id });
    }
}
