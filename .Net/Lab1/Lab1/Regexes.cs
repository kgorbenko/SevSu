using System.Text.RegularExpressions;

namespace Lab1
{
    public static class RegexOperations
    {
        private static string englishRegexTemplate = @"^[A-Za-z0-9 .,!?:;()]+$";

        public static bool IsInEnglish(string test)
            => Regex.IsMatch(test, englishRegexTemplate);
    }
}