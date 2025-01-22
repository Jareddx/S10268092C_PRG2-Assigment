using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace S10268092_PRG2Assigment
{
    public class NORMFlight : Flight
    {
        public NORMFlight() : base() { }

        public NORMFlight(string fn, string o, string d, string et, string s = "Scheduled") : base(fn, o, d, et, s)
        {

        }

        public override double CalculateFees(int flightcount)
        {
            double terminalfees = 0;
            double promodiscount = 0;
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

            double totalfees = terminalfees * tempdiscount - promodiscount - 50;
            return totalfees;
        }
    }
}