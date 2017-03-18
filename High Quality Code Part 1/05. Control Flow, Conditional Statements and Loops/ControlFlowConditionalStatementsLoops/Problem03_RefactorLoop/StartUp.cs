namespace RefactorLoop
{
    using System;
    
    public class StartUp
    {
        public static void Main()
        {
            int size = 20;
            int expectedValue = 5;
            bool isFound = false;
            int[] numbers = new int[size];

            FillArrayWithRandomNumbers(numbers, 10);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);

                if (i % 10 == 0 && numbers[i] == expectedValue)
                {
                    isFound = true;
                    // Console.WriteLine("Index - {0}", i);
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine("Value found!");
            }           
        }

        public static void FillArrayWithRandomNumbers(int[] array, int maxRange)
        {
            var randomGen = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomGen.Next(0, maxRange);
            }
        }
    }
}
