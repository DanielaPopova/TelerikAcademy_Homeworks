using System;
using System.Text;

class StrangeLandNumbers
{
    static void Main()
    {
        string strangelandNumber = Console.ReadLine();
       
        var base7 = new StringBuilder();

        for (int i = 0; i < strangelandNumber.Length; i++)
        {
            char symbol = strangelandNumber[i];

            if (symbol == 'f' || symbol == 'b' || symbol == 'o' || symbol == 'm' || symbol == 'l' || symbol == 'p' || symbol == 'h')
            {
                switch (symbol)
                {
                    case 'f': symbol = '0'; break;
                    case 'b': symbol = '1'; break;
                    case 'o': symbol = '2'; break;
                    case 'm': symbol = '3'; break;
                    case 'l': symbol = '4'; break;
                    case 'p': symbol = '5'; break;
                    case 'h': symbol = '6'; break;
                }

                base7.Append(symbol);
            }
        }       

        long decimalRep = 0;

        for (int i = 0; i < base7.Length; i++)
        {
            int digit = int.Parse(base7[i].ToString());
            decimalRep = digit + decimalRep * 7;
        }

        Console.WriteLine(decimalRep);        
    }
}

