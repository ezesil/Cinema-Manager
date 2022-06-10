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
        private ContentService _contentService;

        public Home(ContentService contentService)
        {
            InitializeComponent();
            _contentService = contentService;
            var buttons = new List<Button>()
            {

            };
            _contentService.Setup(splitContainer2, buttons);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _contentService.NavigateTo<PaginaInicio>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _contentService.NavigateTo<AdminPanel>();
        }
    }
}
