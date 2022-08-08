using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    /// <summary>
    /// Clase que representa una pelicula
    /// </summary>
    public class Movie : Entity
    {
        /// <summary>
        /// ID de la pelicula
        /// </summary>
        [VisibleOnGrid("text_movieid")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Nombre de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_moviename")]
        public string? Name { get; set; }

        /// <summary>
        /// Lenguaje hablado de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_movielanguage")]
        public string? Language { get; set; }

        /// <summary>
        /// Lenguaje subtitulado de la pelicula.
        /// </summary>
        [VisibleOnGrid("text_subtitlelanguage")]
        public string? SubtitleLanguage { get; set; }

        /// <summary>
        /// Indica si la pelicula está activa. Si la pelicula está inactiva, no se mostrará en los buscadores
        /// excepto en el buscador de peliculas.
        /// </summary>
        [VisibleOnGrid("text_isactive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Duracion de la pelicula en minutos.
        /// </summary>
        [VisibleOnGrid("text_duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Obtiene un string que representa al objeto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}, {Language}, {(SubtitleLanguage == null || SubtitleLanguage == "" ? "Sin subtitulos" : SubtitleLanguage )}";
        }

    }
}
