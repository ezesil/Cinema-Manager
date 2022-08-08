using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Adaptador para usuarios.
    /// </summary>
    public class UserAdapter : IGenericAdapter<User>
    {
        /// <summary>
        /// Metodo para adaptar un objeto a un usuario.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
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
                    Enabled = bool.Parse(values[4].ToString()),
                    DVH = (int)values[5],
                    FullName = (string)values[6],
                    DNI = (string)values[7]
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
