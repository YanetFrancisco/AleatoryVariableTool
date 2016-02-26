using System;

namespace ProblemGenerator.DistributionChi
{
    /// <summary>
    /// Funcion de distribucion X-Cuadrado
    /// </summary>
    public class ChiSquareFunction
    {
        private readonly int _k;
        private readonly GammaFunction _gamma;
        private readonly double _g ;

        public ChiSquareFunction(int k,double step=0.05)
        {
            _k = k;
            _gamma = new GammaFunction(k/2.0);
            _g = k%2==0 ? _gamma.Evaluate() : _gamma.Evaluate(step);
        }
        /// <summary>
        /// Evalua la funcion Xi-Cuadrado
        /// </summary>
        /// <param name="x">Punto de evaluacion</param>
        public double Evaluate(double x)
        {
            if (x <= 0)
                return 0;
            return (Math.Pow(x, (_k / 2.0) - 1.0) * Math.Pow(Math.E, -x / 2.0)) / (Math.Pow(2.0, _k / 2.0) * _g);
        }
    }
}
