using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.Services.Extensions
{
    public static class ServiceExtensions
    {
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
