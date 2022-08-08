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
    /// Repositorio de tickets.
    /// </summary>
    public class TicketsRepository : SqlRepository<Ticket, TicketAdapter>, IGenericRepository<Ticket>
    {
        private static string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Tickets] where [guid_ticket] = @Id"; }
        private static string SelectAllQuery
        {
            get => "SELECT " +
                "tk.[guid_ticket], " +
                "tk.[fecha_creacion], " +
                "tk.[fila], " +
                "tk.[asiento], " +
                "tk.[guid_sesion], " +
                "tk.[guid_usuario_creador], " +
                "usr.nombre_completo, " +
                "ss.fecha, " +
                "pl.nombre, " +
                "pl.idioma, " +
                "pl.idioma_subtitulado " +
                "FROM [CinemaDB].[dbo].[Tickets] tk " +
                "JOIN [CinemaDB].[dbo].[Usuario] usr on tk.guid_usuario_creador = usr.guid_usuario " +
                "JOIN [CinemaDB].[dbo].[Sesiones] ss on ss.guid_sesion = tk.guid_sesion " +
                "JOIN [CinemaDB].[dbo].[Peliculas] pl on pl.guid_pelicula = ss.guid_pelicula " +
                "WHERE (@Filter = 1 AND [fecha_creacion] BETWEEN @FechaDesde AND @FechaHasta)";
        }


        private static string SelectQuery
        { get => "SELECT [guid_ticket],[fecha_creacion],[fila],[asiento],[guid_sesion],[guid_usuario_creador] FROM [CinemaDB].[dbo].[Tickets] where [guid_ticket] = @Id"; }
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Tickets] ([fecha_creacion],[fila],[asiento],[guid_sesion],[guid_usuario_creador]) values (@CreationTime, @Row, @SeatNumber, @SessionId, @CreatorUserId)"; }
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Tickets] SET [fecha_creacion] = @CreationTime,[fila] = @Row,[asiento] = @Seat,[guid_sesion] = @SessionId,[guid_usuario_creador] = @CreatorUserId where [guid_pelicula] = @Id"; }

        ExceptionHandler? _exhandler { get; set; }
        Logger? _logger { get; set; }

        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public TicketsRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
            _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
            _logger = ServiceContainer.Instance.GetService<Logger>();
        }

        /// <summary>
        /// Inserta un ticket.
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(Ticket obj)
        {
            base.Insert(obj);
        }

        /// <summary>
        /// Actualiza un ticket.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Ticket obj)
        {
            base.Update(obj);
        }

        /// <summary>
        /// Obtiene todos los tickets. Puede recibir un objeto anonimo que incluya los siguientes parametros
        /// para filtrar la busqueda: FechaDesde y FechaHasta.
        /// </summary>
        /// <param name="paramss"></param>
        /// <returns></returns>
        public IEnumerable<Ticket> GetAll(object paramss = null)
        {
            if (paramss == null)
                paramss = new { FechaDesde = DateTime.Parse("01/01/2000 00:00"), FechaHasta = DateTime.MaxValue };

            return base.GetAll(paramss);
        }

        /// <summary>
        /// Obtiene un ticket.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Ticket GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        /// <summary>
        /// Elimina un ticket.
        /// </summary>
        /// <param name="guid"></param>
        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }
    }
}
