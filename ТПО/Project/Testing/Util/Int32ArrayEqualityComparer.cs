using System.Collections.Generic;
using System.Linq;

namespace Testing.Util
{
    internal class Int32ArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x == null || y == null) return false;

            return x.SequenceEqual(y);
        }

        public int GetHashCode(int[] obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    }
}