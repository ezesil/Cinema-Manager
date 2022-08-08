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
    /// Pagina de gestion de usuarios
    /// </summary>
    public partial class UsersPanel : UserControl
    {
        /// <summary>
        /// Constructor con los servicios necesarios para un correcto funcionamiento del panel.
        /// </summary>
        public UsersPanel()
        {
            InitializeComponent();
            this.Name = "text_users";
        }
    }
}
