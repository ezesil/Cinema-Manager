using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Logs;
using BaseServices.Services;
using Cinema.UI.Services;
using System;
using System.Windows.Forms;
using static BaseServices.Domain.Control_de_acceso.Permiso;

namespace Cinema.UI.Views
{
    public partial class AdminPanel : UserControl
    {
        private LogService _logger;
        private PermissionCheckProvider _permissions;
        private SessionServiceProvider _session;
        private ExceptionHandlerService _exmanager;

        public AdminPanel(LogService logger, PermissionCheckProvider permissions, ExceptionHandlerService exmanager)
        {
            InitializeComponent();
            this.Name = "Panel de administrador";
            _logger = logger;
            _permissions = permissions;
            _session = SessionServiceProvider.Current;
            _exmanager = exmanager;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                if (_session.UserIsNull || !_permissions.HasPermission(PermissionType.Administrator))
                    throw new Exception("Intento de acceso ilegal a herramientas de permisos elevados.");
            }
            catch (Exception ex)
            {
                _exmanager.Handle(ex, new Log(ex.Message + " Datos del usuario: Guid= " + SessionServiceProvider.Current.CurrentUserGuid + ", Nombre= " + SessionServiceProvider.Current.CurrentUser + ", Correo= " + SessionServiceProvider.Current.CurrentUserCorreo, Log.Severity.Critical));
            }
        }
    }
}
