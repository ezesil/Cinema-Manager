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
    public class UsersRepository : SqlRepository<User, UserAdapter>, IUserRepository<User>
    {
        private static string DeleteQuery 
        { get => "DELETE * FROM USERS WHERE guid_usuario = @Usuario"; }
        private static string SelectAllQuery 
        { get => "SELECT [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario]"; }
        private static string SelectQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE guid_usuario = @Id"; }
        private static string InsertQuery 
        { get => "INSERT INTO Usuario ([guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario]) values (@Id, @Username, @Password, @Email, @Enabled, @DVH, @FullName, @DNI)"; }
        private static string UpdateQuery
        { get => "UPDATE Usuario SET [guid_usuario] = @Id, [nombredeusuario] = @Username, [contraseña] = @HashedPassword, [emailprincipal] = @Email, [habilitado] = @Enabled, [DVH] = @DVH, [nombre_completo] = @FullName, [dni_usuario] = @DNI"; }
        private static string SelectWhereUserQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [nombredeusuario] = @Username"; }
        private static string SelectWhereEmailQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [emailprincipal] = @Email"; }
        private static string SelectWhereUserAndPassQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [nombredeusuario] = @Username and [contraseña] = @Password"; }
        private static string SelectWhereEmailAndPassQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [emailprincipal] = @Email and [contraseña] = @Password"; }

        public UsersRepository() 
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {    
        }

        public User Select(Guid guid) => base.GetOne(new { Id = guid });

        public IEnumerable<User> SelectAll() => base.GetAll();

        public int Insert(User obj) => base.Insert(obj);

        public int Update(User obj) => base.Update(obj);

        public int Delete(Guid Id) => base.Delete(new { Id });

        public int UpdateDVH(Guid Id, int DVH) => base.Update(new { Id, DVH });

        public User SelectUserDataByUsername(string Username) => base.GetOne(SelectWhereUserQuery, new { Username });

        public User SelectUserDataByEmailAddress(string Email) => base.GetOne(SelectWhereEmailQuery, new { Email });

        public User SelectUserDataByUsernameAndPassword(string Username, string Password) => base.GetOne(SelectWhereUserAndPassQuery, new { Username, Password });

        public User SelectUserDataByEmailAddressAndPassword(string Email, string Password) => base.GetOne(SelectWhereEmailAndPassQuery, new { Email, Password });
       
    }
}
