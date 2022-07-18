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
    public partial class Home : Form
    {
        private NavigationManager _navigationManager;
        private SessionService _sessionService;
        private ControlTranslationService _controlTranslationService;
        bool firstload = true;
        public Home(NavigationManager navigationManager,
            SessionService sessionService, ControlTranslationService controlTranslationService)
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
            _navigationManager.Setup(this, splitContainer1.Panel2);
        }

        private void BotonInicio_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<MainPage>();
        }

        private void BtnGenerarTicket_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<CreateTicketPage>();
        }

        private void BtnTickets_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<TicketsPage>();
        }

        private void BtnSesiones_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<SessionsPage>();
        }

        private void BtnSalas_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<SessionsPage>();
        }

        private void BtnPeliculas_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<MoviesPage>();
        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<AdminPanel>();
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

        public void MenuOnLogin()
        {
            //if (_sessionService.UserHasPermission(Permission.Administrator))
            if (true)
            {
                _navigationManager.ClearNavigationButtons();
                _navigationManager.CreateButton(BotonInicio_Click, "BotonInicio", "text_home").Show();
                _navigationManager.CreateButton(BtnGenerarTicket_Click, "BtnGenerarTicket", "text_generateticket").Show();
                _navigationManager.CreateButton(BtnTickets_Click, "BtnTickets", "text_tickets").Show();
                _navigationManager.CreateButton(BtnSesiones_Click, "BtnSesiones", "text_sessions").Show();
                _navigationManager.CreateButton(BtnSalas_Click, "BtnSalas", "text_rooms").Show();
                _navigationManager.CreateButton(BtnPeliculas_Click, "BtnPeliculas", "text_movies").Show();
                _navigationManager.CreateButton(BtnAdministracion_Click, "BtnAdministracion", "text_administration").Show();
                _navigationManager.CreateButton(BtnRegistrarUsuario_Click, "BtnRegistrarUSuario", "text_registeruser").Show();
                _navigationManager.CreateButton(BtnLogout_Click, "BtnLogout", "text_logout").Show();
                _navigationManager.CreateButton(BtnExit_Click, "BtnExit", "text_exit").Show();
                _navigationManager.NavigateTo<MainPage>();
            }
            else if (_sessionService.UserHasPermission(PermissionType.Manager))
            {
                _navigationManager.ClearNavigationButtons();
                _navigationManager.CreateButton(BotonInicio_Click, "BotonInicio", "text_home").Show();
                _navigationManager.CreateButton(BtnGenerarTicket_Click, "BtnGenerarTicket", "text_generateticket").Show();
                _navigationManager.CreateButton(BtnTickets_Click, "BtnTickets", "text_tickets").Show();
                _navigationManager.CreateButton(BtnSesiones_Click, "BtnSesiones", "text_sessions").Show();
                _navigationManager.CreateButton(BtnSalas_Click, "BtnSalas", "text_rooms").Show();
                _navigationManager.CreateButton(BtnPeliculas_Click, "BtnPeliculas", "text_movies").Show();
                _navigationManager.CreateButton(BtnLogout_Click, "BtnLogout", "text_logout").Show();
                _navigationManager.CreateButton(BtnExit_Click, "BtnExit", "text_exit").Show();
                _navigationManager.NavigateTo<MainPage>();
            }
            else if (_sessionService.UserHasPermission(PermissionType.Receptionist))
            {
                _navigationManager.ClearNavigationButtons();
                _navigationManager.CreateButton(BotonInicio_Click, "BotonInicio", "text_home").Show();
                _navigationManager.CreateButton(BtnGenerarTicket_Click, "BtnGenerarTicket", "text_generateticket").Show();
                _navigationManager.CreateButton(BtnTickets_Click, "BtnTickets", "text_tickets").Show();
                _navigationManager.CreateButton(BtnLogout_Click, "BtnLogout", "text_logout").Show();
                _navigationManager.CreateButton(BtnExit_Click, "BtnExit", "text_exit").Show();
                _navigationManager.NavigateTo<MainPage>();
            }
            else
            {
                throw new Exception("Usuario sin permisos");
            }

        }

        private void BtnRegistrarUsuario_Click(object? sender, EventArgs e)
        {

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
