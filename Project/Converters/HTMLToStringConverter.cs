using System.Text.RegularExpressions;

namespace Project.Converters
{
    public static partial class HTMLToStringConverter
    {
        public static string Convert(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                html = HtmlTagsAndNbspRegex().Replace(html, "").Trim();
            }
            return html;
        }

        [GeneratedRegex("<[^>]+>|&nbsp;")]
        private static partial Regex HtmlTagsAndNbspRegex();
    }
}