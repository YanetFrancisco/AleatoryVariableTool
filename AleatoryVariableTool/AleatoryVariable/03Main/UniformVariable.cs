using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AleatoryVariableTool
{
    public class UniformVariable : AleatoryVariableBase
    {
        public UniformVariable()
        {
            A = 0;
            B = 1;
        }

        public double A { get; set; }

        public double B { get; set; }

        public override double GenerateValue()
        {
            return A + (B - A)*UniformRandom.NextDouble();
        }

        public override string ToString()
        {
            return "Uniforme";
        }
    }
}
