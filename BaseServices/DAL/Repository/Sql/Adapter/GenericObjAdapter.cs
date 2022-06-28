using BaseServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    internal class GenericObjAdapter<T> : IGenericAdapter<T> where T : class, new()
    {
        public T Adapt(object[] values)
        {
            return (T)values[0];
        }
    }
}
