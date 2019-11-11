using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class GoodsGenerator
    {
        public static Goods GetGoodsItem(Random random)
            => new Goods { Name = "Name",
                           Price = random.Next(100),
                           ID = random.Next(50) };
    }
}
