/*
A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
Write a program that reads the information about a company and its manager and prints it back on the console.
Example input:

program	            user
Company name:	    Telerik Academy
Company address:	31 Al. Malinov, Sofia
Phone number:	    +359 888 55 55 555
Fax number:	
Web site:	        http://telerikacademy.com/
Manager first name:	Nikolay
Manager last name:	Kostov
Manager age:	    25
Manager phone:	    +359 2 981 981

Example output:

Telerik Academy
Address: 231 Al. Malinov, Sofia
Tel. +359 888 55 55 555
Fax: (no fax)
Web site: http://telerikacademy.com/
Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981) 
*/

using System;

class PrintCompanyInfo
{
    static void Main()
    {
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string phoneNum = Console.ReadLine();
        Console.Write("Enter fax number: ");
        string faxNum = Console.ReadLine();
        Console.Write("Enter web site: ");
        string webSite = Console.ReadLine();
        Console.Write("Enter manager first name: ");
        string manFirstName = Console.ReadLine();
        Console.Write("Enter manager last name: ");
        string manLastName = Console.ReadLine();
        Console.Write("Enter manager age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter manager phone numbe: ");
        string manPhoneNum = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine(companyName);
        Console.WriteLine("Address: " + companyAddress);
        Console.WriteLine("Mobile: " + phoneNum);
        Console.WriteLine("Fax: " + faxNum);
        Console.WriteLine("Web site: " + webSite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, mobile: {3})", manFirstName, manLastName, age, manPhoneNum);

    }
}

