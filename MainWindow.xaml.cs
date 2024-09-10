using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VT24A5
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Window
    {
        private ControlTower controlTower;
        public ListBox ListBoxTakeOff { get { return listBoxTakeOff; } }

        /// <summary>
        /// Initializes a new instance of the MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
            controlTower = new ControlTower(listBoxAddedPlane, listBoxTakeOff);
        }

        /// <summary>
        /// Event handler triggered by click to add a flight to the list, collecting flight data
        /// </summary>
        private void btnAddPlane_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            string id = txtBoxID.Text;
            string description = txtBxDescription.Text;

            double time;
            if (!double.TryParse(txtBoxTime.Text, out time))
            {
                MessageBox.Show("Please enter a valid take off time for the flight.");
                return;
            }

            controlTower.AddPlane(name, id, description, time);

            UpdateGUI();
        }

        /// <summary>
        /// Event handler triggered by click to initiate the take off procedure for the flight at selected index.
        /// </summary>
        private void btnTakeOff_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listBoxAddedPlane.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < controlTower.Flights.Count)
            {
                // Order takeoff for the selected airplane
                controlTower.OrderTakeOff(selectedIndex);

                // Update the GUI
                UpdateGUI();
            }
            else
            {
                MessageBox.Show("Please select a valid flight to take off.");
            }
        }

        private void InitializeGUI()
        {
        }

        /// <summary>
        /// Updates GUI with information on the airplane from the control tower list.
        /// </summary>
        private void UpdateGUI()
        {
            listBoxAddedPlane.Items.Clear(); // Clear the list box before updating

            foreach (Airplane airplane in controlTower.Flights)
            {
                // Create a string with the airplane's details
                string airplaneDetails = $"{airplane.Name} - {airplane.FlightID}, heading for {airplane.Destination}";

                // Add the airplane's details to the list box
                listBoxAddedPlane.Items.Add(airplaneDetails);
            }
        }

        private void listBoxAddedPlane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        public void listBoxTakeOff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
