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
        ControlTranslationService _controlTranslationService { get; set; }
        public LoginPage(NavigationManager navigationManager, ControlTranslationService controlTranslationService)
        {
            InitializeComponent();
            _navigationManager = navigationManager;
            _controlTranslationService = controlTranslationService;

            _controlTranslationService.OnRefresh += () =>
            {
                _controlTranslationService.TryTranslateForm(this);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _navigationManager.MenuOnLogin();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
