using BaseServices.Services;
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
    public partial class CreateTicketPage : UserControl
    {
        private Logger _logger;
        private SessionService _sessionService;
        private ExceptionHandler _exmanager;

        public CreateTicketPage(Logger logger, ExceptionHandler exmanager, SessionService sessionService)
        {
            InitializeComponent();
            this.Name = "text_ticket_creation";
            _logger = logger;
            _sessionService = sessionService;
            _exmanager = exmanager;
        }

        private void PaginaInicio_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
