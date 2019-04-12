using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HolidayGrapper.Helpers
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($@"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
    public static class UrlValidator
    {
        public static Regex UrlRegex { get; } = new Regex(@"^https?:\/\/www.officeholidays.com\/countries\/(.*)\/(\d{4})(.php)?", RegexOptions.Compiled);

        public static bool IsValidUrl(string text, out string country, out int year)
        {
            var match = UrlRegex.Match(text);
            country = string.Empty;
            year = -1;

            if (!match.Success)
                return false;

            foreach (var element in match.Groups[1].Value.Split(new char[] {'-', '_'}))
                country += element.FirstCharToUpper();
            
            int.TryParse(match.Groups[2].Value, out year);
            return true;
        }
    }
}