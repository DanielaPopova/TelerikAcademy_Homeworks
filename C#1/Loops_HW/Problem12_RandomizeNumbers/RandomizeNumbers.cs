/*
Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
Examples:

n	    randomized numbers 1…n
3	    2 1 3
10	    3 4 8 2 6 7 9 1 10 5
Note: The above output is just an example. Due to randomness, your program most probably will produce different results. You might need to use arrays.
*/

using System;

class RandomizeNumbers
{
    static void Main()
    {
        Console.Write("Enter how many numbers to be randomized: ");
        int count = int.Parse(Console.ReadLine());
        int[] numbers = new int[count + 1];
        Random randGen = new Random();
        int temp = 1;

        for (int i = 1; i < numbers.Length; i++)
        {
            //numbers[i] = i;
            temp = randGen.Next(1, numbers.Length);
            if (numbers[i] != temp)
            {
                numbers[i] = temp;
                Console.Write(numbers[i] + " ");  
            }
            else
            {
                numbers[i] = i;
            }
                

            
            
               
        }

        

        //Console.WriteLine(randGen.Next());
    }
}

