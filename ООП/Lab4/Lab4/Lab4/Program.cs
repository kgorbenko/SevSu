using static System.Console;

namespace Lab4
{
    class Program
    {
        static void Main()
        {
            var truck = new Truck();
            var car = new Car();

            WriteLine("Car status:\n" + car.Status());
            WriteLine();
            WriteLine("Truck status:\n" + truck.Status());

            ReadLine();
        }
    }
}