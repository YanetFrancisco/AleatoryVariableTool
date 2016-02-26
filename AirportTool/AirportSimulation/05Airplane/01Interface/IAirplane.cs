using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public interface IAirplane
    {
        string Model { get; }

        bool IsLoadAirplane();

        int MaxLoadSize { get; }        
    }
}
