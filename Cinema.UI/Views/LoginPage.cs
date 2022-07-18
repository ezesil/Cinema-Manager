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

        private void button1_Click(object sender, EventArgs e)
        {
            var res = _sessionService.TryLogin(TxtUserEmail.Text, TxtPassword.Text);
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
