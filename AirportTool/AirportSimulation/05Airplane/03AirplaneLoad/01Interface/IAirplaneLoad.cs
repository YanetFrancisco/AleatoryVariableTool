﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public interface IAirplaneLoad : IAirplane
    {
        int Loadsize { get; }

        double ArrivalTime { get; set; }

        double TrackTime { get; set; }
    }
}
