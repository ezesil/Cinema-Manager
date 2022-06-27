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
        public LoginPage(NavigationManager navigationManager)
        {
            InitializeComponent();
            _navigationManager = navigationManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _navigationManager.MenuOnLogin();
        }
    }
}
