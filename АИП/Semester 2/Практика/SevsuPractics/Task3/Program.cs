using System;
using System.IO;

namespace Task3
{
    class Task3
    {
        static void Main()
        {
            int[] array = { 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 };
            foreach (int number in array) Console.Write($"{number} ");
            Console.WriteLine();
            Console.WriteLine($"Количество нулевых элементов(рекурсивно): {NumberOfZero(array, 0, array.Length - 1)}");
            Console.WriteLine($"Количество ненулевых элементов(итерационно): {NumberOfNonZero(array)}");
            Console.ReadLine();
        }

        static int NumberOfZero(int[] array, int first, int last)
        {
            //Нерекурсивная часть
            if (first == last) return IsZero(array[first]);

            //Рекурсивная часть
            if (first < last) return IsZero(array[first]) + NumberOfZero(array, first + 1, last);
            else return 0;
        }

        static int NumberOfNonZero(int[] array)
        {
            int amount = 0;
            foreach (int number in array)
            {
                if (number != 0) amount += 1;
            }
            return amount;
        }

        static int IsZero(int number)
        {
            if (number == 0) return 1;
            else return 0;
        }
    }
}
