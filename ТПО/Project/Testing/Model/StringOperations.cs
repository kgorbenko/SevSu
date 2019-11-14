using System;

namespace Testing.Model
{
    public static class StringOperations
    {
        public static string RemoveAt(string source, int position)
        {
            if (source == null) throw new ArgumentNullException(source);

            return source.Remove(position, 1);
        }
    }
}