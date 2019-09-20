using System.Linq;
using System.Collections.Generic;

public static class StringOperations
{
    public static string RemoveAt(string source, int position) => source.Remove(position, 1);
}