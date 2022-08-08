using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    /// <summary>
    /// Representa a una sesion de una pelicula en una sala.
    /// </summary>
    public class Session : Entity
    {
        /// <summary>
        /// ID de la sesion.
        /// </summary>
        [VisibleOnGrid("text_id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Fecha programada de la sesión.
        /// </summary>
        [VisibleOnGrid("text_date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// ID de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_movieid")]
        public Guid? MovieId { get; set; }

        /// <summary>
        /// ID de la sala.
        /// </summary>
        [VisibleOnGrid("text_roomid")]
        public Guid? RoomId { get; set; }

        /// <summary>
        /// Objeto de la pelicula.
        /// </summary>
        public Movie? Pelicula { get; set; }

        /// <summary>
        /// Objeto de la sala.
        /// </summary>
        public Room? Sala { get; set; }

        /// <summary>
        /// Devuelve la fecha programada de la sesion.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Date.ToString();
        }
    }
}
