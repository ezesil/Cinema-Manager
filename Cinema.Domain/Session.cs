using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Session : Entity
    {
        [VisibleOnGrid("text_id")]
        public Guid? Id { get; set; }

        [VisibleOnGrid("text_date")]
        public DateTime Date { get; set; }

        [VisibleOnGrid("text_movieid")]
        public Guid? MovieId { get; set; }

        [VisibleOnGrid("text_roomid")]
        public Guid? RoomId { get; set; }

        public Movie Pelicula { get; set; }
        public Room Sala { get; set; }

        public override string ToString()
        {
            return Date.ToString();
        }
    }
}
