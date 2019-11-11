using System.IO;
using System.Collections.Generic;
using static System.Math;

public static class IntervalAnalysis
{
    public static IEnumerable<string> Analyse(int intervalStart, int intervalEnd, int inputKoefficient)
    {
        var phi = PI / inputKoefficient;

        for (var ii = intervalStart; ii <= intervalEnd; ii += 2)
        {
            var functionF = 27 * Pow(ii, Log(5, 2));
            var functionG = 37 * ii * ii * Log(ii);

            var ATg_FG = Atan(functionF / functionG);
            var ATg_GF = Atan(functionG / functionF);
            var pi = ATg_FG - ATg_GF;

            var deltaEstimation = phi - pi;
            var thetaEstimation = Abs(pi) - phi;
            var largeOEstimation = pi + phi;

            yield return $"ii={ii:0.00}; " +
                         $"FN={functionF:0.00}; " +
                         $"GN={functionG:0.00}; " +
                         $"ATg_FG={ATg_FG:0.00}; " +
                         $"ATg_GF={ATg_GF:0.00}; " +
                         $"pi={pi:0.00}; " +
                         $"Delta={deltaEstimation:0.00}; " +
                         $"Theta={thetaEstimation:0.00}; " +
                         $"OLarge={largeOEstimation:0.00};";
            
        }
    }
}