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

namespace Cinema.UI.AdminViews
{
    /// <summary>
    /// Panel de administracion del sistema de chequeo de integridad.
    /// </summary>
    public partial class CheckerDigitPanel : UserControl
    {
        LanguageService _languageService { get; set; }
        IntegrityService _integrityService { get; set; }
        Logger _logger { get; set; }
        ExceptionHandler _exhandler { get; set; }

        /// <summary>
        /// Constructor con servicios necesarios para operar.
        /// </summary>
        /// <param name="languageService"></param>
        /// <param name="integrityService"></param>
        /// <param name="logger"></param>
        /// <param name="exceptionHandler"></param>
        public CheckerDigitPanel(LanguageService languageService,
            IntegrityService integrityService,
            Logger logger,
            ExceptionHandler exceptionHandler)
        {

            InitializeComponent();
            this.Name = "text_checker_digit";
            this.Tag = "text_checker_digit";

            _languageService = languageService;
            _integrityService = integrityService;
            _logger = logger;
            _exhandler = exceptionHandler;
        }

        private void BtnRecalcularEntidad_Click(object sender, EventArgs e)
        {
            try
            {
                _integrityService.UpdateDVV(int.Parse(TxtIdEntidad.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }

        private void BtnRecalcularUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                _integrityService.UpdateDVH(Guid.Parse(TxtUsuario.Text));
            }

            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }
    }
}
