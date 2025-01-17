using System;
using System.Collections.Generic;
using S10268092_PRG2Assigment;

using (StreamReader sr = new StreamReader("airlines.csv"))
{
    string? s = sr.ReadLine();
    Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
    while ((s = sr.ReadLine()) != null)
    {
        string[] line = s.Split(',');
        string name = line[0];
        string code = line[1];
        Airline airline = new Airline
        {
            Name = name,
            Code = code,
        };

        airlines.Add(name, airline);
        Console.WriteLine(airlines[name]);
    }
}

/*
using (StreamReader sr = new StreamReader("boardinggates.csv"))
{
    string? s = sr.ReadLine();
    Dictionary<string, BoardingGate> boardingGate = new Dictionary<string, BoardingGate>();
    while ((s = sr.ReadLine()) != null)
    {
        string[] line = s.Split(',');
        string name = line[0];
        string code = line[1];
        Airline airline = new Airline
        {
            Name = name,
            Code = code,
        };

        airlines.Add(name, airline);
        Console.WriteLine(airlines[name]);
    }
}

// Basic Features Qn 2
IDictionary<string, Flight> FlightCollection = new Dictionary<string, Flight>();

using (StreamReader sr = new StreamReader("flights.csv"))
{
    string? s = sr.ReadLine();
    while ((s = sr.ReadLine()) != null)
    {
        string[] data = s.Split(',');
        NORMFlight flightdata = new NORMFlight(data[0], data[1], data[2], data[3], data[4]);
        FlightCollection.Add(data[0], flightdata);
    }
}
*/