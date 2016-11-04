/*
Problem 15.* Age after 10 Years

Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.
*/

using System;
using System.Globalization;

class AgeAfter10Years
{
    static void Main()
    {
        Console.WriteLine("Enter your birthday in format d - m - yy");
        DateTime myBirthDay = DateTime.Parse(Console.ReadLine());
        
        TimeSpan age = DateTime.Today.Subtract(myBirthDay);
        double myAge = (age.TotalDays)/365;

        Console.WriteLine("You are " + Math.Round(myAge, 1) + " years old.");
        Console.WriteLine("In 10 years you'll be " + Math.Round(myAge + 10, 1) + " years old.");
    }
}

