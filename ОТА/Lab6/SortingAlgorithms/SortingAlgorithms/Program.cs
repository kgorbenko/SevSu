using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var array = new Goods[300].Select(x => GoodsGenerator.GetGoodsItem(random)).ToArray();

            foreach (var item in array)
                Console.Write($"{item} ");

            var timerStart = DateTime.Now;
            array = SortingAlgorithms.BubleSort(array);
            var timerEnd = DateTime.Now;

            Console.WriteLine();
            foreach (var item in array)
                Console.Write($"{item} ");

            Console.WriteLine($"\n{timerEnd - timerStart}");

            Console.ReadKey();
        }
    }
}
