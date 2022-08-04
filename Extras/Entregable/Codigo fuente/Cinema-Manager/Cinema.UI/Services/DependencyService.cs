using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.UI.Services
{
    /// <summary>
    /// Servicios de dependencias interno de la aplicacion.
    /// </summary>
    public class DependencyService
    {
        private static IServiceProvider? _provider;

        /// <summary>
        /// Setea una instancia del proveedor de servicios. Solo funciona en el primer uso.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void SetInstance(IServiceProvider serviceProvider)
        {
            if(_provider == null)
                _provider = serviceProvider;
        }

        /// <summary>
        /// Obtiene un serrvicio del contenedor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T Get<T>()
        {
            var instance = _provider.GetService<T>();
            if (instance == null)
                throw new Exception($"No se encontró un servicio de tipo {typeof(T)} en el contenedor de servicios.");
            else
                return instance;
        }
    }
}
