using System;
using System.Text;

class ReverseNumber
{
    static void Main()
    {
        string number = Console.ReadLine();
        StringBuilder revNum = ReverseDecimalNumber(number);
        Console.WriteLine(revNum);
    }

    static StringBuilder ReverseDecimalNumber(string number) 
    {
        StringBuilder reversedNum = new StringBuilder();
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char lastDigit = number[i];            
            reversedNum.Append(lastDigit);
        }

        return reversedNum;
    }
}

/*
using System;

class Program
{
    static void Main()
    {
        string number = Console.ReadLine();
        Console.WriteLine(ReverseDigitsOfNumber(number));
    }

    static string ReverseDigitsOfNumber(string number)
    {
        char[] numbers = number.ToCharArray();
        Array.Reverse(numbers);

        return new string(numbers);
    }
}
*/

