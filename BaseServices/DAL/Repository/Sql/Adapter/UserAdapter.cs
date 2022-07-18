using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    public class UserAdapter : IGenericAdapter<User>
    {
        public User Adapt(object[] values)
        {
            try
            {
                return new User()
                {
                    Id = Guid.Parse(values[0].ToString()),
                    Username = (string)values[1],
                    Password = (string)values[2],
                    Email = (string)values[3],
                    Enabled = int.Parse(values[4].ToString()) == 1 ? true : false,
                    DVH = (int)values[5],
                    FullName = (string)values[6],
                    DNI = (string)values[7]
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
