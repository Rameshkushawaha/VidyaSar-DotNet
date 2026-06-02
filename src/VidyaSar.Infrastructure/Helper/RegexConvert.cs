using System.Text.RegularExpressions;

namespace VidyaSar.Infrastructure.Helpers
{
    public static class RegexConvert
    {
        public static string ToAlphaNumericOnly(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }

        public static string ToAlphaOnly(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return Regex.Replace(input, "[^a-zA-Z]", "");
        }

        public static string ToNumericOnly(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return Regex.Replace(input, "[^0-9]", "");
        }
    }
}