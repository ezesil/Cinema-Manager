using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Room : Entity
    {
        public Guid? Id { get; set; }
        public string Identifier { get; set; }
        public bool HasBigScreen { get; set; } = false;
        public bool Has3D { get; set; } = false;
        public bool IsActive { get; set; } = false;

        public override string ToString()
        {
            return Identifier;
        }
    }
}
