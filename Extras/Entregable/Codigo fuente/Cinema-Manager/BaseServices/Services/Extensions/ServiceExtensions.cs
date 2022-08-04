using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services.Extensions
{
    /// <summary>
    /// Extensiones de servicios.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Extrae el texto de un flag Description que pueda encontrarse en un Enum.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string ToTextCode(this Enum e)
        {
            var attribute =
                e.GetType()?
                    .GetTypeInfo()?
                    .GetMember(e.ToString())
                    .FirstOrDefault(member => member.MemberType == MemberTypes.Field)?
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault()
                    as DescriptionAttribute;

            return attribute?.Description ?? e.ToString();            
        }       
    }
}
