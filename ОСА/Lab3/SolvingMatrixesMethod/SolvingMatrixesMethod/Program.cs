using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SolvingMatrixesMethod
{
    static class Program
    {
        static void Main(string[] args)
        {
            var matrixes = new List<double[,]>
            {
                EnterMatrix(5, 4, 0),
                EnterMatrix(4, 5, 1),
                EnterMatrix(3, 4, 2)
            };

            var levels = new List<double[]>
            {
                new double[4] { 0.4, 0.2, 0.3, 0.1 },
                new double[5],
                new double[4],
                new double[3]
            };

            for (var level = 1; level < levels.Count(); level++)
            {
                var totalSum = 0.0;

                for (var item = 0; item < levels[level].Length; item++)
                {
                    var sumOfItem = 0.0;

                    for (var k = 0; k < matrixes[level - 1].GetLength(1); k++)
                        if (!double.IsNaN(matrixes[level - 1][item, k]))
                            sumOfItem += matrixes[level - 1][item, k] * levels[level - 1][k];

                    levels[level][item] = sumOfItem;
                    totalSum += sumOfItem;
                }

                for (var item = 0; item < levels[level].Length; item++)
                    levels[level][item] = levels[level][item] / totalSum;
            }

            foreach (var level in levels)
            {
                foreach (var item in level)
                    Console.Write($"{item:0.000} ");

                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static double[,] EnterMatrix(int rows, int columns, int level)
        {
            var file = new StreamReader($"{level}.txt");
            var matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var row = file
                           .ReadLine()
                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(x => x == "-" ? double.NaN : double.Parse(x))
                           .ToArray();

                if (row.Length != columns)
                    throw new InvalidOperationException("Invalid items number in column");

                for (var j = 0; j < columns; j++)
                    matrix[i, j] = row[j];
            }

            return matrix;
        }
    }
}
