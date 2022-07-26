using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Interfaces
{
    public interface IGenericAdapter<T>
    {
        T Adapt(object[] values);
    }
}
