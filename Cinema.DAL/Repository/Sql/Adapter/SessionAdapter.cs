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
            throw new NotImplementedException();
        }
    }
}
