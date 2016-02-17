using System.Reflection;

namespace FourToolkit.Notifications.Extensions
{
    public static class ObjectExt
    {
        public static bool IsDefault(this object obj)
        {
            if (obj == null) return true;
            var type = obj.GetType();
            if (!type.GetTypeInfo().IsValueType) return false;
            return obj.Equals(type.GetDefault());
        }
    }
}
