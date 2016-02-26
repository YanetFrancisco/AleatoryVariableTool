using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public class OutputAirport : IOutputAirport
    {
        public IEnumerable<double> EmptyTrackTime { get; set; }

        public int CountPassengers { get;  set; }

        public int LoadSize { get; set; }

        public IEnumerable<IAirplaneLoad> Airplanes { get; set; }
    }
}
