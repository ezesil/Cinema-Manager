using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    internal class RolePermissionAdapter : IGenericAdapter<RolPermisoRelation>
    {
        public RolPermisoRelation Adapt(object[] values)
        {
            return new RolPermisoRelation()
            {
                IdRol = (int)values[0],
                IdPermiso = (int)values[1]
            };
        }
    }
}
