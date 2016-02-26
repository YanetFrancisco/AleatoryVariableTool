using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AleatoryVariableTool;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            var aleatory = new ExponentialVariable() { L = 0.5};
            while (true)
            {
                Console.WriteLine(aleatory.GenerateValue());
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
