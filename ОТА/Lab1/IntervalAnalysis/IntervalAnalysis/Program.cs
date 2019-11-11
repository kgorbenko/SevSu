using System;
using System.IO;
using static IntervalAnalysis;

public static class Program
{
    public static void Main()
    {
        using (var streamWriter = new StreamWriter("file.txt"))
        {
            foreach (var line in Analyse(20, 50, 32))
                streamWriter.WriteLine(line);

            foreach (var line in Analyse(100, 120, 24))
                streamWriter.WriteLine(line);

            foreach (var line in Analyse(500, 540, 18))
                streamWriter.WriteLine(line);

            foreach (var line in Analyse(1, 1000, 18))
                streamWriter.WriteLine(line);
        }

        Console.WriteLine("Enter any key to exit...");
        Console.ReadLine();
    }
}

