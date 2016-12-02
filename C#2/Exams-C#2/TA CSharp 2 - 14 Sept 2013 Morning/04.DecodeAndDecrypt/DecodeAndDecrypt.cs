using System;
using System.Collections.Generic;
using System.Text;

class DecodeAndDecrypt
{
    static void Main()
    {
        string input = Console.ReadLine();

        //Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher

        //lengthOfCypher
        var digits = new List<int>();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(input[i]))
            {
                digits.Add(input[i] - '0');
            }
            else
            {
                break;
            }
        }

        digits.Reverse();

        int lengthOfCypher = 0;

        foreach (var digit in digits)
        {
            lengthOfCypher *= 10;
            lengthOfCypher += digit;
        }

        //Encode(Encrypt(message, cypher) + cypher)
        string encodedMessage = input.Substring(0, input.Length - digits.Count);

        //Encrypt(message, cypher) + cypher
        string decodedMessage = Decode(encodedMessage);

        //Encrypt(message, cypher)
        string encryptedMessage = decodedMessage.Substring(0, decodedMessage.Length - lengthOfCypher);

        //cypher
        string cypher = decodedMessage.Substring(decodedMessage.Length - lengthOfCypher);

        string message = Encrypt(encryptedMessage, cypher);

        Console.WriteLine(message);
    }

    public static string Decode(string encodedMessage)
    {
        var result = new StringBuilder();
        int count = 0;

        foreach (var symbol in encodedMessage)
        {
            if (char.IsDigit(symbol))
            {
                count *= 10;
                count += int.Parse(symbol.ToString());
            }
            else
            {
                if (count == 0)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append(symbol, count);
                    count = 0;
                }
            }
        }

        return result.ToString();
    }

    public static string Encrypt(string message, string cypher)
    {
        var result = new StringBuilder(message);

        int steps = Math.Max(message.Length, cypher.Length);

        for (int i = 0; i < steps; i++)
        {
            int messageIndex = i % message.Length;
            int cypherIndex = i % cypher.Length;
            result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
        }

        return result.ToString();
    }
}

