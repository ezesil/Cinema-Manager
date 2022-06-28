using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Session : Entity
    {
        public Guid? Id { get; set; }
        public DateTime Date { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? RoomId { get; set; }
    }
}
