using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WhileSyntaxChecker
{
    public static class TemplateChecker
    {
        static string pattern = @"[A-Za-z_][\w_]*\([A-Za-z_][\w_]*(<=|>=|==|>|<)[0-9].*\)\{[A-Za-z_][\w_]*\+=[0-9].*;[A-Za-z_][\w_]*:=[A-Za-z_][\w_]*;\}";

        public static bool TryCheck(string operation, out string message)
        {
            if (string.IsNullOrWhiteSpace(operation)) throw new ArgumentNullException(nameof(operation));
            if (operation.Length > 80) throw new ArgumentException("Operator length should be less than 80");

            var errors = new List<string>();
            operation = operation.Replace(" ", string.Empty);
            var namesAndNumbers = operation.Split(new[] { " ", "(", ")", "{", "}", ";", "<", ">", "=", "+", "-", "/", "*", ":" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!Regex.IsMatch(operation, pattern))
                errors.Add("Entered operation doesn't match the required template");

            foreach (var identifier in namesAndNumbers)
            {
                if (Regex.IsMatch(identifier, @"^[0-9].*$"))
                {
                    if (!IsNumberValid(identifier))
                        errors.Add($"number {identifier} is not valid");
                }

                else if (!Regex.IsMatch(identifier, @"^[A-Za-z_][A-Za-z0-9_]*$"))
                    errors.Add($"Name {identifier} is not valid");
            }

            if (!AreNamesMatch(namesAndNumbers))
                errors.Add($"Names {namesAndNumbers[1]}, {namesAndNumbers[3]} and {namesAndNumbers[6]} should match");

            if (namesAndNumbers.First() != "while")
                errors.Add("Operator should be while loop");

            if (operation.Count(x => x == '(') != operation.Count(x => x == ')'))
                errors.Add("Broken parentheses balance");

            if (operation.Count(x => x == '{') != operation.Count(x => x == '}'))
                errors.Add("Broken braces balance");

            message = GetMessage(errors);
            return errors.Count() == 0;

            bool AreNamesMatch(string[] names)
            {
                return !(names[1] != names[3] ||
                         names[3] != names[6] ||
                         names[1] != names[6]);
            }

            bool IsNumberValid(string number)
            {
                return int.TryParse(number, out _);
            }

            string GetMessage(List<string> partsOfMessage)
            {
                if (errors.Count() == 0) return "Entered operator seems to be valid!";

                var line = "There has been some issues:\n";
                foreach (var part in partsOfMessage) line += $"{part};\n";

                return line;
            }
        }
    }
}