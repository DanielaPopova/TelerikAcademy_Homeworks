using System;

class DayOfWeek
{
    static void Main()
    {
        string date = Console.ReadLine();
        DateTime today = DateTime.Parse(date);
        Console.WriteLine(today.DayOfWeek);
    }
}

