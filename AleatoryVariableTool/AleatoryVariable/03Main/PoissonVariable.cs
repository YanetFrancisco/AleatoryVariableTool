using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AleatoryVariableTool
{
    public class PoissonVariable : AleatoryVariableBase
    {
        public PoissonVariable()
        {
            l = 15;
            exponentialVariable = new ExponentialVariable();
            N = 1;
        }

        protected double l;

        protected double n;

        public double L
        {
            get { return l; }

            set 
            { 
                exponentialVariable.L = value * n;
                l = value;
            }
        }

        public double N { get { return n; } set { n = value; exponentialVariable.L = l * n; } }

        private readonly ExponentialVariable exponentialVariable;

        public override double GenerateValue()
        {
            return Proceso();
        }

        private int Proceso()
        {
            var t = 0.0;
            var i = 0;
            do
            {
                t += exponentialVariable.GenerateValue();
                i++;
            } while (t <= N);
            return i;
        }

        private int Factorial(int n)
        {
            if (n == 0)
                return 1;
            return Factorial(n - 1);
        }

        public override string ToString()
        {
            return "Poisson";
        }
    }
}
