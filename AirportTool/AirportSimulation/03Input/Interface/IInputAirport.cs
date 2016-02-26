using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public interface IInputAirport
    {
        int Minutes { get; }

        IEnumerable<IAirplane> Airplanes { get; }
    }
}
