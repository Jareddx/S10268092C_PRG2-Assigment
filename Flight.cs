using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace S10268092_PRG2Assigment
{
    public abstract class Flight : IComparable<Flight>
    {
        private string flightNumber;
        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        private string origin;
        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        private DateTime expectedTime;
        public DateTime ExpectedTime
        {
            get { return expectedTime; }
            set { expectedTime = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public Flight() { }
        public Flight(string fn, string o, string d, string et, string s = "Scheduled")
        {
            FlightNumber = fn;
            Origin = o;
            Destination = d;
            ExpectedTime = Convert.ToDateTime(et);
            Status = s;

        }
        public abstract double CalculateFees(int flightcount);

        public override string ToString()
        {
            return $"Flight Number: {FlightNumber}\n" +
                   $"Origin: {Origin}\n" +
                   $"Destination: {Destination}\n" +
                   $"Expected Time: {ExpectedTime:yyyy-MM-dd HH:mm}";
        }

        public int CompareTo(Flight other)
        {
            if (other == null)
                return 1;

            return this.ExpectedTime.CompareTo(other.ExpectedTime);
        }
    }
}

