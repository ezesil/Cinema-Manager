using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services
{
    /// <summary>
    /// Contenedor de servicios. Permite obtener y registrar una instancia de una clase. 
    /// Requiere un constructor sin parametros.
    /// </summary>
    public class ServiceContainer
    {
        private static ServiceProvider services { get; set; } = SetupServices();

        private ServiceContainer()
        {
            
        }

        private static ServiceProvider SetupServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<BackupServices>();
            services.AddSingleton<SessionService>();
            services.AddSingleton<IntegrityService>();
            services.AddSingleton<ExceptionHandler>();
            services.AddSingleton<HashingService>();
            services.AddSingleton<LanguageService>();
            services.AddSingleton<Logger>();
            services.AddSingleton<RolePermissionManagementService>();

            var service = services.BuildServiceProvider();

            var exhandler = service.GetService<ExceptionHandler>();
            var logger = service.GetService<Logger>();
            exhandler.OnExceptionHandled += logger.Log;

            return service;
        }

        /// <summary>
        /// Instancia del servicio.
        /// </summary>
        public static ServiceProvider Instance
        {
            get
            {
                if(services == null)
                    services = SetupServices();

                return services;
            }
        }

        ///// <summary>
        ///// Obtiene un servicio.Si el servicio no existe, crea una instancia del mismo y la guarda en el contenedor.
        ///// </summary>
        ///// <typeparam name = "T" ></ typeparam >
        ///// < returns ></ returns >
        //public T GetService<T>(Func<ServiceContainer, T> instanceDescriptor = null) where T : class
        //{
        //    var item = objList.OfType<T>().ToList();
        //    if (item.OfType<T>().Count() < 1)
        //    {
        //        var obj = CreateObject<T>();
        //        if (instanceDescriptor == null)
        //            Register(x => obj);
        //        else
        //            Register(instanceDescriptor);

        //        return GetService<T>();
        //    }
        //    else
        //        return item.First();
        //}

        ///// <summary>
        ///// Registra un servicio. Puede registrarse un servicio con parametros.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        //public void Register<T>(Func<ServiceContainer, T> instanceDescriptor = null) where T : class
        //{
        //    if (instanceDescriptor == null)
        //    {
        //        var service = CreateObject<T>();
        //        objList.Add(service);
        //    }
        //    else
        //    {
        //        var service = instanceDescriptor.Invoke(this);
        //        objList.Add(service);
        //    }

        //}

        //private TOut GetObject<TOut>(params object[] values)
        //{
        //    Type specificType = typeof(TOut);

        //    Type genericType = Type.GetType("System.Tuple`" + values.Length);
        //    Type[] typeArgs = values.Select(item => item.GetType()).ToArray();
        //    object[] constructorArguments = values.Cast<object>().ToArray();
        //    return (TOut)Activator.CreateInstance(specificType, constructorArguments);
        //}

        //private TOut CreateObject<TOut>()
        //{
        //    Type specificType = typeof(TOut);
        //    return (TOut)Activator.CreateInstance(specificType);
        //}
    }
}
