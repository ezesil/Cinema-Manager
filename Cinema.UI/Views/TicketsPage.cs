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
        public TicketsPage()
        {
            InitializeComponent();
            this.Name = "Tickets";
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            var items = Cinema.Business.TicketsBLL.Current.GetAllTickets(DateTimeDesde.Value, DateTimeHasta.Value);
        }
    }
}
