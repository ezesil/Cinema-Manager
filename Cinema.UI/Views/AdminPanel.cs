using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Logs;
using BaseServices.Services;
using System;
using System.Windows.Forms;

namespace Cinema.UI.Views
{
    public partial class AdminPanel : UserControl
    {
        private LogService _logService;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                if (SessionServiceProvider.Current.UserIsNull)
                    throw new Exception("Intento de acceso ilegal a herramientas de permisos elevados."); //traducir

                if (!PermissionCheckProvider.Current.HasPermission(Permiso.PermissionType.Administrator))
                    throw new Exception("Intento de acceso ilegal a herramientas de permisos elevados.");
            }

            catch (Exception ex)
            {
                //traducir
                ExceptionManagerService.Handle(ex, new Log(ex.Message + " Datos del usuario: Guid= " + SessionServiceProvider.Current.CurrentUserGuid + ", Nombre= " + SessionServiceProvider.Current.CurrentUser + ", Correo= " + SessionServiceProvider.Current.CurrentUserCorreo, Log.Severity.Critical));
                throw;
            }
        }
    }
}
