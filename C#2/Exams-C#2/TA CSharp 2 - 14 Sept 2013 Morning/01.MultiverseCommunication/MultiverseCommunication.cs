using System;
using System.Text;

class MultiverseCommunication
{
    static void Main()
    {
        string message = Console.ReadLine();

        StringBuilder base13Rep = new StringBuilder();

        for (int i = 0; i < message.Length; i += 3)
        {
            string word = message.Substring(i, 3);
            string base13 = string.Empty;

            switch (word)
            {
                case "CHU": base13 = "0"; break;
                case "TEL": base13 = "1"; break;
                case "OFT": base13 = "2"; break;
                case "IVA": base13 = "3"; break;
                case "EMY": base13 = "4"; break;
                case "VNB": base13 = "5"; break;
                case "POQ": base13 = "6"; break;
                case "ERI": base13 = "7"; break;
                case "CAD": base13 = "8"; break;
                case "K-A": base13 = "9"; break;
                case "IIA": base13 = "A"; break;
                case "YLO": base13 = "B"; break;
                case "PLA": base13 = "C"; break;
            }

            base13Rep.Append(base13);            
        }

        long decNumber = 0;

        for (int i = 0; i < base13Rep.Length; i++)
        {
            string digit = base13Rep[i].ToString();

            switch (digit)
            {
                case "A": digit = "10"; break;
                case "B": digit = "11"; break;
                case "C": digit = "12"; break;
            }

            decNumber = int.Parse(digit) + decNumber * 13;
        }
        Console.WriteLine(decNumber);
    }
}

