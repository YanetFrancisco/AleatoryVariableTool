using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AleatoryVariableTool
{
    public abstract class AleatoryVariableBase : IAleatoryVariable
    {
        protected AleatoryVariableBase()
        {
            UniformRandom = new Random();
        }

        protected Random UniformRandom;

        public abstract double GenerateValue();
    }
}
