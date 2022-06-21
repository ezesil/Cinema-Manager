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
            _navigationManager.SetHeaderContainer(splitContainer2.Panel2);
            _navigationManager.SetHeaderTitle("Inicio");
            var buttons = new List<Button>()
            {
                BotonInicio,
                BtnGenerarTicket,
                BtnTickets,
                BtnSesiones,
                BtnPeliculas,
                BtnAdministracion,
            };
            _navigationManager.Setup(splitContainer1.Panel2, buttons);                    
        }

        private void BotonInicio_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<LoginPage>();
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

        private void BtnPeliculas_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<MoviesPage>();
        }

        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<AdminPanel>();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            _navigationManager.NavigateTo<LoginPage>();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
