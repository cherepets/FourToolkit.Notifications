using System.Text.RegularExpressions;

namespace FourToolkit.Notifications.Extensions
{
    public static class StringExt
    {
        private const string Expression = "\\[[A-Za-z][A-Za-z0-9]+\\]";

        public static bool IsBindingDefenition(this string s)
            => s == null ? false : new Regex(Expression).IsMatch(s);

        public static string ToBindingDefenition(this string s)
            => $"[{s}]";
    }
}
