using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.Domain;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
{
    internal class RolRepository : SqlRepository<Rol, RolAdapter>, IGenericRepository<Rol, int>
    {
        #region Statements
        private static string InsertQuery
        {
            get => "INSERT INTO [dbo].[Roles] (nombre_rol) VALUES (@Nombre)";
        }

        private static string UpdateQuery
        {
            get => "UPDATE [dbo].[Roles] SET nombre_rol = @Nombre WHERE id_rol = @Id";
        }

        private static string DeleteQuery
        {
            get => "DELETE FROM [dbo].[Roles] WHERE id_rol = @Id";
        }

        private static string SelectQuery
        {
            get => "SELECT id_rol, nombre_rol FROM [dbo].[Roles] WHERE id_rol = @Id";
        }

        private static string SelectAllQuery
        {
            get => "SELECT id_rol, nombre_rol FROM [dbo].[Roles]";
        }

        private static string SelectAllByUserQuery
        {
            get => 
                "SELECT rr.id_rol, rr.nombre_rol FROM [dbo].[Roles] rr JOIN [dbo].[UsuariosXRoles] ur ON ur.guid_usuario = @UserId AND ur.id_rol = rr.id_rol";
        }
        #endregion

        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Logger _logger = ServiceContainer.Get<Logger>();

        public RolRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public int Insert(Rol obj) => base.Insert(obj);
        public int Update(Rol obj) => base.Update(obj);
        public IEnumerable<Rol> GetAll() => base.GetAll();
        public IEnumerable<Rol> GetAll(object args = null) => base.GetAll(args, SelectAllByUserQuery);
        public Rol GetOne(int Id) => base.GetOne(new { Id });
        public int Delete(int Id) => base.Delete(new { Id });
    }
}
