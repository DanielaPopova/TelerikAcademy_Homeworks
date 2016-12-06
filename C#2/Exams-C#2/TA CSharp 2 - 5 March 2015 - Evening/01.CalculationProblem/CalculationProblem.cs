using System;

class CalculationProblem
{
    static void Main()
    {
        string[] letterNumbers = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

        long sumLetters = 0;

        for (int i = 0; i < letterNumbers.Length; i++)
        {
            string currWord = letterNumbers[i];
            long currSum = 0;

            foreach (var symbol in currWord)
            {
                int digit = symbol - 'a';
                currSum = digit + currSum * 23;
            }

            sumLetters += currSum;
        }

        long result = sumLetters;
        string base23 = string.Empty;

        do
        {            
            char letter = (char)(sumLetters % 23 + 'a');
            sumLetters /= 23;

            base23 = letter + base23;
        }
        while (sumLetters > 0);

        Console.WriteLine("{0} = {1}", base23, result);
    }
}

