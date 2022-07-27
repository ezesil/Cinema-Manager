using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Extensions
{
    public static class ComboBoxExtensions
    {
        public static Tout GetSelectedObject<Tout>(this ComboBox e) where Tout : class
        {
            if(e.SelectedItem != null)
                return e.SelectedItem as Tout;

            else 
                return null;
        }
    }
}
