using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AleatoryVariableTool
{
    public class ExponentialVariable : AleatoryVariableBase
    {
        public ExponentialVariable()
        {
            L = 1;
        }

        public double L { get; set; } 

        public override double GenerateValue()
        {
            return -(1/L*Math.Log(UniformRandom.NextDouble(), Math.E));
        }

        public override string ToString()
        {
            return "Exponencial";
        }
    }
}
