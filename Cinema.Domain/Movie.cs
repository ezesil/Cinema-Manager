using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Movie : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string SubtitleLanguage { get; set; }
        public bool IsActive { get; set; }
        public int Duration { get; set; }
    }
}
