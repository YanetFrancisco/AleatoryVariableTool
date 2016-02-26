using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AleatoryVariableTool;

namespace AirportTool
{
    public class AirportSimulation : IAirportSimulation
    {
        #region Variables de tiempo

        protected double SystemTime;

        protected double ArrivalTime;

        protected double[] ProcessTime;

        protected double[] FixedTime;

        protected double[] DepartureTime;

        protected double StopTime;

        #endregion

        #region Variables contadoras

        protected double[] TimeEmptyTrack;

        protected double[] TimeDepartuteTime;

        protected int QuantityPassengers;

        protected int CountLoads;

        protected IList<IAirplaneLoad> Airplanes;

        #endregion

        #region Variables de estado

        protected IAirplaneLoad[] Tracks;

        protected Queue<IAirplaneLoad> QueueArrival;

        #endregion

        #region Distribuciones

        private ExponentialVariable exponentialVariable;
        private PoissonVariable poissonVariable;
        private NormalVariable normalVariable;
        private Random aleatory;

        #endregion

        private const double infinity = double.PositiveInfinity;

        public int CountTracks { get; set; }

        public AirportSimulation()
        {
            CountTracks = 5;
        }

        protected virtual void InitializeSystem(IInputAirport entrada)
        {
            ProcessTime = new double[CountTracks];
            TimeDepartuteTime = new double[CountTracks];
            FixedTime = new double[CountTracks];
            DepartureTime = new double[CountTracks];
            TimeEmptyTrack = new double[CountTracks];
            Airplanes = new List<IAirplaneLoad>();
            Tracks = new IAirplaneLoad[CountTracks];
            QueueArrival = new Queue<IAirplaneLoad>();
            aleatory = new Random();
            exponentialVariable = new ExponentialVariable();
            poissonVariable = new PoissonVariable();
            normalVariable = new NormalVariable();
            SystemTime = 0;
            InitializeArray(ProcessTime, infinity);
            InitializeArray(FixedTime, infinity);
            InitializeArray(DepartureTime, infinity);
            InitializeArray(TimeEmptyTrack, 0);
            InitializeArray(TimeDepartuteTime, 0);
            StopTime = entrada.Minutes;
            QuantityPassengers = 0;
            CountLoads = 0;
            ArrivalTime = GenerateTime();
        }

        private IAirplaneLoad GenerateLoads(IAirplane airplane)
        {
            return airplane.CreateAirplaneLoad(normalVariable);
        }

        private double GenerateTimeProcess(IAirplaneLoad airplaneLoad)
        {
            var l = 0.0;
            var carga = airplaneLoad.Loadsize;
            if (carga >= 0 && carga < 150)
            {
                l = 20;
            }
            else if ((airplaneLoad.IsLoadAirplane() && carga >= 150 && carga < 300) || (!airplaneLoad.IsLoadAirplane() && carga >= 150 && carga < 500))
            {
                l = 30;
            }
            else if ((airplaneLoad.IsLoadAirplane() && carga >= 300 && carga <= 500) || (!airplaneLoad.IsLoadAirplane() && carga >= 500 && carga <= 750))
            {
                l = 45;
            }
            exponentialVariable.L = l;
            var variable = 0.0;
            do
            {
                variable = exponentialVariable.GenerateValue();
            } while (double.IsInfinity(variable));
            return variable;
        }

        private double GenerateTime()
        {
            var countDays = (int)(SystemTime / (24 * 60));
            var currentTime = SystemTime - (countDays * 24 * 60);
            if (6 * 60 <= currentTime && currentTime <= 14 * 60)
            {
                poissonVariable.L = 7;
                return poissonVariable.GenerateValue();
            }
            if (18 * 60 <= currentTime && currentTime < 22 * 60)
            {
                poissonVariable.L = 10;
                return poissonVariable.GenerateValue();
            }
            if ((22 * 60 <= currentTime && currentTime < 24 * 60) || (0 <= currentTime && currentTime < 6 * 60))
            {
                poissonVariable.L = 20;
                return poissonVariable.GenerateValue();
            }
            throw new Exception("No se reciben aviones a esta hora");
        }

        private double GenerateDepartureTime()
        {
            exponentialVariable.L = 15;
            return exponentialVariable.GenerateValue();
        }

        private double GenerateFixedTime()
        {
            exponentialVariable.L = 90;
            return exponentialVariable.GenerateValue();
        }

        private bool GenerateBreak()
        {
            return aleatory.Next(0, 5) == 0;
        }

        public IAirplane GenerateAirplane(IEnumerable<IAirplane> airplane)
        {
            return airplane.ToList<IAirplane>()[aleatory.Next(0, airplane.Count())];
        }

        private void InitializeArray(double[] array, double valor)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = valor;
            }
        }

        private void GenerateNewArrivalTime()
        {
            var tiempo = GenerateTime();
            ArrivalTime = SystemTime + tiempo;
            var countDays = (int)(ArrivalTime / (24 * 60));
            var currentTime = ArrivalTime - (countDays * 24 * 60);
            if (2 * 60 < currentTime && currentTime < 18 * 60)
            {
                ArrivalTime = (countDays * 24 * 60) + 18 * 60;
            }
        }

        public virtual IOutputAirport Simulate(IInputAirport input)
        {
            InitializeSystem(input);
            while (ArrivalTime < StopTime || Tracks.Any(x => x != null))
            {
                int posProcessTime;
                var minProcessTime = ProcessTime.MinPos(out posProcessTime);
                int posFixed;
                var minFixedTime = FixedTime.MinPos(out posFixed);
                int posDeparture;
                var minDepartureTime = DepartureTime.MinPos(out posDeparture);
                if (ArrivalTime <= minProcessTime && ArrivalTime <= minFixedTime && ArrivalTime <= minDepartureTime && ArrivalTime < StopTime)
                {
                    // Caso de una llegada
                    Arrival(input);
                    continue;
                }
                if ((minProcessTime < ArrivalTime || ArrivalTime >= StopTime) && minProcessTime <= minFixedTime && minProcessTime <= minDepartureTime)
                {
                    //Caso de procesar carga
                    ProcessLoad(posProcessTime);
                    continue;
                }
                if ((minFixedTime < ArrivalTime || ArrivalTime >= StopTime) && minFixedTime < minProcessTime && minFixedTime <= minDepartureTime)
                {
                    //Caso de una rotura
                    Fixed(posFixed);
                    continue;
                }
                if ((minDepartureTime < ArrivalTime || ArrivalTime >= StopTime) && minDepartureTime < minProcessTime && minDepartureTime < minFixedTime)
                {
                    //Caso de procesar un despegue
                    Departure(posDeparture);
                }
            }
            return new OutputAirport()
                       {
                           EmptyTrackTime = TimeEmptyTrack,
                           CountPassengers = QuantityPassengers,
                           LoadSize = CountLoads,
                           Airplanes = Airplanes
                       };
        }

        private void Arrival(IInputAirport input)
        {
            SystemTime = ArrivalTime;
            GenerateNewArrivalTime();
            var arrivalAirplane = GenerateAirplane(input.Airplanes);
            var arrivalAirplaneLoad = GenerateLoads(arrivalAirplane);
            arrivalAirplaneLoad.ArrivalTime = SystemTime;
            Airplanes.Add(arrivalAirplaneLoad);
            if (arrivalAirplaneLoad.IsLoadAirplane())
                CountLoads += arrivalAirplaneLoad.Loadsize;
            else QuantityPassengers += arrivalAirplaneLoad.Loadsize;
            var emptyTracks = Tracks.NullTracks();
            if (emptyTracks.Count() > 0)
            {                
                int newTrack = aleatory.Next(0, emptyTracks.Count());
                Tracks[newTrack] = arrivalAirplaneLoad;
                TimeEmptyTrack[newTrack] += SystemTime - TimeDepartuteTime[newTrack];                
                arrivalAirplaneLoad.TrackTime = arrivalAirplaneLoad.ArrivalTime;
                ProcessTime[newTrack] = SystemTime + GenerateTimeProcess(arrivalAirplaneLoad);
            }
            else
            {
                QueueArrival.Enqueue(arrivalAirplaneLoad);
            }
        }

        private void ProcessLoad(int pos)
        {
            SystemTime = ProcessTime[pos];
            ProcessTime[pos] = infinity;
            if (GenerateBreak())
            {
                var tiempo = GenerateFixedTime();
                FixedTime[pos] = SystemTime + tiempo;
            }
            else
            {
                var tiempo = GenerateDepartureTime();
                DepartureTime[pos] = SystemTime + tiempo;
            }
        }

        private void Fixed(int pos)
        {
            SystemTime = FixedTime[pos];
            FixedTime[pos] = infinity;
            var tiempo = GenerateDepartureTime();
            DepartureTime[pos] = SystemTime + tiempo;
        }

        private void Departure(int pos)
        {
            SystemTime = DepartureTime[pos];
            DepartureTime[pos] = infinity;
            if (QueueArrival.Count > 0)
            {
                var avion = QueueArrival.Dequeue();
                avion.TrackTime = SystemTime;
                Tracks[pos] = avion;
                var tiempo = GenerateTimeProcess(avion);
                ProcessTime[pos] = SystemTime + tiempo;
            }
            else
            {
                Tracks[pos] = null;
                TimeDepartuteTime[pos] = SystemTime;                
            }            
        }
    }
}
