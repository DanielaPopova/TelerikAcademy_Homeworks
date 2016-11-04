/*
A beer time is after 1:00 PM and before 3:00 AM.
Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator)
and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed.
Note: You may need to learn how to parse dates and times.
Examples:

time	    result
1:00 PM	    beer time
4:30 PM	    beer time
10:57 PM	beer time
8:30 AM	    non-beer time
02:59 AM	beer time
03:00 AM	non-beer time
03:26 AM	non-beer time
*/

using System;
using System.Threading;

class BeerTime
{
    static void Main()
    {

        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Enter time in format hh:mm tt");
        string input = Console.ReadLine();

        DateTime time = new DateTime();

        if (DateTime.TryParse(input, out time))
        {
            //we actually need only the hour to set the boundaries, it should work on different regional settings
            //Console.WriteLine(time.Hour);            
            
            if (time.Hour >= 13 && time.Hour <= 23 || time.Hour >= 1 && time.Hour < 3 || time.Hour == 12)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}

