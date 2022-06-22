using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Logs;
using BaseServices.Services;
using Cinema.UI.AdminViews;
using Cinema.UI.Extensions;
using Cinema.UI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using static BaseServices.Domain.Control_de_acceso.Permiso;

namespace Cinema.UI.Views
{
    public partial class AdminPanel : UserControl
    {
        private LogService _logger;
        private NavigationManager _navigationManager;
        private PermissionCheckProvider _permissions;
        private SessionServiceProvider _session;
        private ExceptionHandler _exmanager;
        private BackupPanel _backupPanel;
        private PermissionsPanel _permissionsPanel;
        private RolesPanel _rolesPanel;
        private UsersPanel _usersPanel;
        private CheckerDigitPanel _checkerDigitPanel;
        private LanguagesPanel _languagesPanel;
        private LogsPanel _logsPanel;

        public AdminPanel(
            NavigationManager navigationManager,
            LogService logger, 
            PermissionCheckProvider permissions, 
            ExceptionHandler exmanager,
            BackupPanel backupPanel,
            PermissionsPanel permissionsPanel,
            RolesPanel rolesPanel,
            UsersPanel usersPanel,
            CheckerDigitPanel checkerDigitPanel,
            LanguagesPanel languagesPanel,
            LogsPanel logsPanel
            )
        {
            InitializeComponent();

            // Title
            this.Name = "Panel de administrador";
            
            // Services
            _logger = logger;
            _permissions = permissions;
            _session = SessionServiceProvider.Current;
            _exmanager = exmanager;
            _navigationManager = navigationManager;

            try
            {
                //if (_session.UserIsNull || !_permissions.HasPermission(PermissionType.Administrator))
                //    throw new Exception("Intento de acceso ilegal a herramientas de permisos elevados.");

                AddPanel(backupPanel);
                AddPanel(permissionsPanel);
                AddPanel(rolesPanel);
                AddPanel(usersPanel);
                AddPanel(checkerDigitPanel);
                AddPanel(languagesPanel);
                AddPanel(logsPanel);
            }
            catch (Exception ex)
            {
                _exmanager.Handle(ex, ex.Message + " Datos del usuario: Guid: " + SessionServiceProvider.Current.CurrentUserGuid + ", Nombre: " + SessionServiceProvider.Current.CurrentUser + ", Correo: " + SessionServiceProvider.Current.CurrentUserCorreo, Log.Severity.Critical);
                _navigationManager.NavigateTo<MainPage>();
            }

            // Panels
            _backupPanel = backupPanel;
            _permissionsPanel = permissionsPanel;
            _rolesPanel = rolesPanel;
            _usersPanel = usersPanel;
            _checkerDigitPanel = checkerDigitPanel;
            _languagesPanel = languagesPanel;
            _logsPanel = logsPanel;
        }

        private void AddPanel(UserControl panel)
        {
            TabPage tp = new TabPage(panel.Name);
            tp.ForeColor = Color.Black;
            tp.Font = new Font("Arial", 9 , FontStyle.Bold);
            panel.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tp.Controls.Add(panel);
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
