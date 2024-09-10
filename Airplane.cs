using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VT24A5
{

    /// <summary>
    /// Represents the airplane
    /// </summary>
    internal class Airplane
    {
        private DispatcherTimer dispatcherTimer;

        public event EventHandler<AirplaneEventArgs> Landed;
        public event EventHandler<AirplaneEventArgs> TakeOff;


        // Constructor
        public Airplane(string v, string id)
        {
            SetUpTimer();
        }

        public Airplane(string name, string id, string description, double time)
        {
            Name = name;
            FlightID = id;
            Destination = description;
            FlightTime = time;
            SetUpTimer();
        }


        // Fields
        private bool canLand;
        private string description;
        private string flightID;
        private double time;
        private TimeOnly localTime;
        private string name;


        // Properties
        public bool CanLand
        {
            get { return canLand; }
            set { canLand = value; }
        }

        public string Destination
        {
            get { return description; }
            set { description = value; }
        }

        public string FlightID
        {
            get { return flightID; }
            set { flightID = value; }
        }

        public double FlightTime
        {
            get { return time; }
            set { time = value; }
        }

        public TimeOnly LocalTime
        {
            get { return localTime; }
            set { localTime = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

 

        /// <summary>
        /// TakeOff and Landing for the corresponding events
        /// </summary>
        public void OnLanding()
        {
            CanLand = true;
            StopTimer();

        }

        public void OnTakeOff()
        {
            CanLand = false;
        }

        /// <summary>
        /// Set up for the DispatcherTime event
        /// </summary>
        public void SetUpTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Event handler for time event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcherTimer_Tick(object? sender, System.EventArgs e)
        {
            LocalTime = LocalTime.AddHours(1);

            if (CanLand && FlightTime <= 0)
            {
                OnLanding();
                return;
            }

            if (!CanLand && FlightTime > 0)
            {
                FlightTime -= 1.0 / 3600;

                if (FlightTime <= 0)
                {
                    OnTakeOff();
                    return;
                }
            }

            // Check if flight time has reached zero and trigger landing if so
            if (!CanLand && FlightTime <= 0)
            {
                OnLanding();
            }
        }

        public void StopTimer()
        {
            dispatcherTimer.Stop();
        }

        /// <summary>
        /// Return a string representation of the airplane
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Airplane {Name}, Flight ID: {FlightID}, Destination: {Destination}";
        }

        public static implicit operator Airplane(string v)
        {
            throw new NotImplementedException();
        }
    }
}
