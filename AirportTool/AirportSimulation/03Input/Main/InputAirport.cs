using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public class InputAirport : IInputAirport
    {
        public int Minutes { get; set; }

        public IEnumerable<IAirplane> Airplanes { get; set; }
    }
}
