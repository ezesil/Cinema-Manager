using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql.Adapter
{
    public class RoomAdapter : IGenericAdapter<Room>
    {
        public Room Adapt(object[] values)
        {
            return new Room()
            {
                Id = Guid.Parse(values[0]?.ToString()),
                Identifier = values[1]?.ToString(),
                HasBigScreen = (bool)values[2],
                Has3D = (bool)values[3],
                IsActive = (bool)values[4]
            };
        }
    }
}
