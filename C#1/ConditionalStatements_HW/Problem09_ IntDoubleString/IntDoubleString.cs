/*
Write a program that, depending on the user’s choice, inputs an int, double or string variable.
If the variable is int or double, the program increases it by one.
If the variable is a string, the program appends * at the end.
Print the result at the console. Use switch statement.

Example 1:

program	                    user
Please choose a type:	
1 --> int	
2 --> double	
3 --> string	            3
Please enter a string:	    hello
hello*	

Example 2:

program	                    user
Please choose a type:	
1 --> int	
2 --> double	            2
3 --> string	
Please enter a double:	    1.5
2.5
*/

using System;

class IntDoubleString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");

        int choice = int.Parse(Console.ReadLine());
       
        switch (choice)
	    {
            case 1: 
                Console.WriteLine("Please enter an integer number");
                int intType;
                if (int.TryParse(Console.ReadLine(), out intType))
                {
                    int intResult = intType + 1;
                    Console.WriteLine(intResult);
                }
                else
                {
                    Console.WriteLine("That's not of type int!");
                }                
                break;
            case 2: 
                Console.WriteLine("Please enter a double");
                double doubleType;
                if (double.TryParse(Console.ReadLine(), out doubleType))
                {
                    double doubleResult = doubleType + 1;
                    Console.WriteLine(doubleResult);
                }
                else
                {
                    Console.WriteLine("That's not of type double!");
                }      
                
                break;
            case 3: 
                Console.WriteLine("Please enter a string");
                string stringType = Console.ReadLine();
                Console.WriteLine(stringType + "*");
                break;
            default:
                Console.WriteLine("Wrong input!");
                break;
	    }        
    }
}

