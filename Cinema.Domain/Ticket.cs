using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Ticket : Entity
    {
        public Guid? Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public int? Row { get; set; }
        public int? Seat { get; set; }
        public Guid? SessionId { get; set; }
        public Guid? CreatorUserId { get; set; }
    }
}
