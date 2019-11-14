using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.UnitTesting
{
    public class UnitTestDto
    {
        public string Name { get; set; }
        public int[,] Input { get; set; }
        public IEnumerable<int[]> Expected { get; set; }
    }
}