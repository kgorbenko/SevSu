using System;
using System.IO;

namespace TestingLab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "file.txt";
            var streamReader      = new StreamReader(filePath);
            var fileOperations    = new FileOperations(streamReader);

            Console.WriteLine(fileOperations.ReverseEveryTwoWords());
        }
    }
}