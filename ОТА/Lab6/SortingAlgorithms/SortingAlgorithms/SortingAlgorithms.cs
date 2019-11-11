using System;

namespace SortingAlgorithms
{
    public static class SortingAlgorithms
    {
        public static Goods[] InsertionSort(Goods[] sequence)
        {
            var N = sequence.Length;

            for (int i = 0; i < N; i++)
            {
                Goods x = sequence[i];

                int j;
                for (j = i - 1; j >= 0 && sequence[j].CompareTo(x) > 0; j--)
                    sequence[j + 1] = sequence[j];

                sequence[j + 1] = x;
            }

            return sequence;
        }

        public static Goods[] BubleSort(Goods[] sequence)
        {
            var N = sequence.Length;

            for (int i = 0; i < N - 1; i++)
                for (int j = i + 1; j < N; j++)
                    if (sequence[i].CompareTo(sequence[j]) > 0)
                    {
                        var temp = sequence[i];
                        sequence[i] = sequence[j];
                        sequence[j] = temp;
                    }

            return sequence;
        }

        public static void QuickSort(ref Goods[] arr, int first, int last)
        {
            Goods p = arr[(last - first) / 2 + first];
            int i = first, j = last;

            while (i <= j)
            {
                while (arr[i].CompareTo(p) < 0) ++i;
                while (arr[j].CompareTo(p) > 0) --j;
                if (i <= j)
                {
                    Goods temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }

            if (j > first) QuickSort(ref arr, first, j);
            if (i < last) QuickSort(ref arr, i, last);
        }
    }
}