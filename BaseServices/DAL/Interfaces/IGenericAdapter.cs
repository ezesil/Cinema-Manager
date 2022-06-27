using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    public interface IGenericAdapter<T> where T: class, new()
    {
        T Adapt(object[] values);
    }
}
