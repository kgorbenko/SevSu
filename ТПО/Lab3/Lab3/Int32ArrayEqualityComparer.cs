using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    class Int32ArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(int[] obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    }
}