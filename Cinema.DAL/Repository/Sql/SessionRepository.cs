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


        public SessionRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public void Insert(Session obj)
        {
            base.Insert(obj);
        }

        public void Update(Session obj)
        {
            base.Update(obj);
        }

        public IEnumerable<Session> GetAll(object paramss = null)
        {
            return base.GetAll(paramss);
        }

        public Session GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }
    }
}
