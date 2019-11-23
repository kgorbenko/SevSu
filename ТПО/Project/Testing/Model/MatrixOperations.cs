using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing.Model
{
    public static class MatrixOperations
    {
        public static IEnumerable<int> GetSumsOfPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Only square martixes are allowed.");
            }

            return matrix
                    .GetColumns()
                    .Select(column => column.Where(x => x > 0).Sum());
        }
    }
}