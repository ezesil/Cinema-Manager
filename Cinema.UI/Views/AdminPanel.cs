using BaseServices.Domain;
using BaseServices.Services;
using Cinema.UI.AdminViews;
using Cinema.UI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema.UI.Views
{
    public partial class AdminPanel : UserControl
    {
        private Logger _logger;
        private NavigationManager _navigationManager;
        private SessionService _sessionService;
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
            Logger logger, 
            ExceptionHandler exmanager,
            SessionService sessionService,
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
            this.Tag = "text_admin_panel";
            
            // Services
            _logger = logger;
            _sessionService = sessionService;
            _exmanager = exmanager;
            _navigationManager = navigationManager;

            try
            {
                if (true || _sessionService.UserIsNull || !_sessionService.UserHasPermission(PermissionType.Administrator))
                    throw new Exception("Intento de acceso ilegal a herramientas de permisos elevados.");

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
                _exmanager.Handle(ex, ex.Message + " Datos del usuario: Guid: " + _sessionService.CurrentUserGuid + ", Nombre: " + _sessionService.CurrentUser + ", Correo: " + _sessionService.CurrentUserCorreo, Log.Severity.Critical);
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
