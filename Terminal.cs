using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
================================
Student name: Dayao Jaredd
Student number: S10268092
Partner name: Yew Jun Jie
================================
*/

namespace S10268092_PRG2Assigment
{
    public class Terminal
    {
        private string terminalName;

        public string TerminalName
        {
            get { return terminalName; }
            set { terminalName = value; }
        }

        private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
        public Dictionary<string, Airline> Airlines { get; set; } = new Dictionary<string, Airline>();


        private Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
        public Dictionary<string, Flight> Flights { get; set; } = new Dictionary<string, Flight>();


        private Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
        public Dictionary<string, BoardingGate> BoardingGates { get; set; } = new Dictionary<string, BoardingGate>();


        private Dictionary<string, double> gateFees = new Dictionary<string, double>();
        public Dictionary<string, double> GateFees { get; set; } = new Dictionary<string, double>();

        public Terminal() { }

        public Terminal(string terminalName)
        {
            this.terminalName = terminalName;
        }

        public bool AddAirline(Airline airline)
        {
            if (airlines.ContainsKey(airline.Code))
            {
                return false; // Airline already exists
            }

            airlines.Add(airline.Code, airline);
            return true;
        }

        public bool AddBoardingGate(BoardingGate gate)
        {
            if (boardingGates.ContainsKey(gate.GateName))
            {
                return false; // Gate already exists
            }

            boardingGates.Add(gate.GateName, gate);
            return true;
        }

        public Airline GetAirlineFromFlight(Flight flight)
        {
            foreach (var airline in airlines.Values)
            {
                if (airline.Flights.ContainsKey(flight.FlightNumber))
                {
                    return airline;
                }
            }
            return null; // Flight not found in any airline
        }

        public void PrintAirlineFees()
        {
            Console.WriteLine($"Airline Fees in Terminal: {TerminalName}");
            foreach (var airline in airlines.Values)
            {
                Console.WriteLine($"Airline: {airline.Name} ({airline.Code}), Fees: {airline.CalculateFees()}");
            }
        }

        public override string ToString()
        {
            string result = $"Terminal: {TerminalName}\n";
            result += "Airlines:\n";
            foreach (var airline in airlines.Values)
            {
                result += airline.ToString() + "\n";
            }
            result += "Boarding Gates:\n";
            foreach (var gate in boardingGates.Values)
            {
                result += gate.ToString() + "\n";
            }
            return result;
        }
    }
}
