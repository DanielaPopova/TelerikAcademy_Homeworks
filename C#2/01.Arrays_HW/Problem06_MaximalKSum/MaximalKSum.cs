using System;

class MaximalKSum
{
    static void Main()
    {
        //Console.Write("Enter number of elements for the array: n = ");
        int n = int.Parse(Console.ReadLine());

        //Console.WriteLine("Enter k elements, k < n");
        int k = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        int sum = 0;

        //Console.WriteLine("Insert elements of the array, each on a separate line");
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());            
        }

        Array.Sort(numbers);

        for (int i = numbers.Length - 1; i >= numbers.Length - k; i--)
        {
            //Console.WriteLine(numbers[i] + " ");            
                sum += numbers[i];
                //Console.Write(numbers[i] + " ");
        }
        //Console.WriteLine();
        //Console.WriteLine("SUM = {0}", sum);
        Console.WriteLine(sum);
    }
}

