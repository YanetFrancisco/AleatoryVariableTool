using System;

namespace ProblemGenerator.DistributionChi
{
    /// <summary>
    /// Funcion de distribucion Gamma
    /// </summary>
    public class GammaFunction
    {
        private readonly double _k;

        public GammaFunction(double k)
        {
            _k = k;
        }

        public double Evaluate()
        {
            var r = _k-1;
            for (var i = 2; i < _k; i++)
                r *= _k-i;
            return r;
        }
        public double Evaluate(double step)
        {
            var x0 = 0.0;
            var result = 0.0;
            for (double i = 0;; i += step)
            {
                var x1 = x0 + step;
                double y0 = Gamma(x0);
                double y1 = Gamma(x1);
                result += ((y0 + y1)/2)*step;
                x0 += step;
                if (Math.Abs(y0 - y1) < 0.0000000000000005)
                    break;
            }
            return result;
        }
        private double Gamma(double x)
        {
            if (Math.Abs(x) < 0.0000000000000005 && _k - 1 < 0)
                return 0;
            return Math.Pow(x, _k - 1)*Math.Pow(Math.E, -x)+0;
        }
    }
}
