namespace RangeExceptions
{
    using System;
    using RangeExceptions.Exceptions;
    
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter number:");
                int inputNumber = int.Parse(Console.ReadLine());

                if (inputNumber < 1 || inputNumber > 100)
                {
                    throw new InvalidRangeException<int>("Invalid input!", 1, 100);
                }
                else
                {
                    Console.WriteLine("Correct -> {0}", inputNumber);
                }
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine("Wrong input! Number should be in range [{0} - {1}]", ire.RangeStart, ire.RangeEnd);
            }
            
            // DateTime
            try
            {
                Console.WriteLine("Enter date dd.mm.yyyy:");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", null);

                if (date.Year < 1980 || date.Year > 2013)
                {
                    throw new InvalidRangeException<DateTime>("Invalid input!", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
                else
                {
                    Console.WriteLine("Correct -> {0}", date);
                }
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine("Wrong input! Date must be in range {0:dd/MM/yyyy} - {1:dd/MM/yyyy}", ire.RangeStart, ire.RangeEnd);
            }
        }
    }
}
