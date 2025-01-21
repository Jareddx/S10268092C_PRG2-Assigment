using System;
using System.Collections.Generic;
using S10268092_PRG2Assigment;

// Basic Features Qn 1
using (StreamReader sr = new StreamReader("airlines.csv"))
{
    string? s = sr.ReadLine();
    Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
    int count = 0;
    while ((s = sr.ReadLine()) != null)
    {
        count += 1;
        string[] line = s.Split(',');
        string name = line[0];
        string code = line[1];
        Airline airline = new Airline
        {
            Name = name,
            Code = code,
        };

        airlines.Add(name, airline);
    }
    Console.WriteLine("Loading Airlines...");
    Console.WriteLine("{0} Airlines Loaded!", count);
}


using (StreamReader sr = new StreamReader("boardinggates.csv"))
{
    string? s = sr.ReadLine();
    Dictionary<string, BoardingGate> boardingGate = new Dictionary<string, BoardingGate>();
    int count = 0;
    while ((s = sr.ReadLine()) != null)
    {
        count += 1;
        string[] line = s.Split(',');
        string gate = line[0];
        string ddjb = line[1];
        string cfft = line[2];
        string lwtt = line[3];

        bool supportddjb = false;
        bool supportcfft = false;
        bool supportlwtt = false;
        if (ddjb == "True")
        {
            supportddjb = true;
            
        }

        else if (ddjb == "False")
        {
            supportddjb = false;
        }

        if (cfft == "True")
        {
            supportcfft = true;
        }

        else if (cfft == "False")
        {
            supportcfft = false;
        }

        if (lwtt == "True")
        {
            supportlwtt = true;
        }

        else if (lwtt == "False")
        {
            supportlwtt = false;
        }
        BoardingGate boardinggate = new BoardingGate
        {
            GateName = gate,
            SupportsDDJB = supportddjb,
            SupportsCFFT = supportcfft,
            SupportsLWTT = supportlwtt
        };

        BoardingGate gatedata = new BoardingGate(gate,supportcfft, supportddjb, supportlwtt);
        boardingGate.Add(gate, gatedata);
    }
    Console.WriteLine("Loading Boarding Gates...");
    Console.WriteLine("{0} Boarding Gates Loaded!", count);
}


// Basic Features Qn 2
IDictionary<string, Flight> FlightCollection = new Dictionary<string, Flight>();

using (StreamReader sr = new StreamReader("flights.csv"))
{
    int count = 0;
    string? s = sr.ReadLine();
    while ((s = sr.ReadLine()) != null)
    {
        count += 1;
        string[] data = s.Split(',');
        NORMFlight flightdata = new NORMFlight(data[0], data[1], data[2], data[3], data[4]);
        FlightCollection.Add(data[0], flightdata);
    }
    Console.WriteLine("Loading Flights...");
    Console.WriteLine("{0} Flights Loaded!",count);
}

// Basic Features Qn 3
void DisplayFlightInfo()
{
    List<Flight> FlightList = new List<Flight>();

    foreach (var flight in FlightCollection)
    {
        Flight flightdata = flight.Value;
        FlightList.Add(flightdata);
    }

    for (int i = 0; i < FlightList.Count(); i++)
    {
        Flight F = FlightList[i];
        string[] split = F.FlightNumber.Split(" ");
        
    }
}

