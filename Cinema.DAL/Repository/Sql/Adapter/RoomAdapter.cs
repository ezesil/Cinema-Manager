using Cinema.DAL.Interfaces;
using Cinema.Domain;
using Cinema.Domain.Extensions;
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
                Id = values[0].ToGuid(),
                Identifier = values[1]?.ToString(),
                HasBigScreen = values[2].ByteToBoolean(),
                Has3D = values[3].ByteToBoolean(),
                IsActive = values[4].ByteToBoolean()
            };
        }
    }
}
