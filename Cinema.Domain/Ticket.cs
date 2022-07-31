using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Ticket : Entity
    {
        public Guid? Id { get; set; }

        public int Row { get; set; } = 0;

        public int SeatNumber { get; set; } = 0;
      
        public Guid? SessionId { get; set; }

        public Guid? CreatorUserId { get; set; }

        public string MovieName { get => Movie == null ? "" : Movie.Name; }

        public string SessionDate { get => Session == null ? "" : Session.Date.ToString(); }


        [VisibleOnGrid("text_creationtime")]
        public DateTime? CreationTime { get; set; }

        [VisibleOnGrid("text_seat")]
        public string Seat { get => $"{Row} - {SeatNumber}"; }

        [VisibleOnGrid("text_roomidentifier")]
        public string RoomIdentifier { get; set; }

        [VisibleOnGrid("text_creatoruser")]
        public string UsuarioCreador { get; set; }

        [VisibleOnGrid("text_sessiondate")]
        public string FechaSesion { get; set; }

        [VisibleOnGrid("text_moviename")]
        public string NombrePelicula { get; set; }

        [VisibleOnGrid("text_language")]
        public string Idioma { get; set; }

        [VisibleOnGrid("text_subtitlelanguage")]
        public string IdiomaSubtitulado { get; set; }




        public Session Session { get; set; }

        public Room Room { get; set; }

        public Movie Movie { get; set; }
    }
}
