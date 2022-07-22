using BaseServices.Services;
using Cinema.Business;
using Cinema.Domain;
using Cinema.UI.Extensions;
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
    public partial class TicketsPage : UserControl
    {
        LanguageService _languageService;
        public TicketsPage(LanguageService languageService)
        {
            InitializeComponent();
            _languageService = languageService;
            this.Name = "Tickets";
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            GridPrincipal.Clear();
            TicketsBLL.Current.GetAllTickets(DateTimeDesde.Value, DateTimeHasta.Value).ForEach(x => GridPrincipal.Add(x));
            GridPrincipal.UpdateNames<Ticket>(x => _languageService.TranslateCode(x));
        }

        private void TicketsPage_Load(object sender, EventArgs e)
        {
            GridPrincipal.SetupBehaviour(RowClick);
        }

        private void RowClick(object sender, DataGridViewCellEventArgs e)
        {
            var ticket = GridPrincipal.GetCellValues<Ticket>();

            //TxtFechaCreacion.Text = ticket.CreationTime.ToString();
            //TxtFila.Text = ticket.Row.ToString();
            //TxtAsiento.Text = ticket.Seat.ToString();
            //TxtFecha.Text = "";
            //TxtPelicula.Text = "";
            //TxtSala.Text = RoomsBLL.Current.GetRoom(ticket.SessionId());

        }
    }
}
