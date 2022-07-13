using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql
{
    public class TicketsRepository : SqlRepository<Ticket, TicketAdapter>, IGenericRepository<Ticket>
    {
        private static string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Tickets] where [guid_ticket] = @Id"; }
        private static string SelectAllQuery
        { get => "SELECT [guid_ticket],[fecha_creacion],[fila],[asiento],[guid_sesion],[guid_usuario_creador] FROM [CinemaDB].[dbo].[Tickets] WHERE @Filter = 1 OR [fecha_creacion] BETWEEN @FechaDesde AND @FechaHasta"; }
        private static string SelectQuery
        { get => "SELECT [guid_ticket],[fecha_creacion],[fila],[asiento],[guid_sesion],[guid_usuario_creador] FROM [CinemaDB].[dbo].[Tickets] where [guid_ticket] = @Id"; }
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Salas] ([fecha_creacion],[fila],[asiento],[guid_sesion],[guid_usuario_creador]) values (@CreationTime, @Row, @Seat, @SesionId, @CreatorUserId)"; }
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Salas] SET [fecha_creacion] = @CreationTime,[fila] = @Row,[asiento] = @Seat,[guid_sesion] = @SesionId,[guid_usuario_creador] = @CreatorUserId where [guid_pelicula] = @Id"; }


        public TicketsRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public void Insert(Ticket obj)
        {
            base.Insert(obj);
        }

        public void Update(Ticket obj)
        {
            base.Update(obj);
        }

        public IEnumerable<Ticket> GetAll(object paramss)
        {
            return base.GetAll(paramss);
        }

        public Ticket GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }
    }
}
