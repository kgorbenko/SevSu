using System;
using System.Linq;

namespace Lab1
{
    public class Arrays
    {
        public static int GetMaximalAverageColumn(int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException($"{nameof(matrix)} instance was null");

            var columnsAverages = matrix
                                    .GetColumns()
                                    .Select(x => Enumerable.Average(x))
                                    .ToArray();

            return Array.IndexOf(columnsAverages, Enumerable.Max(columnsAverages));
        }

        public static void PrintMatrix(int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException($"{nameof(matrix)} instance was null");

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }
        }
    }
}