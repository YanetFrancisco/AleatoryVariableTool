using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public interface IOutputAirport
    {
        IEnumerable<double> EmptyTrackTime { get; }

        int CountPassengers { get; }

        int LoadSize { get; }

        IEnumerable<IAirplaneLoad> Airplanes { get; }
    }
}
