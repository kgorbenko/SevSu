using static System.Console;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            WriteLine("Enter archer's name:");
            Unit person1 = new Archer(ReadLine());
            WriteLine(person1.Status());

            WriteLine("Enter swordsman's name:");
            Unit person2 = new Swordsman(ReadLine());
            WriteLine(person2.Status());

            WriteLine("Enter shield bearer's name:");
            Unit person3 = new ShieldBearer(ReadLine());
            WriteLine(person3.Status());

            ShieldBearer test1 = new ShieldBearer("test");
            WriteLine(test1.Status());

            ShieldBearer test2 = new ShieldBearer("test");
            WriteLine(test2.Status());

            WriteLine("Enter another shield bearer's name");
            Swordsman person4 = new ShieldBearer(ReadLine());
            WriteLine(person4.Status());

            WriteLine("Press enter to exit");

            ReadLine();
        }
    }
}
