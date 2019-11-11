using System;
using System.IO;
using System.Linq;
using static NumberOfAssignments;

public static class Program
{
    public static void Main()
    {
        using (var streamWriter = new StreamWriter("file.txt"))
        {
            var arraysWithRandomValues = new[]
            {
                CreateArrayWithRandomValues(100),
                CreateArrayWithRandomValues(500),
                CreateArrayWithRandomValues(1000),
            };

            foreach (var array in arraysWithRandomValues)
            {
                streamWriter.WriteLine($"Array with {array.Length} random values:");
                streamWriter.WriteLine($"Number of assignments: {array.GetNumberOfAssignments()}");
                streamWriter.WriteLine($"Mathematical expectation: {Math.Log(array.Length) + 0.57}");
            }
        }

        Console.Read();
    }
}