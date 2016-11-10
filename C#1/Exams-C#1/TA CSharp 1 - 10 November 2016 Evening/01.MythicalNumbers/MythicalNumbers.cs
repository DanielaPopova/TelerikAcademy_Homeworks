using System;

class MythicalNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        double result = 0;

        int thirdDigit = number % 10;
        number /= 10;

        int secondDigit = number % 10;
        number /= 10;

        int firstDigit = number % 10;

        if (thirdDigit == 0)
        {
            result = firstDigit * secondDigit;
            Console.WriteLine((result).ToString("F2"));
        }
        else if (thirdDigit > 0 && thirdDigit <= 5)
        {
            result = (firstDigit * secondDigit) / (double)thirdDigit;
            Console.WriteLine(result.ToString("F2"));
        }
        else
        {
            result = (firstDigit + secondDigit) * thirdDigit;
            Console.WriteLine(result.ToString("F2"));
        }
    }
}

