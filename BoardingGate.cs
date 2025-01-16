using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10268092_PRG2Assigment
{
    public class BoardingGate
    {
        private string gateName;

        public string GateName
        {
            get { return gateName; }
            set { gateName = value; }
        }

        private bool supportsCFFT;

        public bool SupportsCFFT
        {
            get { return supportsCFFT; }
            set { supportsCFFT = value; }
        }

        private bool supportsDDJB;

        public bool SupportsDDJB
        {
            get { return supportsDDJB; }
            set { supportsDDJB = value; }
        }

        private bool supportsLWTT;

        public bool SupportsLWTT
        {
            get { return supportsLWTT; }
            set { supportsLWTT = value; }
        }

        private Flight flight;

        public Flight Flight
        {
            get { return flight; }
            set { flight = value; }
        }

        public BoardingGate() { }

        public BoardingGate(string gateName, bool cfft, bool ddjb, bool lwtt, Flight flight)
        {
            this.gateName = gateName;
            this.supportsCFFT = cfft;
            this.supportsDDJB = ddjb;
            this.supportsLWTT = lwtt;
            this.flight = flight;
        }

        public double CalculateFees()
        {
            return 2;
        }

        public override string ToString()
        {
            string flightInfo = Flight != null ? Flight.ToString() : "No flight assigned";
            return $"Gate: {GateName}\nSupports CFFT: {SupportsCFFT}\nSupports DDJB: {SupportsDDJB}\nSupports LWTT: {SupportsLWTT}\nFlight: {flightInfo}";
        }
    }
}
