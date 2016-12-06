using System;
using System.Numerics;

class CryptoCS
{
    static void Main()
    {
        string base26 = Console.ReadLine();
        string operation = Console.ReadLine();
        string base7 = Console.ReadLine();

        BigInteger base26number = 0;

        foreach (var symbol in base26)
        {
            base26number = symbol - 'a' + base26number * 26;
        }

        BigInteger base7number = 0;

        foreach (var symbol in base7)
        {
            base7number = symbol - '0' + base7number * 7;
        }

        BigInteger result = 0;

        if (operation == "+")
        {
            result = base26number + base7number;
        }
        else
        {
            result = base26number - base7number;
        }

        string base9 = string.Empty;

        do
        {
            base9 = (result % 9).ToString() + base9;
            result /= 9;
        }
        while (result > 0);

        Console.WriteLine(base9);
    }    
}

