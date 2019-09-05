using System;
using System.Linq;
using static System.Console;

namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CheckArrays();
            CheckStrings();
            CheckRegexes();
        }

        public static void CheckArrays()
        {
            WriteLine("Checking arrays task");

            const int M = 5;
            const int N = 10;
            var matrix = new int[M, N];
            var random = new Random();

            for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(100);

            Arrays.PrintMatrix(matrix);

            WriteLine("\nAverages:\n");
            foreach (var item in matrix.GetColumns().Select(x => Enumerable.Average(x)))
                Write($"{item} ");

            WriteLine($"\nColumn with maximal average: {Arrays.GetMaximalAverageColumn(matrix)}");
        }

        public static void CheckStrings()
        {
            WriteLine("Checking strings task");

            WriteLine("Enter your string:");
            var str = ReadLine();

            WriteLine("Words starting and ending with the same letter:");
            foreach (var word in Strings.GetWordsStartingAndEndingTheSameLetter(str))
                Write($"{word} ");
        }

        public static void CheckRegexes()
        {
            WriteLine("Checking regex task");

            var englishText    = "A text in English with some punctuation marks:.,;!?()";
            var notEnglishText = "Текст не на английском. Всякие знаки препинания:.?,!";

            WriteLine(englishText);
            WriteLine(Regexes.IsInEnglish(englishText));

            WriteLine(notEnglishText);
            WriteLine(Regexes.IsInEnglish(notEnglishText));
        }
    }
}