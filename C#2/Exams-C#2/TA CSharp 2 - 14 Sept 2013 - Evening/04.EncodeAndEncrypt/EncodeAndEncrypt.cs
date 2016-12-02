using System;
using System.Text;

class EncodeAndEncrypt
{
    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        string encryptedMessage = Encrypt(message, cypher);        
        string encodedMessage = Encode(encryptedMessage + cypher);
        string result = encodedMessage + cypher.Length.ToString();

        Console.WriteLine(result);
    }

    public static string Encrypt(string message, string cypher)
    {
        int maxLength = Math.Max(message.Length, cypher.Length);
        var encrypteMessage = new StringBuilder(message);

        for (int i = 0; i < maxLength; i++)
        {
            char messageSymbol = encrypteMessage[i % message.Length];
            char cypherSymbol = cypher[i % cypher.Length];

            encrypteMessage[i % message.Length] = (char)(((messageSymbol - 'A') ^ (cypherSymbol - 'A')) + 'A');            
        }

        return encrypteMessage.ToString();
    }

    public static string Encode(string encryptedMessage)
    {
        int count = 1;
        char previousSymbol = encryptedMessage[0];
        var encodedMessage = new StringBuilder();

        for (int i = 1; i < encryptedMessage.Length; i++)
        {
            if (encryptedMessage[i] == previousSymbol)
            {
                count++;
            }
            else
            {
                if (count == 1)
                {
                    encodedMessage.Append(previousSymbol);
                }
                else if (count == 2)
                {
                    encodedMessage.Append(new string(previousSymbol, count));
                }
                else
                {
                    encodedMessage.Append(count + previousSymbol.ToString());
                }

                count = 1;
            }

            previousSymbol = encryptedMessage[i];
        }

        if (count == 1)
        {
            encodedMessage.Append(previousSymbol);
        }
        else if (count == 2)
        {
            encodedMessage.Append(new string(previousSymbol, count));
        }
        else
        {
            encodedMessage.Append(count + previousSymbol.ToString());
        }        

        return encodedMessage.ToString();
    }
}

