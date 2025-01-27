using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Transactions;
using System.Xml.Linq;
using S10268092_PRG2Assigment;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
================================
Student name: Dayao Jaredd
Student number: S10268092
Partner name: Yew Jun Jie
================================
*/

void DisplayTable()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Welcome to Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("1. List All Flights");
    Console.WriteLine("2. List Boarding Gates");
    Console.WriteLine("3. Assign a Boarding Gate to a Flight");
    Console.WriteLine("4. Create Flight");
    Console.WriteLine("5. Display Airline Flights");
    Console.WriteLine("6. Modify Flight Details");
    Console.WriteLine("7. Display Flight Schedule");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
    Console.Write("Please select your option: ");

    int option = Convert.ToInt16(Console.ReadLine());
    if (option == 1)
    {
        DisplayFlightInfo();
        Console.WriteLine();
        DisplayTable();
    }

    else if (option ==2)
    {
        DisplayBoardingGate();
        Console.WriteLine();
        DisplayTable();
    }
    else if (option == 3)
    {
        AssignGate();
        Console.WriteLine();
        DisplayTable();
    }

    else if (option == 4)
    {
        AddFlight();
        Console.WriteLine();
        DisplayTable();
    }

    else if (option == 5)
    {
        DisplayAirlineDetails();
        Console.WriteLine();
        DisplayTable();
    }
    else if (option ==6)
    {
        ModifyFlight();
        Console.WriteLine();
        DisplayTable();
    }
    else if (option == 7)
    {
        DisplayScheduledFlights();
        Console.WriteLine();
        DisplayTable();
    }
}

// Basic Features Qn 1

Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
Dictionary<string, string> temp1= new Dictionary<string, string>();
using (StreamReader sr = new StreamReader("airlines.csv"))
{
    string? s = sr.ReadLine();
    
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


        temp1.Add(code,name);
        airlines.Add(name, airline);
    }
    Console.WriteLine("Loading Airlines...");
    Console.WriteLine("{0} Airlines Loaded!", count);
}

Dictionary<string, BoardingGate> boardingGate = new Dictionary<string, BoardingGate>();
using (StreamReader sr = new StreamReader("boardinggates.csv"))
{
    string? s = sr.ReadLine();

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
        NORMFlight flightdata = new NORMFlight(data[0], data[1], data[2], data[3]);
        FlightCollection.Add(data[0], flightdata);
    }
    Console.WriteLine("Loading Flights...");
    Console.WriteLine("{0} Flights Loaded!",count);
}

// Basic Features Qn 3
void DisplayFlightInfo()
{
    List<Flight> FlightList = new List<Flight>();
    List<Airline> temp = new List<Airline>();
    string AirlineName = "";

    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        string? s = sr.ReadLine();
        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            Airline AirlineData = new Airline()
            {
                Name = data[0],
                Code = data[1],
            };
            temp.Add(AirlineData);
        }
    }

    foreach (var flight in FlightCollection)
    {
        Flight flightdata = flight.Value;
        FlightList.Add(flightdata);
    }

    Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-10}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");
    for (int i = 0; i < FlightList.Count(); i++)

    {
        Flight F = FlightList[i];
        string[] split = F.FlightNumber.Split(" ");

        for (int x = 0; x < temp.Count(); x++)
        {
            Airline C = temp[x];
            if (C.Code == split[0])
            {
                AirlineName = C.Name;
            }
        }
        Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-10}", F.FlightNumber, AirlineName, F.Origin, F.Destination, F.ExpectedTime);
    }
}

// Basic Features Qn 4
void DisplayBoardingGate()
{
    Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-25}", "Gate Name", "DDJB", "CFFT", "LWTT");
    foreach (KeyValuePair<string, BoardingGate> kvp in boardingGate)
    {
        Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-25}", kvp.Key, kvp.Value.SupportsDDJB, kvp.Value.SupportsCFFT, kvp.Value.SupportsLWTT);
    }

}

// Basic Features Qn 5
void AssignGate()
{
    List<string> temp = new List<string>();


    Console.Write("Enter Flight Number: ");
    string FlightNo = Console.ReadLine();
    Flight FlightData = FlightCollection[FlightNo];
    List<Flight> flights = new List<Flight> { FlightData };

    using (StreamReader sr = new StreamReader("flights.csv"))
    {
        string? s = sr.ReadLine();
        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            if (data[0] == FlightNo)
            {
                if (data[4] == "")
                {
                    data[4] = "None";
                }
                temp.Add(data[4]);
            }
        }
    }

    Console.Write("Enter Boarding Gate Name: ");
    string GateName = Console.ReadLine();
    BoardingGate BoardingGateData = boardingGate[GateName];

    if (BoardingGateData.Flight != null)
    {
        Console.WriteLine("Boarding Gate {0} is already assigned, please try again", GateName);
        return;
    }

    Console.WriteLine(FlightData);
    Console.WriteLine("Special Request Code: {0}", temp[0]);
    Console.WriteLine(BoardingGateData);
    Console.Write("Would you like to update the status of the flight? (Y/N) ");
    string answer = Console.ReadLine();

    if (answer == "Y")
    {
        Console.WriteLine("1. Delayed");
        Console.WriteLine("2. Boarding");
        Console.WriteLine("3. On Time");
        Console.Write("Please select the new status of the flight: ");
        string status = Console.ReadLine();

        if (status == "1")
        {
            FlightData.Status = "Delayed";
        }
        else if (status == "2")
        {
            FlightData.Status = "Boarding";
        }
        else if (status == "3")
        {
            FlightData.Status = "On Time";
        }
    }

    BoardingGateData.Flight = FlightData;
    Console.WriteLine("Flight {0} has been assigned to Boarding Gate {1}!", FlightNo, GateName);
}
// Basic Features Qn 6
void AddFlight()
{
    while (true)
    {
        Console.Write("Enter Flight Number: ");
        string FlightNo = Console.ReadLine();
        Console.Write("Enter Origin: ");
        string Origin = Console.ReadLine();
        Console.Write("Enter Destination: ");
        string Destination = Console.ReadLine();
        Console.Write("Enter Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
        string ExpectedTime = Console.ReadLine();
        Console.Write("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
        string RequestCode = Console.ReadLine();

        NORMFlight flightdata = new NORMFlight(FlightNo, Origin, Destination, ExpectedTime, RequestCode);
        FlightCollection.Add(FlightNo, flightdata);

        using (StreamWriter sw = new StreamWriter("flights.csv", true))
        {
            if (RequestCode == "None")
            {
                RequestCode = "";
            }
            sw.WriteLine(FlightNo + "," + Origin + "," + Destination + "," + ExpectedTime + "," + RequestCode);
        }

        Console.WriteLine("Flight {0} has been added!", FlightNo);
        Console.Write("Would you like to add another flight? (Y/N)");
        string option = Console.ReadLine();
        if (option == "N")
        {
            break;
        }
    } 
}
// Basic Features Qn 7
void DisplayAirlineDetails()
{
    Console.WriteLine("{0,-16}{1,-20}","Airline Code", "Airline Name");
    foreach (KeyValuePair<string, Airline> kvp in airlines)
    {
        Console.WriteLine("{0,-16}{1,-20}",kvp.Value.Code,kvp.Key);
    }
    Console.Write("Enter Airline Code: ");
    string code= Console.ReadLine();
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Flights for {0}", temp1[code]);
    Console.WriteLine("=============================================");
    List<Flight> FlightList = new List<Flight>();
    List<Airline> temp = new List<Airline>();
    string AirlineName = temp1[code];
    foreach (var flights in FlightCollection)
    {
        Flight flightdata = flights.Value;
        FlightList.Add(flightdata);
    }
    var Flights = FlightList.FindAll(f => f.FlightNumber.StartsWith(code));
    Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-10}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");
    foreach(var flight in Flights)
    {
        Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-10}", flight.FlightNumber, AirlineName, flight.Origin, flight.Destination, flight.ExpectedTime);
    }
}
// Basic Features Qn 8
Dictionary<string, string> flightSpecialRequestCodes = new Dictionary<string, string>();

void ModifyFlight()
{

    Console.WriteLine("{0,-16}{1,-20}", "Airline Code", "Airline Name");
    foreach (KeyValuePair<string, Airline> kvp in airlines)
    {
        Console.WriteLine("{0,-16}{1,-20}", kvp.Value.Code, kvp.Key);
    }
    Console.Write("Enter Airline Code: ");
    string code = Console.ReadLine();
    Console.WriteLine("=============================================");
    Console.WriteLine("List of Flights for {0}", temp1[code]);
    Console.WriteLine("=============================================");
    List<Flight> FlightList = new List<Flight>();
    List<Airline> temp = new List<Airline>();
    string AirlineName = temp1[code];
    List<Flight> airlineFlights = FlightCollection.Values
    .Where(f => f.FlightNumber.StartsWith(code))
    .ToList();
    foreach (var flights in FlightCollection)
    {
        Flight flightdata = flights.Value;
        FlightList.Add(flightdata);
    }
    var Flights = FlightList.FindAll(f => f.FlightNumber.StartsWith(code));
    Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-10}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");
    foreach (var flight in Flights)
    {
        Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-10}", flight.FlightNumber, AirlineName, flight.Origin, flight.Destination, flight.ExpectedTime);
    }

    
    Flight selectedFlight;
    string flightNumber="";
    while ((selectedFlight = airlineFlights.FirstOrDefault(f => f.FlightNumber == flightNumber)) == null)
    {
        Console.Write("Choose an existing flight to modify of delete: ");
        flightNumber = Console.ReadLine();
    }
    Console.WriteLine("1. Modify Flight");
    Console.WriteLine("2. Delete Flight");
    Console.Write("Choose an option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    Dictionary<string, string> flightBoardingGates = new Dictionary<string, string>();
    void DisplayNewFlightDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Flight updated!");
            Console.WriteLine("Flight Number: {0}", flightNumber);
            Console.WriteLine("Airline Name: {0}", temp1[code]);
            Console.WriteLine("Origin: {0}", selectedFlight.Origin);
            Console.WriteLine("Destination: {0}", selectedFlight.Destination);
            Console.WriteLine("Expected Time: {0}", selectedFlight.ExpectedTime);
            Console.WriteLine("Status: {0}", selectedFlight.Status);
            string requestCode = flightSpecialRequestCodes.ContainsKey(selectedFlight.FlightNumber)
                                 ? flightSpecialRequestCodes[selectedFlight.FlightNumber]
                                 : "No special request code";
            Console.WriteLine("Special Request Code: {0}", requestCode);
        string boardingGate = flightBoardingGates.ContainsKey(selectedFlight.FlightNumber)
                      ? flightBoardingGates[selectedFlight.FlightNumber]
                      : "No boarding gate assigned";

        Console.WriteLine("Boarding Gate: {0}", boardingGate);
        }
    if (option == 1)
    {
        Console.WriteLine("1. Modify Basic Information");
        Console.WriteLine("2. Modify Status");
        Console.WriteLine("3. Modify Special Request Code");
        Console.WriteLine("4. Modify Boarding Gate");
        Console.Write("Choose an option: ");
        int option2 = Convert.ToInt32(Console.ReadLine());

        if (option2 == 1)
        {
            Console.Write("Enter new Origin: ");
            selectedFlight.Origin = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter new Destination: ");
            selectedFlight.Destination = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
            selectedFlight.ExpectedTime = DateTime.Parse(Console.ReadLine());
            DisplayNewFlightDetails();
        }
        else if (option2 == 2)
        {
            Console.Write("Enter new Status: ");
            selectedFlight.Status = Console.ReadLine();
            DisplayNewFlightDetails();
        }
        else if (option2 == 3)
        {
            Console.Write("Enter new Special Request Code: ");
            string specialRequestCode = Console.ReadLine();
            if (flightSpecialRequestCodes.ContainsKey(selectedFlight.FlightNumber))
            {
                flightSpecialRequestCodes[selectedFlight.FlightNumber] = specialRequestCode;
            }
            else
            {
                flightSpecialRequestCodes.Add(selectedFlight.FlightNumber, specialRequestCode);
            }
            DisplayNewFlightDetails();
        }
        else if (option2 == 4)
        {
            Console.Write("Enter new Boarding Gate: ");
            string boardingGate = Console.ReadLine();

            // Update the boarding gate for the selected flight
            if (flightBoardingGates.ContainsKey(selectedFlight.FlightNumber))
            {
                // Update the existing boarding gate
                flightBoardingGates[selectedFlight.FlightNumber] = boardingGate;
            }
            else
            {
                // Add a new boarding gate if not already present
                flightBoardingGates.Add(selectedFlight.FlightNumber, boardingGate);
            }
            DisplayNewFlightDetails();
        }

    }


    else if (option == 2)
    {
        string flightNumberToDelete = flightNumber;
        // Check if the flight exists
        if (FlightCollection.ContainsKey(flightNumberToDelete))
        {
            // Confirm deletion
            Console.Write($"Are you sure you want to delete flight {flightNumberToDelete}? (Y/N): ");
            string confirmation = Console.ReadLine();

            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                // Remove the flight from FlightCollection
                FlightCollection.Remove(flightNumberToDelete);

                // Remove associated Special Request Code, if it exists
                if (flightSpecialRequestCodes.ContainsKey(flightNumberToDelete))
                {
                    flightSpecialRequestCodes.Remove(flightNumberToDelete);
                }

                // Remove associated Boarding Gate, if it exists
                if (flightBoardingGates.ContainsKey(flightNumberToDelete))
                {
                    flightBoardingGates.Remove(flightNumberToDelete);
                }

                Console.WriteLine($"Flight {flightNumberToDelete} has been successfully deleted.");
            }
            else
            {
                Console.WriteLine("Deletion canceled.");
            }
        }
        else
        {
            Console.WriteLine("Flight Number not found.");
        }


    }

    // Basic Features Qn 9
    void DisplayScheduledFlights()
{
    List<Flight> FlightList = new List<Flight>();
    List<BoardingGate> BoardingList = new List<BoardingGate>();
    List<Airline> temp = new List<Airline>();
    string AirlineName = "";
    string BoardingGate = "Unassigned";

    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        string? s = sr.ReadLine();
        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            Airline AirlineData = new Airline()
            {
                Name = data[0],
                Code = data[1],
            };
            temp.Add(AirlineData);
        }
    }

    foreach (var flight in FlightCollection)
    {
        Flight flightdata = flight.Value;
        FlightList.Add(flightdata);
    }

    foreach (var gate in boardingGate)
    {
        BoardingGate boardingdata = gate.Value;
        BoardingList.Add(boardingdata);
    }

    FlightList.Sort();

    Console.WriteLine("Flight Number   Airline Name           Origin                 Destination            Expected Departure/Arrival Time     Status          Boarding Gate");
    for (int i = 0; i < FlightList.Count(); i++)

    {
        Flight F = FlightList[i];
        string[] split = F.FlightNumber.Split(" ");

        for (int x = 0; x < temp.Count(); x++)
        {
            Airline C = temp[x];
            if (C.Code == split[0])
            {
                AirlineName = C.Name;
            }
        }
        
        /*
        for (int z = 0; z < BoardingList.Count(); z++)
        {
            BoardingGate BG = BoardingList[z];
            Flight F2 = BG.Flight;
            if (F.FlightNumber == F.FlightNumber)
            {
                BoardingGate = BG.GateName;
            }
        }
        */

        Console.WriteLine("{0,-16}{1,-23}{2,-23}{3,-23}{4,-36}{5,-16}{6, -10}", F.FlightNumber, AirlineName, F.Origin, F.Destination, F.ExpectedTime, F.Status, BoardingGate);
    }
}

// Main Loop
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
DisplayTable();
