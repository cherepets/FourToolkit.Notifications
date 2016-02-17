using System.Reflection;

namespace FourToolkit.Notifications.Extensions
{
     public static class PropertyInfoExt
    {
        public static bool IsIndexed(this PropertyInfo prop)
            => prop.GetIndexParameters().Length > 0;
    }
}
