using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql.Adapter
{
    public class SessionAdapter : IGenericAdapter<Session>
    {
        public Session Adapt(object[] values)
        {
            return new Session()
            {
                Id = Guid.Parse(values[0].ToString()),
                Date = DateTime.Parse(values[1].ToString()),
                MovieId = Guid.Parse(values[2].ToString()),
                RoomId = Guid.Parse(values[3].ToString())
            };
        }
    }
}
