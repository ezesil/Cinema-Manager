using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Movie : Entity
    {
        [VisibleOnGrid("text_movieid")]
        public Guid? Id { get; set; }

        [VisibleOnGrid("text_moviename")]
        public string Name { get; set; }

        [VisibleOnGrid("text_movielanguage")]
        public string Language { get; set; }

        [VisibleOnGrid("text_subtitlelanguage")]
        public string SubtitleLanguage { get; set; }

        [VisibleOnGrid("text_isactive")]
        public bool IsActive { get; set; }

        [VisibleOnGrid("text_duration")]
        public int Duration { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Language}, {(SubtitleLanguage == null || SubtitleLanguage == "" ? "Sin subtitulos" : SubtitleLanguage )}";
        }

    }
}
