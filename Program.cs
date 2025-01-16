// See https://aka.ms/new-console-template for more information
using S10268092_PRG2Assigment;

Console.WriteLine("Hello, World!");
Console.WriteLine("sigma");


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
