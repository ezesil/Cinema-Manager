﻿using BaseServices.Domain;
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
                if (false || (_sessionService.UserIsNull || !_sessionService.UserHasPermission(Permission.AdminPanel)))
                    throw new Exception("Intento de acceso ilegal a herramientas de permisos elevados.");

                if (true || _sessionService.UserHasPermission(Permission.BackupPanel))
                    AddPanel(backupPanel);
                if (true || _sessionService.UserHasPermission(Permission.PermissionsPanel))
                    AddPanel(permissionsPanel);
                if (true || _sessionService.UserHasPermission(Permission.RolesPanel))
                    AddPanel(rolesPanel);
                if (true || _sessionService.UserHasPermission(Permission.UsersPanel))
                    AddPanel(usersPanel);
                if (true || _sessionService.UserHasPermission(Permission.CheckerDigitPanel))
                    AddPanel(checkerDigitPanel);
                if (true || _sessionService.UserHasPermission(Permission.LanguagesPanel))
                    AddPanel(languagesPanel);
                if (true || _sessionService.UserHasPermission(Permission.LogsPanel))
                    AddPanel(logsPanel);

            }
            catch (Exception ex)
            {
                _exmanager.Handle(ex);
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

        private TabPage AddPanel(UserControl panel)
        {
            panel.AutoScroll = true;
            TabPage tp = new TabPage(panel.Name);
            tp.ForeColor = Color.Black;
            tp.AutoScroll = true;
            tp.Font = new Font("Arial", 9 , FontStyle.Bold);
            panel.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(tp);
            tp.Controls.Add(panel);
            return tp;
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

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
