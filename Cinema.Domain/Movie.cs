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
        [Description("text_id")]
        public Guid? Id { get; set; }

        [Description("text_name")]
        public string Name { get; set; }

        [Description("text_language")]
        public string Language { get; set; }

        [Description("text_subtitlelanguage")]
        public string SubtitleLanguage { get; set; }

        [Description("text_isactive")]
        public bool IsActive { get; set; }

        [Description("text_duration")]
        public int Duration { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
