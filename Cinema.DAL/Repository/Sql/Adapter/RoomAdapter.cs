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
    /// <summary>
    /// Adaptador de salas.
    /// </summary>
    public class RoomAdapter : IGenericAdapter<Room>
    {
        /// <summary>
        /// Adapta un objeto[] a Room.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Room Adapt(object[] values)
        {
            return new Room()
            {
                Id = values[0].ToGuid(),
                Identifier = values[1]?.ToString(),
                HasBigScreen = (bool)values[2],
                Has3D = (bool)values[3],
                IsActive = (bool)values[4]
            };
        }
    }
}
