using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportTool
{
    public class Airplane : IAirplane
    {
        protected string model;
        protected bool isLoadAirplane;
        protected int maxLoadSize;

        public Airplane(string model, bool isLoadAirplane, int maxLoadSize)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            if (maxLoadSize < 1)
            {
                throw new ArgumentOutOfRangeException("maxLoadSize");
            }
            this.model = model;
            this.isLoadAirplane = isLoadAirplane;
            this.maxLoadSize = maxLoadSize;
        }

        public string Model
        {
            get { return model; }
        }

        public bool IsLoadAirplane()
        {
            return isLoadAirplane;
        }

        public int MaxLoadSize
        {
            get { return maxLoadSize; }
        }
    }
}
