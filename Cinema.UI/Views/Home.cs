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
            _contentService.SetHeaderContainer(splitContainer2.Panel1);
            _contentService.SetHeaderTitle("Inicio");
            var buttons = new List<Button>()
            {
                BotonInicio,
                button2,
                button3,
                button4,
                button5,
                button6,               
                button1,
            };
            _contentService.Setup(splitContainer2.Panel2, buttons);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void SetSelectedNavButton(object sender)
        {
            _contentService?.ButtonDisabler?.Invoke((Button)sender);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SetSelectedNavButton(sender);
            _contentService.NavigateTo<PaginaInicio>();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SetSelectedNavButton(sender);
            _contentService.NavigateTo<AdminPanel>();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
