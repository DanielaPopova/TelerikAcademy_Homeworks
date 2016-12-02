using System;
using System.Collections.Generic;
using System.Numerics;

class BunnyFactory
{
    static void Main()
    {
        string input = Console.ReadLine();
        var numbers = new List<int>();

        while (input != "END")
        {           
            numbers.Add(int.Parse(input));
            input = Console.ReadLine();
        }

        int cycle = 1;

        for (int i = 0; i < numbers.Count; i++)
        {
            int sumCycle = 0;
            BigInteger sumCages = 0;
            BigInteger productCage = 1;

            if (cycle > numbers.Count)
            {
                break;
            }

            for (int j = 0; j < cycle; j++)
            {
                sumCycle += numbers[j];
            }

            if (sumCycle >= numbers.Count - i)
            {
                break;
            }

            for (int k = cycle; k < sumCycle + cycle; k++)
            {
                sumCages += numbers[k];
                productCage *= numbers[k];
            }

            string result = sumCages.ToString() + productCage.ToString();
            for (int l = i + sumCycle + 1; l < numbers.Count; l++)
            {
                result += numbers[l].ToString();
            }

            result = result.Replace("0", "");
            result = result.Replace("1", "");

            var newNumbers = new List<int>();
            for (int m = 0; m < result.Length; m++)
            {
                newNumbers.Add(int.Parse(result[m].ToString()));
            }

            numbers = newNumbers;

            cycle++;
        }

        Console.WriteLine(String.Join(" ", numbers));
    }
}

