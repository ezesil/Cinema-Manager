using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Extensions
{
    /// <summary>
    /// Extensiones para la clase Object.
    /// </summary>
    public static class ObjectExtensions
    {      
        /// <summary>
        /// Convierte un objeto Byte[] en tipo booleano. Solo funciona si el objeto de origen es byte[].
        /// Hecho para reducir codigo en adaptadores.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ByteToBoolean(this object obj)
        {
            return ((byte[])obj)[0] == 1 ? true : false;
        }

        /// <summary>
        /// Convierte un objeto string en tipo booleano. Solo funciona si el objeto de origen es string.
        /// Hecho para reducir codigo en adaptadores.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool StringToBoolean(this object obj)
        {
            return bool.Parse(obj.ToString());
        }

        /// <summary>
        /// Convierte un objeto en tipo booleano. Solo funciona si el objeto de origen es un string con formato Guid.
        /// Hecho para reducir codigo en adaptadores.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(this object obj)
        {
            if(obj == null)
                return Guid.Empty;

            return Guid.Parse(obj.ToString());
        }

        /// <summary>
        /// Obtiene el texto especificado en el flag [Description(texto)] del objeto especificado.
        /// Utilizado para obtener este flag de propiedades.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo de extension de PropertyInfo. Obtiene el flag especificado en el tipo generico.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
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
