using System.Collections.Generic;

namespace Testing.UnitTesting
{
    public class GetColumnsUnitTestDto
    {
        public string Name { get; set; }
        public int[,] Input { get; set; }
        public IEnumerable<int[]> Expected { get; set; }
    }
}