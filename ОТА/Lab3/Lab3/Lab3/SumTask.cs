using System;

public static class SumTask
{
    public static bool Compose(int[] array, int V, out int[] counter, out int operations)
    {
        var N = array.Length;
        int maxN = (int)Math.Pow(2, N) - 1;
        counter = new int[N];
        operations = 0;

        for (int cnt = 1; cnt < maxN; cnt++)
        {
            int sum = 0; operations += 4;

            for (int i = 0; i < N; i++)
            {
                sum = sum + counter[i] * array[i];
                operations += 8;
            }
            operations += 1;

            if (sum == V)
            {
                operations += 2;
                return true;
            }
            operations += 1;

            var j = N - 1; operations += 2;
            while (counter[j] == 1 && j != 0)
            {
                counter[j] = 0;
                j = j - 1;
                operations += 8;
            }
            operations += 1;

            counter[j] = 1;
            cnt = cnt + 1;
            operations += 4;
        }

        return false;
    }
}