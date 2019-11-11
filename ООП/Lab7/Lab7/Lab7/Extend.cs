using System;

namespace Lab7
{
    public static class Extend
    {
        public static Array SwapLines(this Array array, int i, int j)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (i == j) throw new InvalidOperationException("Swapping lines should be different");

            var temp = array.GetValue(0, 0);

            for (int column = 0; column < array.GetLength(0); column++)
            {
                temp = array.GetValue(i, column);
                array.SetValue(array.GetValue(j, column), i, column);
                array.SetValue(temp, j, column);
            }

            return array;
        }

        public static T[,] SwapLines<T>(T[,] array, int i, int j)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (i == j) throw new InvalidOperationException("Swapping lines should be different");

            var temp = array[0, 0];

            for (int column = 0; column < array.GetLength(0); column++)
            {
                temp = array[i, column];
                array[i, column] = array[j, column];
                array[j, column] = temp;
            }

            return array;
        }
    }
}