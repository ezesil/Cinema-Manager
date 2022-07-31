using Cinema.Domain.CustomFlags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Room : Entity
    {
        [VisibleOnGrid("text_id")]
        public Guid? Id { get; set; }

        [VisibleOnGrid("text_identifier")]
        public string Identifier { get; set; }

        [VisibleOnGrid("text_hasbigscreen")]
        public bool HasBigScreen { get; set; } = false;

        [VisibleOnGrid("text_has3d")]
        public bool Has3D { get; set; } = false;

        [VisibleOnGrid("text_isactive")]
        public bool IsActive { get; set; } = false;

        public override string ToString()
        {
            return Identifier;
        }
    }
}
