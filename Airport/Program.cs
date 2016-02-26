using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AirportTool;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = args[0];
            if (!File.Exists(dir))
            {
                Console.WriteLine("El archivo no existe");
                return;
            }
            var textReader = new StreamReader(dir);
            var dias = int.Parse(textReader.ReadLine());
            List<IAirplane> aviones = new List<IAirplane>();
            while (!textReader.EndOfStream)
            {
                var linea = textReader.ReadLine();
                var split = linea.Split(' ');
                var esCarga = split[1].ToUpper() == "C";
                var carga = int.Parse(split[2]);
                aviones.Add(new Airplane(split[0], esCarga, carga));
            }
            var simulacion = new AirportSimulation();
            var salida = simulacion.Simulate(new InputAirport()
                                                 {
                                                     Minutes = dias * 24 * 60,
                                                     Airplanes = aviones,
                                                 });
            Console.WriteLine("Introduzca la dirección del archivo de salida");
            var dirSalida = Console.ReadLine();
            var textWriter = new StreamWriter(dirSalida);
            int i = 0;
            foreach (var emptyTime in salida.EmptyTrackTime)
            {
                textWriter.WriteLine("Pista {0}: {1} min", i, emptyTime);
                i++;
            }
            textWriter.WriteLine("Cantidad total de pasajeros: {0}", salida.CountPassengers);
            textWriter.WriteLine("Cantidad de carga: {0}", salida.LoadSize);
            foreach (var airplaneLoad in salida.Airplanes)
            {
                textWriter.WriteLine("Avión {0} con {1}% de carga, tiempo de espera {2} en min", airplaneLoad.Model,
                                     airplaneLoad.Loadsize * 1.0 /airplaneLoad.MaxLoadSize*100,
                                     airplaneLoad.TrackTime - airplaneLoad.ArrivalTime);
            }
            textWriter.Close();
        }
    }
}
