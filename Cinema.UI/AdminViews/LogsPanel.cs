using BaseServices.Domain;
using BaseServices.Services;
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

namespace Cinema.UI.AdminViews
{
    public partial class LogsPanel : UserControl
    {
        private Logger _logger;
        private ExceptionHandler _exhandler;

        public LogsPanel(Logger logger,
            ExceptionHandler exhandler)
        {
            InitializeComponent();

            this.Name = "text_logs";

            _logger = logger;
            _exhandler = exhandler;

            GridLogs.SetupBehaviour(RowClick);
        }

        private void RowClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var log = GridLogs.GetCellValues<Log>();

                TxtDetalleLog.Text = "";
                TxtDetalleLog.Text += "Mensaje del sistema: " + log.Message + "\r\n";
                TxtDetalleLog.Text += "Fecha del evento: " + log.Fecha + "\r\n";
                TxtDetalleLog.Text += "Severidad: " + log.SeverityName + "\r\n";
                TxtDetalleLog.Text += "\r\nTraza completa:" + "\r\n" + "\r\n" + log.StackTrace;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void TxtFiltrar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridLogs.DataSource != null)
                    (GridLogs.DataSource as DataTable).DefaultView.RowFilter =
                        $"Fecha LIKE '%{TxtFiltrar.Text}%' OR " +
                        $"Message LIKE '%{TxtFiltrar.Text}%' OR " +
                        $"SeverityName LIKE '%{TxtFiltrar.Text}%' OR " +
                        $"StackTrace LIKE '%{TxtFiltrar.Text}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnObtenerLogsLocales_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.GetAllFileLogs().OrderByDescending(x => x.Fecha).ToList().ForEach(x => GridLogs.Add(x));
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnObtenerLogsBd_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.GetAllSqlLogs().ForEach(x => GridLogs.Add(x));
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }
    }
}
