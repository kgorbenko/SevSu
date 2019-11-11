using System;
using static System.Console;
using static Lab8.TemperatureConversions;
using System.IO;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {

            int userOption = -1;

            do
            {
                try
                {
                    userOption = GetUserOption();

                    switch (userOption)
                    {
                        case 1:
                            var celsius = ToCelsius(GetDegrees());
                            WriteConversionToFile(celsius);
                            break;

                        case 2:
                            var fahrenheit = ToFahrenheit(GetDegrees());
                            WriteConversionToFile(fahrenheit);
                            break;

                        case 3:
                            return;

                        default:
                            WriteLine("Wrong input, enter any key to try again");
                            ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    continue;
                }
            }
            while (userOption != 3);
        }

        static int GetUserOption()
        {
            int? userOption = null;

            while (userOption == null)
            {
                Clear();
                WriteLine
                    ("What do you want to do?\n" +
                     "1 - Translate fahrenheit to celsium\n" +
                     "2 - Translate celsium to fahrenheit\n" +
                     "3 - Exit");

                userOption = int.Parse(ReadLine());
            }

            return (int)userOption;
        }

        static double GetDegrees()
        {
            double? degrees = null;

            while (degrees == null)
            {
                Clear();
                WriteLine("Enter degrees\n");
                degrees = double.Parse(ReadLine());
            }

            return (double)degrees;
        }

        static void WriteConversionToFile(double degrees)
        {
            var line = new string('\\', 13).Insert(0, $"{degrees:0.0000}");

            using (var writer = new StreamWriter(path:"File.txt", append:true))
            {
                writer.Write(line);
            }

            WriteLine("The result has been written to a file. Enter any key to continue");
        }
    }
}