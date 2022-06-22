using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.SqlServer.Adapter
{
    public class UserAdapter : IGenericAdapter<User>
    {
        public User Adapt(object[] values)
        {
            throw new NotImplementedException();
        }
    }
}
