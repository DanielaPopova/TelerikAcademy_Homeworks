using System;

class Enigmanation
{
    static void Main()
    {
        string expression = Console.ReadLine();

        double result = 0;
        double resultInBracket = 0;

        char sign = '+';
        char signInBracket = '+';

        bool inBracket = false;

        foreach (char symbol in expression)
        {
            if (symbol == '(')
            {
                inBracket = true;
                continue;
            }

            if (symbol == ')')
            {
                inBracket = false;

                switch (sign)
                {
                    case '+': result += resultInBracket; break;
                    case '-': result -= resultInBracket; break;
                    case '%': result %= resultInBracket; break;
                    case '*': result *= resultInBracket; break;
                }

                resultInBracket = 0;
                signInBracket = '+';
            }

            if (symbol == '+' || symbol == '-' || symbol == '%' || symbol == '*')
            {
                if (inBracket)
                {
                    signInBracket = symbol;
                }
                else
                {
                    sign = symbol;
                }
            }

            if (Char.IsDigit(symbol))
            {
                int currNumber = symbol - '0';

                if (inBracket)
                {
                    switch (signInBracket)
                    {
                        case '+': resultInBracket += currNumber; break;
                        case '-': resultInBracket -= currNumber; break;
                        case '%': resultInBracket %= currNumber; break;
                        case '*': resultInBracket *= currNumber; break;
                    }
                }
                else
                {
                    switch (sign)
                    {
                        case '+': result += currNumber; break;
                        case '-': result -= currNumber; break;
                        case '%': result %= currNumber; break;
                        case '*': result *= currNumber; break;
                    }
                }                
            }
        }

        Console.WriteLine(result.ToString("F3"));
    }
}

