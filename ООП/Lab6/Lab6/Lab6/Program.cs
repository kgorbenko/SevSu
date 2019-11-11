using System;
using static System.Console;
    
namespace Lab6
{
    class Program
    {
        static void Main()
        {
            var rect1 = new Rectangle(5, 5);
            var rect2 = new Rectangle(10, 5);

            WriteLine($"!rect1:{!rect1}");
            WriteLine($"!rect2:{!rect2}");
            WriteLine($"-rect1:{-rect1}");
            WriteLine($"-rect2:{-rect2}");
            WriteLine($"rect1==rect2:{rect1 == rect2}");
            WriteLine($"rect1+rect2:{rect1 + rect2}");
            ReadLine();
        }
    }
}
