using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    internal interface IRolPermisoRepository : IGenericRepository<RolPermisoRelation, int>
    {
        new int Delete(RolPermisoRelation R);
    }
}
