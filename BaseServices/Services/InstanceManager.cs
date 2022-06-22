using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    public static class ServiceContainer
    {
        private static List<object> objList = new List<object>();

        /// <summary>
        /// Obtiene un servicio. Si el servicio no existe, crea una instancia del mismo y la guarda en el contenedor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Registra un servicio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>() where T : class, new()
        {
            var obj = new T();
            objList.Add(obj);           
        }
    }
}
