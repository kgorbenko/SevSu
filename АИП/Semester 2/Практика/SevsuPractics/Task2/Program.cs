using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = new int[EnterMatrixDimention('n', 150), EnterMatrixDimention('m', 100)];

            FillTheFile("File.txt", matrix.GetLength(0), matrix.GetLength(1));
            InputMatrixFromFile(ref matrix, "File.txt");

            PrintMatrix(matrix);
            Console.WriteLine("\n\n");

            Console.WriteLine("Enter colomn number to get vector");
            PrintVector(matrix, int.Parse(Console.ReadLine()));

            Console.WriteLine("\n\n");

            Console.WriteLine("Вектор с условием:");
            PrintCustomVector(matrix);
            Console.ReadLine();
        }

        //Ввод матрицы з файла
        static void InputMatrixFromFile(ref int[,] matrix, string path)
        {
            //Открытие файла с путем path для чтения
            StreamReader sr = new StreamReader(path);

            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                //Очередная строка преобразуется в массив строк,
                //каждая из которых содержит строковое представление
                //элементов матрицы
                var stringLine = sr.ReadLine().Split(" ");

                //Присваивание элементам очередной строки матрицы 
                //чисел, преобразованных из строк
                for (int m = 0; m < matrix.GetLength(1); m++)
                    matrix[n, m] = int.Parse(stringLine[m]);
            }
        }

        //Вывод матрицы в консоль
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        //Ввод одной размерности матрирцы с консоли
        static int EnterMatrixDimention(char c, int maxValue)
        {
            int dimention;

            //Цикл будет бесконечно спрашивать размерность из
            //консоли пока не получит подходящие данные
            while (true)
            {

                //В блоке try проверяются условия, ограничивающие
                //размерность
                try
                {
                    Console.WriteLine($"Введите {c}");
                    dimention = int.Parse(Console.ReadLine());
                    if (dimention < 1 || dimention > maxValue)
                        throw new Exception();
                }

                //Блок catch выполняется в случае ввода 
                //из консоли неправильных данных. Необходим для
                //перехода в начало цикла
                catch
                {
                    Console.WriteLine("Somethig went wrong. Try again");
                    continue;
                }

                //Выход из метода в случае правильного ввода
                return dimention;
            }
        }

        //Вывод вектора, содержащего определенный столбец данной матрицы,
        //в консоль
        static void PrintVector(int[,] matrix, int m)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                Console.Write($"{matrix[i, m - 1]} ");
        }

        //Создание и вывод вектора с заданными условиями
        static void PrintCustomVector(int[,] matrix)
        {
            //Создание переменной размером в количество
            //столбцов заданной матрицы
            int[] customVector = new int[matrix.GetLength(1)];

            //Заполнение вектора числами, не равными 0 и 1
            for (int i = 0; i < customVector.Length; i++)
                customVector[i] = -1;

            //Просмотр матрицы по столбцам
            for (int m = 0; m < matrix.GetLength(1); m++)
            {
                for (int n = 0; n < matrix.GetLength(0); n++)
                {

                    //Если i-й столбец содержит положительные числа,
                    //то i-му элементу приваивается 0, просматривание элементов
                    //прекращается
                    if (matrix[n, m] > 0)
                    {
                        customVector[m] = 0;
                        break;
                    }
                }

                //Если при просмотрении i-го стобца не было найдено 
                //положительных чисел, i-му элементу вектора присваивается 1
                if (customVector[m] != 0) customVector[m] = 1;
            }

            //Вывод в консоль полученного вектора
            for (int i = 0; i < customVector.Length; i++)
                Console.Write($"{customVector[i]} ");
        }

        //Заполнение файла случайными числами в форме матрицы через пробел
        static void FillTheFile(string path, int n, int m)
        {
            //Удаление файла с данным именем
            File.Delete(path);

            //Создание файловой переменной sw и открытие файла
            //с заданным именем для записи 
            StreamWriter sw = new StreamWriter(path);

            //Создание объекта класса Random для возможности
            //оперировать случайными числами
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //Random.Next - метод для генерации случайных чисел;
                    //аргумент метода - максимальное значение случайного числа
                    sw.Write($"{random.Next(-50, 150)} ");
                }
                sw.WriteLine();
            }
            //Dispose - метод для принудительной выгрузки буфера
            sw.Dispose();
        }
    }
}
