using System;
using System.Collections.Generic;

namespace Testing.Model
{
    public static class ExtensionMethods
    {
        public static IEnumerable<int[]> GetColumns(this int[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (var j = 0; j < array.GetLength(1); j++)
            {
                var column = new int[array.GetLength(0)];

                for (var i = 0; i < array.GetLength(0); i++)
                    column[i] = array[i, j];

                yield return column;
            }
        }
    }
}