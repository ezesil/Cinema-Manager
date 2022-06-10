using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.UI.Services
{
    public class DependencyService
    {
        private static IServiceProvider _instance;

        /// <summary>
        /// Setea una instancia del proveedor de servicios. Solo funciona en el primer uso.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SetInstance(IServiceProvider serviceProvider)
        {
            if(_instance == null)
                _instance = serviceProvider;
        }

        public static T Get<T>()
        {
            var instance = _instance.GetService<T>();
            if (instance == null)
                throw new Exception($"No se encontró un servicio de tipo {typeof(T)}.");
            else
                return instance;
        }
    }
}
