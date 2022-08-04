using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Headers
{
    /// <summary>
    /// Elemento header generico.
    /// </summary>
    public partial class GenericHeader : UserControl
    {
        /// <summary>
        /// Setea el nombre del header.
        /// </summary>
        /// <param name="name"></param>
        public void SetHeaderTitle(string name)
        {
            label1.Text = name;
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public GenericHeader()
        {
            InitializeComponent();
        }

        private void GenericHeader_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
