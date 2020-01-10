using System;
using Testing.Util;
using Testing.UnitTesting;
using System.IO;
using System.Linq;
using Testing.IntegrationTesting;
using Testing.Model;

namespace Testing
{
    public static class Program
    {
        private enum Labs
        {
            Lab3,
            Lab4,
            Lab6
        }

        public static void Main(string[] args)
        {
            const Labs option = Labs.Lab6;

            switch (option)
            {
                case Labs.Lab3:
                {
                    var fileLogger = new FileLogger(new StreamWriter(UnitTestConstants.Path));
                    var testEngine = new GetColumnsUnitTestEngine(fileLogger, UnitTestConstants.TestSuite);
                    testEngine.Run();
                    break;
                }
                case Labs.Lab4:
                {
                    var fileLogger = new FileLogger(new StreamWriter(IntegrationTestConstants.Path));
                    var testEngine = new GetColumnsUnitTestEngineIntegrationTestEngine(fileLogger);
                    testEngine.Run();
                    break;
                }
                case Labs.Lab6:
                {
                    var matrix = CreateMatrix();
                    var sumsOfPositiveElementsInColumns = MatrixOperations.GetSumsOfPositiveElementsInColumns(matrix);

                    Console.WriteLine(string.Join(" " , sumsOfPositiveElementsInColumns.Select(x => x.ToString())));

                    break;
                }
            }
        }

        private static int[,] CreateMatrix()
        {
            var random = new Random();
            var matrix = new int[1000, 1000];

            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    matrix[i, j] = Enumerable.Range(0, random.Next(1, 1000)).Select(x => random.Next(int.MinValue, 1000))
                        .Last();
                }
            }

            return matrix;
        }
    }
}