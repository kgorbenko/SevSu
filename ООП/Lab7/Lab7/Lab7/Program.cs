using System;
using static System.Console;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            var integralMatrix = FillMatrixWithRandomIntegral(new int[5, 5]);
            var floatingMatrix = FillMatrixWithRandomFloating(new double[5, 5]);
            var characterMatrix = FillMatrixWithRandomCharacter(new char[5, 5]);

            WriteLine("Integral");
            PrintMatrix(integralMatrix);

            WriteLine("Double");
            PrintMatrix(floatingMatrix);

            WriteLine("Char");
            PrintMatrix(characterMatrix);

            WriteLine("Integral swaped");
            PrintMatrix(Extend.SwapLines(integralMatrix, 0, 2));

            WriteLine("Real swaped");
            PrintMatrix(Extend.SwapLines(floatingMatrix, 0 ,2));

            WriteLine("Char swaped");
            PrintMatrix(characterMatrix.SwapLines(0, 2));

            ReadLine();
        }

        static void PrintMatrix(Array array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Write($"{array.GetValue(i, j)}\t");
                WriteLine();
            }
            WriteLine();
        }

        public static int[,] FillMatrixWithRandomIntegral(int[,] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.Next(100);
            }

            return array;
        }

        public static double[,] FillMatrixWithRandomFloating(double[,] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.NextDouble();
            }

            return array;
        }

        public static char[,] FillMatrixWithRandomCharacter(char[,] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var random = new Random();

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = (char)random.Next(33, 126);
            }

            return array;
        }
    }
}