using System;
using System.Linq;

public static class NumberOfAssignments
{
    const int arrayMaxValue = 750;

    public static int[] CreateArrayWithRandomValues(int arrayLength)
    {
        var randomGenerator = new Random();

        return new int[arrayLength].Select(x => randomGenerator.Next(arrayMaxValue)).ToArray();
    }

    public static int GetNumberOfAssignments(this int[] array)
    {
        var minimalValue       = array[0];
        var assignmentsCounter = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minimalValue)
            {
                minimalValue = array[i];
                assignmentsCounter += 1;
            }
        }

        return assignmentsCounter;
    }
}