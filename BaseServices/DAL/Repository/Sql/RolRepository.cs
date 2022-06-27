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
    internal class RolRepository : SqlRepository<Rol, RolAdapter>, IGenericRepository<Rol>
    {
        #region Statements
        private static string InsertQuery
        {
            get => "INSERT INTO [dbo].[Rol] (id_rol, permisos, nombre_rol) VALUES (@id_rol, @permisos, @nombre_rol)";
        }

        private static string UpdateQuery
        {
            get => "UPDATE [dbo].[Rol] SET permisos = @permisos, nombre_rol = @nombre_rol WHERE id_rol = @id_rol";
        }

        private static string DeleteQuery
        {
            get => "DELETE FROM [dbo].[Rol] WHERE id_rol = @id_rol";
        }

        private static string SelectQuery
        {
            get => "SELECT id_rol, permisos, nombre_rol FROM [dbo].[Rol] WHERE id_rol = @id_rol";
        }

        private static string SelectAllQuery
        {
            get => "SELECT id_rol, nombre_rol, permisos FROM [dbo].[Rol]";
        }
        #endregion

        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Logger _logger = ServiceContainer.Get<Logger>();

        public RolRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public Rol GetOne(Guid g)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid g)
        {
            throw new NotImplementedException();
        }

        public void Insert(Rol o)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol o)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
