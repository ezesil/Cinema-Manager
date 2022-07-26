using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    internal class RolAdapter : IGenericAdapter<Rol>
    {
        public Rol Adapt(object[] values)
        {
            return new Rol()
            {
                Id = (int)values[0],
                Nombre = (string)values[1]
            };
        }
    }
}
