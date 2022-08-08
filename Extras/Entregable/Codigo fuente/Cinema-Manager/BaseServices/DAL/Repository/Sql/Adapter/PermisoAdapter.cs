using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    internal class PermisoAdapter : IGenericAdapter<Permiso>
    {
        public Permiso Adapt(object[] values)
        {
            return new Permiso((int)values[0], (string)values[1]);
        }
    }
}
