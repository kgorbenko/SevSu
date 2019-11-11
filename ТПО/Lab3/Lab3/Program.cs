using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var fileLogger = new FileLogger(new StreamWriter(path, append:true));
            var testEngine = new TestEngine(fileLogger, TestSuite);
            testEngine.TestEquality();
        }

        private static string path = "file.txt";

        private static IEnumerable<Test> TestSuite = new[]
        {
            new Test {
                Name     = "Single item",
                Input    = new[,] { { 3 } },
                Expected = new[] { new[] { 3 } }.AsEnumerable()
            },
            new Test {
                Name = "Multiple items in square matrix",
                Input = new[,]
                {
                    { 15, 10, 36 },
                    { 23,  0, 14 },
                    { 62, 15, 35 }
                },
                Expected = new[]
                {
                    new[] { 15, 23, 62 },
                    new[] { 10,  0, 15 },
                    new[] { 36, 14, 35 }
                }.AsEnumerable()
            },
            new Test {
                Name = "Multiple items in non-square matrix",
                Input = new[,]
                {
                    { 13,  2, 14, 16,  46 },
                    {  0, 54, -2,  9, -14 },
                    { 62,  0, 21, 15,   2 },
                    { 64,  0, 11,  2, 523 }
                },
                Expected = new[]
                {
                    new[] { 13,   0, 62,  64 },
                    new[] {  2,  54, -2,   9 },
                    new[] { 14,  -2, 21,  11 },
                    new[] { 16,   9, 15,   2 },
                    new[] { 46, -14,  2, 523 }
                }.AsEnumerable()
            },
        };
    }
}
