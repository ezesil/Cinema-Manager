using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain
{
    public class Entity
    {     
        public Entity()
        {

        }
        public static TOut CreateTuple<TOut>(params object[] values)
        {
            Type specificType = typeof(TOut);

            Type genericType = Type.GetType("System.Tuple`" + values.Length);

            Type[] typeArgs = values.Select(item => item.GetType()).ToArray();
            object[] constructorArguments = values.Cast<object>().ToArray();
            return (TOut)Activator.CreateInstance(specificType, constructorArguments);
        }

        public static object GetTuple<T>(params T[] values)
        {
            Type genericType = Type.GetType("System.Tuple`" + values.Length);
            Type[] typeArgs = values.Select(_ => typeof(T)).ToArray();
            Type specificType = genericType.MakeGenericType(typeArgs);
            object[] constructorArguments = values.Cast<object>().ToArray();
            return Activator.CreateInstance(specificType, constructorArguments);
        }
    }
}
