using System;
using System.Collections.Generic;

namespace ProblemGenerator.DistributionChi
{
    public class ChiSquareTable
    {
        /// <summary>
        /// La cantidad de cifras decimales que se manipularan
        /// </summary>
        public static int _decimalplaces = 5;
        static Dictionary<KeyValuePair<double, int>, double> MemoizedResults =
            new Dictionary<KeyValuePair<double, int>, double>(11);

        private static Dictionary<KeyValuePair<double, int>, double> MemoizedPercentil =
            new Dictionary<KeyValuePair<double, int>, double>(11);
        public static double GetValue(double x, int k, double step = 0.05)
        {
            double value = 0.0;
            if (MemoizedResults.TryGetValue(new KeyValuePair<double, int>(Math.Round(x, _decimalplaces), k), out value))
                return value;
            var chi = new ChiSquareFunction(k);
            var x0 = 0.0;
            var result = 0.0;
            for (double i = 0; i < x; i += step)
            {
                var x1 = x0 + step;
                var y0 = chi.Evaluate(x0);
                var y1 = chi.Evaluate(x1);
                result += ((y0 + y1) / 2) * step;
                x0 += step;
            }
            result += (chi.Evaluate(x0) + chi.Evaluate(x)) / 2 * (Math.Abs(x - x0));

            MemoizedResults.Add(new KeyValuePair<double, int>(Math.Round(x, _decimalplaces), k), result);

            return result;
        }

        /// <summary>
        /// Computes the x percentil of the X square distribution
        /// </summary>
        /// <param name="percentil">percentil</param>
        /// <param name="degrees"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static double GetPercentil(double percentil, int degrees, double step = 0.05)
        {
            double value = 0.0;
            if (MemoizedPercentil.TryGetValue(new KeyValuePair<double, int>(Math.Round(percentil, _decimalplaces), degrees), out value))
                return value;

            var result = 0.0;
            var distribution = GetValue(result, degrees,step);

            while (distribution < percentil)
            {
                result += step;
                distribution = GetValue(result, degrees,step);

            }
            var nuevovalor = new KeyValuePair<double, int>(Math.Round(distribution, _decimalplaces), degrees);
            if (!MemoizedPercentil.ContainsKey(nuevovalor))
                MemoizedPercentil.Add(nuevovalor, result);

            return result;
        }
    }
    //public class ChiSquareTable
    //{
    //    public static double GetValue(double x, int k, double step = 0.05)
    //    {
    //       // if (k <= 1)
    //            //throw new InvalidOperationException("K>1");
    //        var chi = new ChiSquareFunction(k,step);
    //        var x0 = 0.0;
    //        var result = 0.0;
    //        for (double i = 0; i < x; i += step)
    //        {
    //            var x1 = x0 + step;
    //            var y0 = chi.Evaluate(x0);
    //            var y1 = chi.Evaluate(x1);
    //            result += ((y0 + y1)/2)*step;
    //            x0 += step;
    //        }
    //        result += (chi.Evaluate(x0) + chi.Evaluate(x))/2*(Math.Abs(x - x0));
    //        return result;
    //    }

    //}
}

