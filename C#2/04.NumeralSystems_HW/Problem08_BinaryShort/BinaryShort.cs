using System;

class SortingArray
{
    static void Main()
    {
        short signedShort = short.Parse(Console.ReadLine());

        string binary = string.Empty;        

        for (int i = 0; i < 16; i++)
        {
            string sign = (signedShort & 1) == 0 ? "0" : "1";
            binary = sign + binary;
           
            signedShort >>= 1;
        }

        Console.WriteLine(binary.PadLeft(16, '0'));
    }   
}