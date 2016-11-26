using System;
using System.Globalization;

class DateDifference
{
    static void Main()
    {
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

        TimeSpan difference = firstDate - secondDate;
        double daysBetweenTimeSpan = Math.Abs(difference.TotalDays);

        Console.WriteLine(daysBetweenTimeSpan);            
    }
}

/*
27.02.2006
03.03.2006
*/