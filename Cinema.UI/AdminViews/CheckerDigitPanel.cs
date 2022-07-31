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

namespace Cinema.UI.AdminViews
{
    public partial class CheckerDigitPanel : UserControl
    {
        LanguageService _languageService { get; set; }
        IntegrityService _integrityService { get; set; }
        Logger _logger { get; set; }
        ExceptionHandler _exceptionHandler { get; set; }
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
            _exceptionHandler = exceptionHandler;
        }

        private void BtnRecalcularEntidad_Click(object sender, EventArgs e)
        {
            //_integrityService.
        }
    }
}
