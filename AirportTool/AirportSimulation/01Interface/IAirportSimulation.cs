using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public interface IAirportSimulation
    {
        IOutputAirport Simulate(IInputAirport input);
    }
}
