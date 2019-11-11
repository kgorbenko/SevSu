using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public struct Goods : IComparable
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int ID { get; set; }

        public Goods(string name, int price, int id)
        {
            Name = name;
            Price = price;
            ID = id;
        }

        public int CompareTo(object obj)
        {
            var otherGoods = (Goods)obj;

            if (this.Price == otherGoods.Price) return 0;
            if (this.Price > otherGoods.Price) return 1;
            return -1;
        }

        public override string ToString()
            => Price.ToString();
    }
}
