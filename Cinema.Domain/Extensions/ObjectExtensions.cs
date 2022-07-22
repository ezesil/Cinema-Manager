using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static String GetDescription(this Object e)
        {
            String valueText = e.ToString();

            Type type = e.GetType();

            PropertyInfo pi = type.GetProperty(valueText);

            Object[] attributes = pi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                DescriptionAttribute attribute = (DescriptionAttribute)attributes[0];
                return attribute.Description;
            }

            return valueText;
        }


    }
}
