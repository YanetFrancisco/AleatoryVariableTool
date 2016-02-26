using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AleatoryVariableTool;

namespace AirportTool
{
    static class Extensor
    {
        const double porCientoMedia = 0.8;
        const double porCientoVar = 0.3;

        public static IAirplaneLoad CreateAirplaneLoad(this IAirplane airplane, NormalVariable distribution)
        {            
            distribution.M = porCientoMedia * airplane.MaxLoadSize;
            distribution.S2 = porCientoVar * airplane.MaxLoadSize;
            var carga = (int)Math.Max(distribution.GenerateValue(), 0);
            carga = Math.Min(airplane.MaxLoadSize, carga);
            return new AirplaneLoad(airplane.Model, airplane.IsLoadAirplane(), airplane.MaxLoadSize, carga);
        }

        private static int posMin;
        public static double Min(this IEnumerable<double> values)
        {
            posMin = 0;
            var i = 0;
            double min = double.MaxValue;
            foreach (var value in values)
            {
                if (value < min)
                {
                    min = value;
                    posMin = i;
                }
                i++;
            }
            return min;
        }

        public static double MinPos(this IEnumerable<double> values, out int pos)
        {
            var retorno = Min(values);
            pos = posMin;
            return retorno;
        }

        public static IEnumerable<int> NullTracks(this IEnumerable<IAirplaneLoad> tracks)
        {
            int count = 0;
            foreach (var item in tracks)
            {
                if (item == null) yield return count;
                count++;
            }
        }
    }
}
