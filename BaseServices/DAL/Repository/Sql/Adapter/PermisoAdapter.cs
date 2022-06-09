using BaseServices.DAL.Interfaces;
using BaseServices.Domain.Control_de_acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    internal class RolAdapter : IGenericAdapter<Rol>
    {

        #region Singleton
        private readonly static RolAdapter _instance = new RolAdapter();

        public static RolAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private RolAdapter()
        {

        }
        #endregion

        public Rol Adapt(object[] values)
        {
            return new Rol(Convert.ToInt32(values[0].ToString()), values[1].ToString(), values[2].ToString());
        }


    }
}
