# Airport Simulator

A C# WPF desktop application that simulates airport operations, allowing users to manage aircraft flights, schedule takeoffs, and track landings.

## Overview

The Airport Simulator provides a graphical interface for managing airport flight operations. Users can add aircraft to the system, schedule their takeoffs, and monitor flight activities through an event log. The application simulates flight times and automatically handles landing procedures.

## Features

- **Add Flights**: Register new aircraft with flight details including name, flight ID, destination, and estimated flight time
- **Manage Takeoffs**: Order takeoffs for aircraft waiting in the queue
- **Flight Tracking**: Real-time monitoring of flight status and event logging
- **Event Logging**: Comprehensive log of all flight events including takeoff times and landing confirmations
- **Automatic Flight Simulation**: Built-in timer system that simulates flight duration and arrival times

## Project Structure

### Core Classes

- **`Airplane.cs`** - Represents individual aircraft with properties like name, flight ID, destination, and flight time. Handles flight state management and timing using `DispatcherTimer`.

- **`ControlTower.cs`** - Manages all active flights and coordinates between the UI and airplane objects. Handles takeoff ordering and flight event subscriptions.

- **`ListManager<T>.cs`** - Generic list management utility for maintaining the collection of flights.

- **`AirplaneEventArgs.cs`** - Custom event arguments class for airplane events, carrying flight information in event handlers.

### UI Components

- **`MainWindow.xaml` / `MainWindow.xaml.cs`** - Main application window with input controls and display lists:
  - Input fields for aircraft details (name, ID, destination, flight time)
  - Add Plane button to register new aircraft
  - Takeoff button to initiate departures
  - List displays for queued aircraft and flight events

- **`App.xaml` / `App.xaml.cs`** - WPF application entry point and configuration

### Project Files

- **`VT24A5.csproj`** - Visual Studio project configuration
- **`VT24A5.sln`** - Visual Studio solution file

## Getting Started

### Prerequisites

- .NET Framework or .NET Core
- Visual Studio or Visual Studio Code with C# support

### Running the Application

1. Open `VT24A5.sln` in Visual Studio
2. Build the solution
3. Run the application (F5 or Debug > Start Debugging)

### Usage

1. **Add a Flight**:
   - Enter aircraft name, flight ID, destination, and estimated flight time
   - Click "Add Plane" to queue the aircraft

2. **Schedule Takeoff**:
   - Select an aircraft from the queued list
   - Click "Take Off" to initiate the departure procedure
   - View flight events in the event log

3. **Monitor Flights**:
   - Check the event log for real-time updates on takeoffs and landings
   - The system automatically handles landing based on flight time simulation

## How It Works

- Each airplane maintains a timer that counts down the flight duration
- When an aircraft takes off, it's removed from the queue and enters active flight status
- The system logs takeoff time and calculates arrival time based on flight duration
- Upon reaching the destination, the aircraft automatically triggers a landing event
- All events are displayed in the flight log for operator reference

## Technologies Used

- **Language**: C# (.NET)
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Architecture**: Event-driven design with pub/sub pattern

## Future Enhancements

- Runway queue management
- Fuel consumption simulation
- Passenger capacity tracking
- Maintenance scheduling
- Weather system impact
- Detailed flight statistics and reports

