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

        public static void SetInstance(IServiceProvider serviceProvider)
        {
            if(_instance == null)
                _instance = serviceProvider;
        }

        public static T Get<T>()
        {
            return _instance.GetService<T>();
        }
    }
}
