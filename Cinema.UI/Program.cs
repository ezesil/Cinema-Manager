using BaseServices.Services;
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

            // Servicios de BaseServices
            services.AddSingleton<BackupServices>();
            services.AddSingleton<CheckerDigitService>();
            services.AddSingleton<ExceptionHandlerService>();
            services.AddSingleton<HashingService>();
            services.AddSingleton<LanguageService>();
            services.AddSingleton<LogService>();
            services.AddSingleton<PermissionCheckProvider>();

            // Servicios de la UI
            services.AddSingleton<ControlTranslationService>();
            services.AddSingleton<ContentService>();

            // Paginas
            services.AddSingleton<PaginaInicio>();
            services.AddSingleton<AdminPanel>();
            services.AddSingleton<Home>();
            services.AddSingleton<Form1>();


            ServiceProvider serviceProvider = services.BuildServiceProvider();

            DependencyService.SetInstance(serviceProvider);
            
            var form1 = serviceProvider.GetRequiredService<Home>();
            Application.Run(form1);
            
        }
    }
}
