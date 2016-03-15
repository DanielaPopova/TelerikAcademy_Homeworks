/*
The gravitational field of the Moon is approximately 17% of that on the Earth.
Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
Examples:

weight	weight on the Moon
86	     14.62
74.6	 12.682
53.7	 9.129
*/

using System;
using System.Threading;

class GravitationOnTheMoon
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        
        Console.WriteLine("Enter weight: ");
        double weightEarth = double.Parse(Console.ReadLine());
        double weightMoon = (17.0/100) * weightEarth;

        Console.WriteLine(Math.Round(weightMoon, 3));
    }
}

