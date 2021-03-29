using System.Globalization;

namespace Custom.Internal
{
    internal static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}