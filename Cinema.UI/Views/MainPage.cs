using BaseServices.Services;
using Cinema.UI.Services;
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
    /// <summary>
    /// Pagina inicial
    /// </summary>
    public partial class MainPage : UserControl
    {
        private LanguageService _languageService;
        private ControlTranslationService _controlTranslationService;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public MainPage(LanguageService languageService,
            ControlTranslationService controlTranslationService)
        {
            InitializeComponent();
            this.Tag = "text_home";
            this.Name = "text_home";

            _languageService = languageService;
            _controlTranslationService = controlTranslationService;

            _controlTranslationService.TryTranslateForm(this);
        }
    }
}
