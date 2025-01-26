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
    public class Airline
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private Dictionary<string,Flight> flights = new Dictionary<string, Flight>();

        public Dictionary<string, Flight> Flights { get; set; } = new Dictionary<string, Flight>();

        public Airline() { }

        public Airline(string name, string code, Dictionary<string, Flight> Flights)
        {
            this.name = name;
            this.code = code;
            this.Flights = Flights;
        }

        public bool AddFlight(Flight flight)
        {
            if (Flights.ContainsKey(flight.FlightNumber))
            {
                return false;
            }
            Flights.Add(flight.FlightNumber, flight);
            return true;
        }

        public double CalculateFees()
        {
            return 2;
        }

        public bool RemoveFlight(Flight flight)
        {
            return Flights.Remove(flight.FlightNumber);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Airline Name: {Name}");
            sb.AppendLine($"Code: {Code}");
            sb.AppendLine("Flights:");
            foreach (var flight in Flights.Values)
            {
                sb.AppendLine($"  - {flight.ToString()}");
            }
            return sb.ToString();
        }
    }
}
