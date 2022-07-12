using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.UI.Extensions
{  
    internal static class GridViewAdapters
    {
        public static DataTable Adapt(IEnumerable<Movie> movies)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Lenguaje");
            dt.Columns.Add("Subtitulos");
            dt.Columns.Add("Activo");
            dt.Columns.Add("Duracion");

            foreach(var movie in movies)
            {
                dt.Rows.Add(new object[] { movie.Id, movie.Name, movie.Language, movie.SubtitleLanguage, movie.IsActive, movie.Duration });
            }

            return dt;
        }

        public static DataTable Adapt(IEnumerable<Room> rooms)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Pantalla grande");
            dt.Columns.Add("3D");
            dt.Columns.Add("Activo");

            foreach (var room in rooms)
            {
                dt.Rows.Add(new object[] { room.Id, room.Identifier, room.HasBigScreen, room.Has3D, room.IsActive });
            }

            return dt;
        }

        public static DataTable Adapt(IEnumerable<Session> sessions)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Pelicula");
            dt.Columns.Add("Sala");

            foreach (var session in sessions)
            {
                dt.Rows.Add(new object[] { session.Id, session.Date, session.MovieId, session.RoomId });
            }

            return dt;
        }

        public static DataTable Adapt(IEnumerable<Ticket> tickets)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Fecha de creacion");
            dt.Columns.Add("Fila");
            dt.Columns.Add("Asiento");
            dt.Columns.Add("Sesion");
            dt.Columns.Add("Usuario creador");

            foreach (var ticket in tickets)
            {
                dt.Rows.Add(new object[] { ticket.Id, ticket.CreationTime, ticket.Row, ticket.Seat, ticket.SessionId, ticket.CreatorUserId });
            }

            return dt;
        }

    }
}
