using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AleatoryVariableTool
{
    public class NormalVariable : AleatoryVariableBase
    {
        public NormalVariable()
        {
            M = 0;
            S2 = 1;            
        }

        public double M { get; set; }

        public double S2 { get; set; }

        public override double GenerateValue()
        {
            var primer = Math.Sqrt(-(2 * Math.Log(UniformRandom.NextDouble(), Math.E)));
            var sen = Math.Sin(2 * Math.PI * UniformRandom.NextDouble());
            return Math.Sqrt(S2) * primer * sen + M;
        }

        public override string ToString()
        {
            return "Normal";
        }
    }
}
