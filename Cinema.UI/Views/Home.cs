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

        public Home(NavigationManager contentService)
        {
            InitializeComponent();
            _navigationManager = contentService;
            _navigationManager.SetHeaderContainer(splitContainer2.Panel1);
            _navigationManager.SetHeaderTitle("Inicio");
            var buttons = new List<Button>()
            {
                BotonInicio,
                BtnGenerarTicket,
                BtnTickets,
                BtnSesiones,
                BtnPeliculas,
                BtnUsuarios,               
                BtnAdministracion,
            };
            _navigationManager.Setup(splitContainer2.Panel2, buttons);         
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

        }

        private void BtnSesiones_Click(object sender, EventArgs e)
        {

        }

        private void BtnPeliculas_Click(object sender, EventArgs e)
        {

        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {

        }
    }
}
