using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public class AirplaneLoad : Airplane, IAirplaneLoad
    {
        public AirplaneLoad(string model, bool isLoadAirplane, int maxLoadSize, int loadSize)
            : base(model, isLoadAirplane, maxLoadSize)
        {
            if (loadSize < 0)
            {
                throw new ArgumentOutOfRangeException("loadSize");
            }
            Loadsize = loadSize;
        }

        public int Loadsize { get; protected set; }

        public double ArrivalTime { get; set; }

        public double TrackTime { get; set; }
    }
}
