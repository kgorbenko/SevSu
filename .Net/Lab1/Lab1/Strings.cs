using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public static class StringOperations
    {
        public static IEnumerable<string> GetWordsStartingAndEndingTheSameLetter(string line)
            => line.Split(" ").Where(x => x.First() == x.Last());
    }
}