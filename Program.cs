using S10268092_PRG2Assigment;
using System;
using System.Collections.Generic;

using (StreamReader sr = new StreamReader("airlines.csv"))
{
    string? s = sr.ReadLine(); 

    while ((s = sr.ReadLine()) != null)
    {
        string[] line = s.Split(',');
        

        Console.WriteLine(s);
    }
}

using (StreamReader sr = new StreamReader("boardinggates.csv"))
{
    string? s = sr.ReadLine();

    while ((s = sr.ReadLine()) != null)
    {


        Console.WriteLine(s);
    }
}