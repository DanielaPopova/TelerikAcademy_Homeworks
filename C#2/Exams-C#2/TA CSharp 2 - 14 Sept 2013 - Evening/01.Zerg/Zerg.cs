using System;
using System.Text;

class Zerg
{
    static void Main()
    {
        string zergMessage = Console.ReadLine();
        string[] words = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };

        var base15 = new StringBuilder();

        for (int i = 0; i < zergMessage.Length; i += 4)
        {
            string word = zergMessage.Substring(i, 4);

            for (int j = 0; j < words.Length; j++)
            {
                if (word == words[j])
                {
                    string symbol = j.ToString();

                    switch (symbol)
                    {
                        case "10": symbol = "A"; break;
                        case "11": symbol = "B"; break;
                        case "12": symbol = "C"; break;
                        case "13": symbol = "D"; break;
                        case "14": symbol = "E"; break;
                    }

                    base15.Append(symbol);
                }
            }
        }

        long decRepresentation = 0;

        for (int i = 0; i < base15.Length; i++)
        {
            string digit = base15[i].ToString();

            switch (digit)
            {
                case "A": digit = "10"; break;
                case "B": digit = "11"; break;
                case "C": digit = "12"; break;
                case "D": digit = "13"; break;
                case "E": digit = "14"; break;                
            }

            decRepresentation = int.Parse(digit) + decRepresentation * 15;
        }

        Console.WriteLine(decRepresentation);
    }
}

