using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter unit's name");
            var unit = new Unit(Console.ReadLine());

            Console.WriteLine("Enter archer's name");
            var archer = new Archer(Console.ReadLine());

            Console.WriteLine($"Unit's properties:\n" +
                              $"Name = {unit.Name}\n" + 
                              $"Health = {unit.Health}\n" +
                              $"Damage = {unit.Damage}\n" + 
                              $"Status = {unit.Status()}\n");

            Console.WriteLine($"Archer's properties:\n" +
                              $"Name = {archer.Name}\n" +
                              $"Health = {archer.Health}\n" +
                              $"Damage = {archer.Damage}\n" + 
                              $"Range = {archer.Range}\n" + 
                              $"Status = {archer.Status()}\n" + 
                              $"Is alive = {archer.IsAlive()}");

            Console.ReadLine();
        }
    }
}