using System;
using System.Reflection;

namespace FourToolkit.Notifications.Extensions
{
    public static class TypeExt
    {
        public static object GetDefault(this Type type)
        {
            if (type.GetTypeInfo().IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }
    }
}
