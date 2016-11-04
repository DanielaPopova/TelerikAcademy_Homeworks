/*
Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
Use Windows Calculator to find its hexadecimal representation.
Print the variable and ensure that the result is 254.
using System;
*/

using System;

class VariableInHexadecimalFormat
{
    static void Main()
    {
        int hexNumber = 0xFE;
        Console.WriteLine(hexNumber);

        //Convert decimal number to hexadecimal 
        int decNumber = 254;
        string decToHex = decNumber.ToString("X");
        Console.WriteLine(decToHex);
    }
}

