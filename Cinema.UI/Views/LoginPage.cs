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
    public partial class LoginPage : UserControl
    {
        public NavigationManager _navigationManager { get; set; }

        private SessionService _sessionService;

        ControlTranslationService _controlTranslationService { get; set; }
        public LoginPage(NavigationManager navigationManager,
            ControlTranslationService controlTranslationService,
            SessionService sessionService)
        {
            InitializeComponent();
            _navigationManager = navigationManager;
            _controlTranslationService = controlTranslationService;
            _sessionService = sessionService;

            _controlTranslationService.OnRefresh += () =>
            {
                _controlTranslationService.TryTranslateForm(this);
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HideError();
            TxtUserEmail.Enabled = false;
            TxtPassword.Enabled = false;
            button1.Enabled = false;
            //await Task.Delay(2000);
            try
            {
                if (_sessionService.TryLogin(TxtUserEmail.Text, TxtPassword.Text))
                {
                    _navigationManager.NavigateTo<MainPage>();
                }
                else
                {
                    ShowError();
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
            TxtUserEmail.Enabled = true;
            TxtPassword.Enabled = true;
            button1.Enabled = true;
        }

        private void HideError()
        {
            TxtError.Visible = false;
        }

        private void ShowError(string error = "Nombre de usuario o contraseña incorrectos.")
        {
            TxtError.Text = error;
            TxtError.Visible = true;
        }

        private void ShowMessageBox(string text = "Ocurrió un error inesperado. Intente nuevamente en unos minutos.")
        {
            MessageBox.Show(text);
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
