using BaseServices.Domain;
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
            services.AddSingleton(x => ServiceContainer.Instance.GetService<BackupServices>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<SessionService>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<IntegrityService>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<ExceptionHandler>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<HashingService>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<LanguageService>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<Logger>());
            services.AddSingleton(x => ServiceContainer.Instance.GetService<RolePermissionManagementService>());

            // Servicios de la UI
            services.AddSingleton<NavigationManager>();
            services.AddSingleton<ControlTranslationService>();

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
            services.AddSingleton<RoomsPage>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            DependencyService.SetInstance(serviceProvider);

            var integrityService = DependencyService.Get<IntegrityService>();

            var session = ServiceContainer.Instance.GetService<SessionService>();

            string autologinmode = "";
            var homeform = DependencyService.Get<Home>();
            var sessionService = DependencyService.Get<SessionService>();
            var languageService = DependencyService.Get<LanguageService>();
            var exhandler = DependencyService.Get<ExceptionHandler>();
            var logger = DependencyService.Get<Logger>();

            // Evita el chequeo si es true
            bool chequeo = false;
            // modo de pruebas, si algo falla se logea como admin
            bool debugmode = false;

            integrityService.UpdateDVV(100);

            try
            {
                if (chequeo == false)
                {
                    try
                    {
                        chequeo = integrityService.CheckIntegrity();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception($"{languageService.TranslateCode("integrity_check_genericerror")}. Mensaje de origen: {ex.Message}", ex);                       
                    }
                }

                if (chequeo)
                {
                    if (autologinmode == "admin")
                    {
                        var res = sessionService.TryLogin("admin", "administrador");
                    }
            
                    Application.Run(homeform);           
                }

                else
                {
                    throw new Exception(languageService.TranslateCode("integrity_check_failed"));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                exhandler.Handle(ex);

                if (debugmode == true)
                {
                    sessionService.TryLogin("admin", "descargandomal33");
                    homeform = DependencyService.Get<Home>();
                    Application.Run(homeform);
                }

                Application.Exit();
            }
        }
    }
}
