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
    public partial class PaginaInicio : UserControl
    {
        private LogService _logger;
        private PermissionCheckProvider _permissions;
        private SessionServiceProvider _session;
        private ExceptionHandlerService _exmanager;

        public PaginaInicio(LogService logger, PermissionCheckProvider permissions, ExceptionHandlerService exmanager)
        {
            InitializeComponent();
            this.Name = "Pagina de inicio";
            _logger = logger;
            _permissions = permissions;
            _session = SessionServiceProvider.Current;
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
