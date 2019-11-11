using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var arrayLength = 12;
        var maxValue = 90;
        var sum = 29;
        var path = "file.txt";

        for (int i = 1; i <= 10; i++)
        {
            var array = new int[arrayLength].Select(x => random.Next(maxValue)).ToArray();
            array[11] = 29;

            using (var streamWriter = new StreamWriter(path, append:true))
            {
                foreach (var value in array)
                    streamWriter.Write($"{value} ");

                if (SumTask.Compose(array, sum, out var counter, out var operations))
                    streamWriter.WriteLine("\nSum has been composed");
                else streamWriter.WriteLine("\nSum has not been composed");

                foreach (var value in counter)
                    streamWriter.Write($"{value} ");

                streamWriter.WriteLine($"\noperations - {operations}\n");
            }
        }
    }
}
