using BaseServices.Domain;
using BaseServices.Services;
using Cinema.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace Cinema.UI.Views
{
    /// <summary>
    /// Pagina principal y contenedor de los servicios de navegacion.
    /// </summary>
    public partial class Home : Form
    {
        private NavigationManager _navigationManager;
        private SessionService _sessionService;
        private ControlTranslationService _controlTranslationService;

        /// <summary>
        /// Constructor con servicios necesarios para operar.
        /// </summary>
        /// <param name="navigationManager"></param>
        /// <param name="sessionService"></param>
        /// <param name="controlTranslationService"></param>
        public Home(NavigationManager navigationManager,
            SessionService sessionService, 
            ControlTranslationService controlTranslationService)
        {
            InitializeComponent();

            _controlTranslationService = controlTranslationService;

            controlTranslationService.OnRefresh += () =>
            {
                controlTranslationService.TryTranslateForm(this.Controls);
                controlTranslationService.TryTranslateForm(this.splitContainer1.Panel1.Controls);
                controlTranslationService.TryTranslateForm(this.splitContainer1.Panel2.Controls);
            };

            _navigationManager = navigationManager;
            _sessionService = sessionService;

            _sessionService.OnSuccessfulLogin += MenuOnLogin;
            _sessionService.OnSuccessfulLogout += MenuOnLogout;

            _navigationManager.SetHeaderContainer(splitContainer2.Panel2);
            _navigationManager.SetHeaderTitle("Inicio");
            _navigationManager.Setup(this, splitContainer1.Panel1, splitContainer1.Panel2, _sessionService);
        }

        private void BotonInicio_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<MainPage>();
        }

        private void BtnGenerarTicket_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<CreateTicketPage>(x => x.UserHasPermission(Permission.CreateTicketPage));
        }

        private void BtnTickets_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<TicketsPage>(x => x.UserHasPermission(Permission.TicketsPage));
        }

        private void BtnSesiones_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<SessionsPage>(x => x.UserHasPermission(Permission.SessionsPage));
        }

        private void BtnSalas_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<RoomsPage>(x => x.UserHasPermission(Permission.RoomsPage));
        }

        private void BtnPeliculas_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<MoviesPage>(x => x.UserHasPermission(Permission.MoviesPage));
        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<AdminPanel>(x => x.UserHasPermission(Permission.AdminPanel));
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<LoginPage>();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            _sessionService.Logout();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            _sessionService.Logout();
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (_sessionService.UserIsNull)
            {
                _navigationManager.ClearNavigationButtons();
                _navigationManager.CreateButton(BtnLogin_Click, "BotonLogin", "text_login").Show();
                _navigationManager.CreateButton(BtnExit_Click, "BtnExit", "text_exit").Show();
                _navigationManager.NavigateTo<LoginPage>();
            }
            else
            {
                MenuOnLogin();
            }
        }

        /// <summary>
        /// Metodo utilizado en caso de login existoso. 
        /// </summary>
        public void MenuOnLogin()
        {
            _navigationManager.ClearNavigationButtons();

            _navigationManager.CreateButton(BotonInicio_Click, "BotonInicio", "text_home").Show();

            if (_sessionService.UserHasPermission(Permission.CreateTicketPage))
                _navigationManager.CreateButton(BtnGenerarTicket_Click, "BtnGenerarTicket", "text_generateticket").Show();

            if (_sessionService.UserHasPermission(Permission.TicketsPage))
                _navigationManager.CreateButton(BtnTickets_Click, "BtnTickets", "text_tickets").Show();

            if (_sessionService.UserHasPermission(Permission.SessionsPage))
                _navigationManager.CreateButton(BtnSesiones_Click, "BtnSesiones", "text_sessions").Show();

            if (_sessionService.UserHasPermission(Permission.RoomsPage))
                _navigationManager.CreateButton(BtnSalas_Click, "BtnSalas", "text_rooms").Show();

            if (_sessionService.UserHasPermission(Permission.MoviesPage))
                _navigationManager.CreateButton(BtnPeliculas_Click, "BtnPeliculas", "text_movies").Show();

            if (_sessionService.UserHasPermission(Permission.AdminPanel))
                _navigationManager.CreateButton(BtnAdministracion_Click, "BtnAdministracion", "text_administration").Show();

            if (_sessionService.UserHasPermission(Permission.RegisterPage))
                _navigationManager.CreateButton(BtnRegistrarUsuario_Click, "BtnRegistrarUSuario", "text_registeruser").Show();

            _navigationManager.CreateButton(BtnLogout_Click, "BtnLogout", "text_logout").Show();
            _navigationManager.CreateButton(BtnExit_Click, "BtnExit", "text_exit").Show();

            _navigationManager.NavigateTo<MainPage>(x => x.UserHasPermission(Permission.MainPage));
        }

        private void BtnRegistrarUsuario_Click(object? sender, EventArgs e)
        {
            _navigationManager.NavigateTo<RegisterPage>(x => x.UserHasPermission(Permission.RegisterPage));
        }

        private void MenuOnLogout()
        {
            _navigationManager.ClearNavigationButtons();
            _navigationManager.CreateButton(BtnLogin_Click, "BotonLogin", "text_login").Show();
            _navigationManager.CreateButton(BtnExit_Click, "BtnExit", "text_exit").Show();
            _navigationManager.NavigateTo<LoginPage>();
        }

    }
}
