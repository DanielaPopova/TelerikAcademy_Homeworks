using System;

class EnterNumbers
{
    static void Main()
    {
        try
        {
            int[] numbers = new int[12];
            numbers[0] = 1;
            numbers[numbers.Length - 1] = 100;

            bool correct = false;

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                numbers[i] = ReadNumber();                
            }

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    correct = true;
                }
                else
                {
                    throw new SystemException();
                }
            }

            if (correct)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == numbers[numbers.Length - 1])
                    {
                        Console.Write(numbers[i]);                        
                    }
                    else
                    {
                        Console.Write(numbers[i] + " < ");
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Exception");
        }
        catch (SystemException)
        {
            Console.WriteLine("Exception");
        }
    }

    static int ReadNumber(int start = 1, int end = 100)
    {
        int number;
        try
        {
            number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new SystemException();
            }
        }
        catch (FormatException)
        {
            throw new FormatException();
        }

        return number;       
    }
}

/*
Description

Write a method ReadNumber(int start, int end) that enters an integer number in a given range ( start, end ).

If an invalid number or non-number text is entered, the method should throw an exception.
Using this method write a program that enters 10 numbers: a1, a2, ..., a10, such that 0 < a1 < ... < a10 < 100
Input

You will receive 10 lines of input, each consisted of an integer number
a1
a2
...
a10
Output

Print 0 < a1 < ... < a10 < 100
Or Exception if the above inequality is not true
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
5
7
15
29
46
47
60
70
89
98	        0 < 5 < 7 < 15 < 29 < 46 < 47 < 60 < 70 < 89 < 98 < 100
 * 
87
10
29
28
43
58
95
41
2
46	        Exception
 * 
5
11
20
27
49
41
52
81
89
99          Exception	
*/
