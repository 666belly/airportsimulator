using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VT24A5
{

    /// <summary>
    /// Provides data for events related to the airplanes.
    /// </summary>
    internal class AirplaneEventArgs : EventArgs
    {
        private string name;
        private string message;

        // Constructor
        public AirplaneEventArgs(string flightId, string message)
        {
            this.name = flightId;
            this.message = message;
        }

        /// <summary>
        /// Gets or sets the flight ID.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

    }
}
