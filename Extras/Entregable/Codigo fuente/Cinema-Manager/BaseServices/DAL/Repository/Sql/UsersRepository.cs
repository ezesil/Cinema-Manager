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
    /// <summary>
    /// Repositorio de usuarios.
    /// </summary>
    public class UsersRepository : SqlRepository<User, UserAdapter>, IGenericRepository<User, Guid>, IUserRepository
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
        private static string UpdateDVHQuery
        { get => "UPDATE Usuario SET [DVH] = @DVH where guid_usuario = @Id"; }
        private static string SelectWhereUserQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [nombredeusuario] = @Username"; }
        private static string SelectWhereEmailQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [emailprincipal] = @Email"; }
        private static string SelectWhereUserAndPassQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [nombredeusuario] = @Username and [contraseña] = @Password"; }
        private static string SelectWhereEmailAndPassQuery
        { get => "SELECT TOP(1) [guid_usuario], [nombredeusuario], [contraseña], [emailprincipal], [habilitado], [DVH], [nombre_completo], [dni_usuario] FROM [CinemaDB].[dbo].[Usuario] WHERE [emailprincipal] = @Email and [contraseña] = @Password"; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public UsersRepository() 
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {    
        }

        /// <summary>
        /// Obtiene un usuario.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public User GetOne(Guid guid) => base.GetOne(new { Id = guid });

        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll() => base.GetAll();

        /// <summary>
        /// Obtiene todos los usuarios. Puede recibir un objeto anonimo con parametros. 
        /// Las propiedades deben tener los mismos nombres de la query.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAll(object args = null) => base.GetAll(args);

        /// <summary>
        /// Inserta un usuario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Insert(User obj) => base.Insert(obj);

        /// <summary>
        /// Actualiza un usuario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update(User obj) => base.Update(obj);

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(Guid Id) => base.Delete(new { Id });

        /// <summary>
        /// Actualiza el digito verificador horizontal de un usuario.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DVH"></param>
        /// <returns></returns>
        public int UpdateDVH(Guid Id, int DVH) => base.Update(new { Id, DVH }, UpdateDVHQuery);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public User SelectUserDataByUsername(string Username) => base.GetOne(SelectWhereUserQuery, new { Username });

        /// <summary>
        /// Obtiene un usuario por su direccion de email.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public User SelectUserDataByEmailAddress(string Email) => base.GetOne(SelectWhereEmailQuery, new { Email });

        /// <summary>
        /// Obtiene un usuario por su usuario y contraseña.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User SelectUserDataByUsernameAndPassword(string Username, string Password) => base.GetOne(SelectWhereUserAndPassQuery, new { Username, Password });

        /// <summary>
        /// Obtiene un usuario por su email y contraseña.
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User SelectUserDataByEmailAddressAndPassword(string Email, string Password) => base.GetOne(SelectWhereEmailAndPassQuery, new { Email, Password });
       
    }
}
