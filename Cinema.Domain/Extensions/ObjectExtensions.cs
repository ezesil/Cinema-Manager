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
        public static bool ByteToBoolean(this object obj)
        {
            return ((byte[])obj)[0] == 1 ? true : false;
        }

        public static bool StringToBoolean(this object obj)
        {
            return bool.Parse(obj.ToString());
        }

        public static Guid ToGuid(this object obj)
        {
            if(obj == null)
                return Guid.Empty;

            return Guid.Parse(obj.ToString());
        }

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

        public static T? GetFlag<T>(this PropertyInfo e) where T : Attribute
        {
            Object[] attributes = e.GetCustomAttributes(typeof(T), false);

            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }
            return null;
        }
    }
}
