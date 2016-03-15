/*
A marketing company wants to keep record of its employees. Each record would have the following characteristics:

First name
Last name
Age (0...100)
Gender (m or f)
Personal ID number (e.g. 8306112507)
Unique employee number (27560000…27569999)
Declare the variables needed to keep the information for a single employee using appropriate primitive data types.
Use descriptive names. Print the data at the console.
*/

using System;

class EmployeeData
{
    static void Main()
    {
        Console.WriteLine("Please fill in our employee information!");

        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());
        if (age < 0 || age > 100)
        {
            Console.WriteLine("Wrong entry! Try again!");
            Console.Write("Enter age: ");
            age = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter gender m/f: ");
        char gender = char.Parse(Console.ReadLine());
        if (gender != 'm' && gender != 'f')
        {
            Console.WriteLine("Wrong entry! Use m for \"male\" or f for \"female\"!");
            Console.Write("Enter gender m/f: ");
            gender = char.Parse(Console.ReadLine());
        }

        Console.Write("Your personal ID number: ");
        ulong id = ulong.Parse(Console.ReadLine());

        Console.Write("Your employee number: ");
        int employeeNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Your information is recorded!");
        Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nID Number: {4}\nEmployee Number: {5}",
                        firstName, lastName, age, gender, id, employeeNumber);               
    }
}

