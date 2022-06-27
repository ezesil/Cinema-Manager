using BaseServices.Services;
using Cinema.UI.AdminViews;
using Cinema.UI.Services;
using Cinema.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            services.AddSingleton<SessionService>();
            services.AddSingleton<CheckerDigitService>();
            services.AddSingleton<ExceptionHandler>();
            services.AddSingleton<HashingService>();
            services.AddSingleton<LanguageService>();
            services.AddSingleton<Logger>();

            // Servicios de la UI
            services.AddSingleton<ControlTranslationService>();
            services.AddSingleton<NavigationManager>();

            // Paneles de administracion
            services.AddTransient<BackupPanel>();
            services.AddTransient<PermissionsPanel>();
            services.AddTransient<RolesPanel>();
            services.AddTransient<UsersPanel>();
            services.AddTransient<CheckerDigitPanel>();
            services.AddTransient<LanguagesPanel>();
            services.AddTransient<LogsPanel>();

            // Paginas
            services.AddTransient<AdminPanel>();
            services.AddSingleton<CreateTicketPage>();
            services.AddSingleton<Home>();
            services.AddSingleton<MainPage>();
            services.AddSingleton<LoginPage>();
            services.AddSingleton<RegisterPage>();
            services.AddSingleton<MoviesPage>();
            services.AddSingleton<SessionsPage>();
            services.AddSingleton<TicketsPage>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            DependencyService.SetInstance(serviceProvider);
            
            var homeform = serviceProvider.GetRequiredService<Home>();
            Application.Run(homeform);
            
        }
    }
}
