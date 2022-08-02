using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    /// <summary>
    /// Clase que representa a un ticket.
    /// </summary>
    public class Ticket : Entity
    {
        /// <summary>
        /// ID del ticket.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Fila asignada al ticket.
        /// </summary>
        public int Row { get; set; } = 0;

        /// <summary>
        /// Numero de asiento asignado al ticket.
        /// </summary>
        public int SeatNumber { get; set; } = 0;
      
        /// <summary>
        /// ID de la sesion asignada al ticket.
        /// </summary>
        public Guid? SessionId { get; set; }

        /// <summary>
        /// Nombre de la pelicula.
        /// </summary>
        public string? MovieName { get => Movie == null ? "" : Movie.Name; }

        /// <summary>
        /// Fecha programada de la sesion.
        /// </summary>
        public string SessionDate { get => Session == null ? "" : Session.Date.ToString(); }

        /// <summary>
        /// ID del usuario creador del ticket.
        /// </summary>
        public Guid? CreatorUserId { get; set; }

        /// <summary>
        /// Fecha de creacion.
        /// </summary>
        [VisibleOnGrid("text_creationtime")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Cadena que representa a la fila y asiento asignados al ticket.
        /// </summary>
        [VisibleOnGrid("text_seat")]
        public string Seat { get => $"{Row} - {SeatNumber}"; }

        /// <summary>
        /// Codigo fisico de la sala.
        /// </summary>
        [VisibleOnGrid("text_roomidentifier")]
        public string? RoomIdentifier { get; set; }

        /// <summary>
        /// Nombre completo del usuario creador.
        /// </summary>
        [VisibleOnGrid("text_creatoruser")]
        public string? UsuarioCreador { get; set; }

        /// <summary>
        /// Fecha de la sesion en formato de cadena.
        /// </summary>
        [VisibleOnGrid("text_sessiondate")]
        public string? FechaSesion { get; set; }

        /// <summary>
        /// Nombre de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_moviename")]
        public string? NombrePelicula { get; set; }

        /// <summary>
        /// Idioma de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_language")]
        public string? Idioma { get; set; }

        /// <summary>
        /// Idioma de los subtitulos de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_subtitlelanguage")]
        public string? IdiomaSubtitulado { get; set; }



        /// <summary>
        /// Objeto de la sesión. 
        /// </summary>
        public Session? Session { get; set; }

        /// <summary>
        /// Objeto de la sala.
        /// </summary>
        public Room? Room { get; set; }

        /// <summary>
        /// Objeto de la pelicula.
        /// </summary>
        public Movie? Movie { get; set; }
    }
}
