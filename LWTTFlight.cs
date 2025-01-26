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
    class LWTTFlight : Flight
    {
        private double requestFee;

        public double RequestFee
        {
            get { return requestFee; }
            set { requestFee = value; }
        }

        public LWTTFlight() : base() {}

        public LWTTFlight(string fn, string o, string d, string et, string s, double rf) : base(fn, o, d, et, s)
        {
            RequestFee = rf;
        }

        public override double CalculateFees(int flightcount)
        {
            double terminalfees = 0;
            double promodiscount = 500;
            double tempdiscount = 1;

            if (flightcount > 3)
            {
                promodiscount += 350;
            }

            if (flightcount > 5)
            {
                tempdiscount = 0.97;
            }

            if (ExpectedTime.Hour < 11 || ExpectedTime.Hour >= 21)
            {
                promodiscount += 110;
            }

            if (Origin == "DXB" || Origin == "BKK" || Origin == "NRT")
            {
                promodiscount += 25;
            }

            if (Destination == "SIN")
            {
                terminalfees += 500;
            }

            if (Origin == "SIN")
            {
                terminalfees += 800;
            }

            double totalfees = terminalfees * tempdiscount - promodiscount;
            return totalfees;
        }
    }
}
