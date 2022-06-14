using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI.Extensions
{
    internal static class UserControlExtensions
    {
        public static string GetTitle(this UserControl userControl)
        {
            return userControl.Name;
        }

        public static void SetTitle(this UserControl userControl, string title)
        {
            userControl.Name = title;
        }
    }
}
