using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Test
    {
        public string Name                 { get; set; }
        public int[,] Input                { get; set; }
        public IEnumerable<int[]> Expected { get; set; }
    }
}