using BaseServices.Domain;
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

namespace Cinema.UI.Views
{
    public partial class RegisterPage : UserControl
    {
        private SessionService _sessionService;
        private ExceptionHandler _exhandler;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public RegisterPage(SessionService sessionService,
            ExceptionHandler exhandler)
        {
            InitializeComponent();
            _sessionService = sessionService;
            _exhandler = exhandler;


        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User(
                        Guid.NewGuid(),
                        TxtUsername.Text,
                        TxtContraseña.Text,
                        TxtEmail.Text,
                        TxtNombre.Text,
                        TxtDni.Text);

                _sessionService.RegisterUser(user);

                MessageBox.Show("text_successful_register");
            }
            catch (Exception ex)
            {
                MessageBox.Show(_exhandler.Handle(ex).Message);
            }
        }
    }
}
