using System;

class XExpression
{
    static void Main()
    {
        string expression = Console.ReadLine();

        double result = 0;
        double resultBracket = 0;

        char sign = '+';
        char signBracket = '+';

        bool inBracket = false;

        for (int i = 0; i < expression.Length; i++)
        {
            char currSymbol = expression[i];

            if (currSymbol == '+' || currSymbol == '-' || currSymbol == '*' || currSymbol == '/')
            {
                if (inBracket)
                {
                    signBracket = currSymbol;
                }
                else
                {
                    sign = currSymbol;
                }
            }

            if (currSymbol >= 48 && currSymbol <= 57)
            {
                if (inBracket)
                {
                    switch (signBracket)
                    {
                        case '+': resultBracket += (currSymbol - '0'); break;
                        case '-': resultBracket -= (currSymbol - '0'); break;
                        case '*': resultBracket *= (currSymbol - '0'); break;
                        case '/': resultBracket /= (currSymbol - '0'); break;
                    }
                }
                else
                {
                    switch (sign)
                    {
                        case '+': result += (currSymbol - '0'); break;
                        case '-': result -= (currSymbol - '0'); break;
                        case '*': result *= (currSymbol - '0'); break;
                        case '/': result /= (currSymbol - '0'); break;
                    }
                }                
            }

            if (currSymbol == '(')
            {
                inBracket = true;
                continue;
            }

            if (currSymbol == ')')
            {
                inBracket = false;

                switch (sign)
                {
                    case '+': result += resultBracket; break;
                    case '-': result -= resultBracket; break;
                    case '*': result *= resultBracket; break;
                    case '/': result /= resultBracket; break;
                }

                resultBracket = 0;
                signBracket = '+';
            }
        }

        Console.WriteLine(result.ToString("F2"));
    }
}

