using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    internal static class InstanceManager
    {
        private static List<object> objList = new List<object>();

        public static T Get<T>() where T : class, new()
        {
            var item = objList.OfType<T>().ToList();
            if (item.OfType<T>().Count() < 1)
            {
                var obj = new T();
                objList.Add(obj);
                return obj;
            }
            else
                return item.First();
        }

        public static void Register<T>() where T : class, new()
        {
            var obj = new T();
            objList.Add(obj);           
        }
    }
}
