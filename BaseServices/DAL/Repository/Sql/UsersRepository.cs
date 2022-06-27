using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Repository.Sql;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
{
    public class UsersRepository : SqlRepository<User, UserAdapter>, IGenericRepository<User>
    {
        private static string DeleteQuery 
        { get => "DELETE * FROM USERS WHERE guid_usuario = @Usuario"; }
        private static string SelectAllQuery 
        { get => "SELECT [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario]"; }
        private static string SelectQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE guid_usuario = @Id"; }
        private static string InsertQuery 
        { get => "INSERT INTO Users ([guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario])" +
                " values (@Id, @Username, @Contraseña, @Email, @Habilitado, @DVH, @Name, @DNI)"; }
        private static string UpdateQuery
        {
            get => "UPDATE Users SET [guid_usuario] = @Id, [nombredeusuario] = @Username, [contraseña] = @Contraseña, [emailprincipal] = @Email, [habilitado] = @Habilitado, [DVH] = @DVH, [nombre_completo] = @Name, [dni_usuario] = @DNI";
        }

        public UsersRepository() 
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {    
        }

        // TODO: Implementar clase User
        public void Insert(User obj)
        {
            base.Insert(new SqlParameter[] 
            { 
                new SqlParameter("guid", obj.Id) 
            });
        }


        public void Update(User obj) => base.Update(new SqlParameter[] { new SqlParameter("guid", obj.Id) });

        public IEnumerable<User> GetAll() => base.GetAll();

        public User GetOne(Guid guid) => base.GetOne(new SqlParameter[] { new SqlParameter("guid", guid) });

        public void Delete(Guid guid) => base.Delete(new SqlParameter[] { new SqlParameter("guid", guid) });

    }
}
