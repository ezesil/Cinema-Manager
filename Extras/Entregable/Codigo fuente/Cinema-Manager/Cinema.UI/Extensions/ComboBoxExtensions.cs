using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Extensions
{
    /// <summary>
    /// Clase con metodos de extension de ComboBox.
    /// </summary>
    public static class ComboBoxExtensions
    {
       
        /// <summary>
        /// Obtiene el objeto original que fue agregado y seleccionado en la lista interna del ComboBox.
        /// </summary>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Tout GetSelectedObject<Tout>(this ComboBox e) where Tout : class
        {
            if(e.SelectedItem != null)
                return e.SelectedItem as Tout;

            else 
                return null;
        }
    }
    public class ComboBoxItem
    {
        public object Key { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return $"{Key} - {Value}";
        }
    }
}
