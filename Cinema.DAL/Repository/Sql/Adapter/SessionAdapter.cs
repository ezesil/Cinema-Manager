using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Adaptadores para sesiones.
    /// </summary>
    public class SessionAdapter : IGenericAdapter<Session>
    {
        /// <summary>
        /// Adapta un objet[] a una sesion.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
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
