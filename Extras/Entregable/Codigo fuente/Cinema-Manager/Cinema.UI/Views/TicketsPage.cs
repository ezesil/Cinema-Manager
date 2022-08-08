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
    /// <summary>
    /// Pagina de tickets.
    /// </summary>
    public partial class TicketsPage : UserControl
    {
        LanguageService _languageService;

        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        /// <param name="languageService"></param>
        public TicketsPage(LanguageService languageService)
        {
            InitializeComponent();
            _languageService = languageService;
            this.Name = "text_tickets";
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            GridPrincipal.Clear();
            TicketsBLL.Current.GetAllTickets(DateTimeDesde.Value, DateTimeHasta.Value).ForEach(x => GridPrincipal.Add(x));

            GridPrincipal.UpdateNames<Ticket>(x => _languageService.TranslateCode(x));
        }

        private void TicketsPage_Load(object sender, EventArgs e)
        {
            GridPrincipal.SetupBehaviour();
        }

    }
}
