using Cinema.UI.Services;
using Cinema.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            services.AddSingleton<ContentService>();
            services.AddSingleton<PaginaInicio>();
            services.AddSingleton<Home>();
            services.AddSingleton<Form1>();


            ServiceProvider serviceProvider = services.BuildServiceProvider();

            DependencyService.SetInstance(serviceProvider);
            
            var form1 = serviceProvider.GetRequiredService<Home>();
            Application.Run(form1);
            
        }
    }
}
