using System;
using System.IO;

namespace TestingLab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[,]
            {
                {1, 2, 3},
                {3, -4, 8},
                {15, 25, 3},
                {132, 12, 3}
            };

            for (var i = 0; i < matrix.GetLength(0); i++){
                for (var j = 0; j < matrix.GetLength(1); j++){
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            try{
                foreach (var item in MatrixOperations.GetSumOfColumnsWithoutNegativeElements(matrix)){
                    Console.Write($"{item} ");
                }
            }
            catch (ArgumentException e){
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
            
            /*
            const string filePath = "file.txt";
            var streamReader      = new StreamReader(filePath);
            var fileOperations    = new FileOperations(streamReader);

            Console.WriteLine(fileOperations.ReverseEveryTwoWords());
            */
        }
    }
}