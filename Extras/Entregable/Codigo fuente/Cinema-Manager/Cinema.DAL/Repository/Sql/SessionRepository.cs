using BaseServices.Services;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql
{
    /// <summary>
    /// Repositorio de sesiones.
    /// </summary>
    public class SessionRepository : SqlRepository<Session, SessionAdapter>, IGenericRepository<Session>
    {
        private static string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Sesion] where [guid_sesion] = @Id"; }
        private static string SelectAllQuery
        { get => "SELECT [guid_sesion],[fecha],[guid_pelicula],[guid_sala] FROM [CinemaDB].[dbo].[Sesiones]"; }
        private static string SelectQuery
        { get => "SELECT [guid_sesion],[fecha],[guid_pelicula],[guid_sala] FROM [CinemaDB].[dbo].[Sesiones] where [guid_sesion] = @Id"; } 
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Sesiones] ([guid_sesion],[fecha],[guid_pelicula],[guid_sala]) values (@Id, @Date, @MovieId, @RoomId)";}
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Sesiones] SET [fecha] = @Date,[guid_pelicula] = @MovieId,[guid_sala] = @RoomId where [guid_sesion] = @Id"; }

        ExceptionHandler? _exhandler { get; set; }
        Logger? _logger { get; set; }

        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public SessionRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
            _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
            _logger = ServiceContainer.Instance.GetService<Logger>();
        }

        /// <summary>
        /// Inserta una nueva sesion.
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(Session obj)
        {
            base.Insert(obj);
        }

        /// <summary>
        /// Actualiza una sesion.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Session obj)
        {
            base.Update(obj);
        }

        /// <summary>
        /// Obtiene todas las sesiones. Los parametros ingresados serán ignorados.
        /// </summary>
        /// <param name="paramss"></param>
        /// <returns></returns>
        public IEnumerable<Session> GetAll(object paramss = null)
        {
            return base.GetAll(null);
        }

        /// <summary>
        /// Obtiene una sesion.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Session GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        /// <summary>
        /// Borra una session.
        /// </summary>
        /// <param name="guid"></param>
        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }
    }
}
