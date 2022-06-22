﻿using BaseServices.Services;
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
        private LogService _logger;
        private PermissionCheckProvider _permissions;
        private SessionServiceProvider _session;
        private ExceptionHandler _exmanager;

        public CreateTicketPage(LogService logger, PermissionCheckProvider permissions, ExceptionHandler exmanager)
        {
            InitializeComponent();
            this.Name = "Creacion de ticket";
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
