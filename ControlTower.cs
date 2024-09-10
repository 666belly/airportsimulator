using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace VT24A5
{
    //// <summary>
    /// Class representing a control tower to manage flights.
    /// </summary>
    internal class ControlTower
    {
        private ListManager<Airplane> flights;
        private ListBox listBoxTakeOff;

        public ControlTower(ListBox listBoxAddedPlane, ListBox listBoxTakeOff)
        {
            flights = new ListManager<Airplane>();
            this.listBoxTakeOff = listBoxTakeOff;
        }

        /// <summary>
        /// Handles the display information for airplane events.
        /// </summary>
        private void OnDisplayInfo(object sender, AirplaneEventArgs e)
        {
            string msg = $"{e.Name}: {e.Message}";
            listBoxTakeOff.Items.Add(msg);
        }

        public List<Airplane> Flights => flights.GetList();

        /// <summary>
        /// Adds a plane to the list of flights.
        /// </summary>
        public void AddPlane(string name, string id, string description, double time)
        {
            Airplane newPlane = new Airplane(name, id, description, time);

            newPlane.Landed += OnDisplayInfo; // Subscribe to Landed event
            newPlane.TakeOff += OnDisplayInfo; // Subscribe to TakeOff event

            flights.Add(newPlane); // Add the plane to the list
        }

        private void OnPlaneLanded(object sender, AirplaneEventArgs e)
        {
            // Handle plane landed event
        }

        private void OnPlaneTakeOff(object sender, AirplaneEventArgs e)
        {
            // Handle plane takeoff event
            string msg = $"Flight {e.Name} is taking off: {e.Message}";
            listBoxTakeOff.Items.Add(msg);
        }

        /// <summary>
        /// Orders takeoff for the airplane at the chosen index.
        /// </summary>
        public void OrderTakeOff(int index)
        {
            if (index >= 0 && index < flights.GetList().Count)
            {
                Airplane airplane = flights.GetList()[index];
                DateTime currentTime = DateTime.Now;

                string headingMessage = $"Flight {airplane.Name}, flight ID {airplane.FlightID}, heading for {airplane.Destination} is sent to runway";
                string takeOffMessage = $"The aircraft {airplane.Name}, flight ID {airplane.FlightID}, is taking off, time of take off: {currentTime}";
                double flightTime = airplane.FlightTime / 3600;
                DateTime arrivalTime = currentTime.AddHours(flightTime);
                string landingMessage = $"Flight {airplane.Name}, flight ID {airplane.FlightID}, has landed in {airplane.Destination}, flight time of arrival: {arrivalTime}";

                listBoxTakeOff.Items.Add(headingMessage);
                listBoxTakeOff.Items.Add(takeOffMessage);
                listBoxTakeOff.Items.Add(landingMessage);

                // Start the timer to simulate flight time
                airplane.SetUpTimer();

                // Handle plane takeoff event
                airplane.TakeOff += OnPlaneTakeOff;
                airplane.Landed += OnPlaneLanded;

                // Remove the airplane from the list once it takes off
                flights.GetList().RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"No plane selected for takeoff: {index}");
            }
        }
    }
}
