namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;

    using Exceptions_Homework.Models;    

    public class ExceptionsHomework
    {
        public static void Main()
        {            
            Console.WriteLine("Checking Utils");
            var substr = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
            Console.WriteLine(Utils.ExtractEnding("Nakov", 4));
            Console.WriteLine(Utils.ExtractEnding("beer", 4));

            try
            {
                Console.WriteLine(Utils.ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nChecking Prime Method");
            if (Utils.CheckPrime(23))
            {
                Console.WriteLine("23 is prime");
            }
            else
            {
                Console.WriteLine("23 is not prime");
            }

            if (Utils.CheckPrime(33))
            {
                Console.WriteLine("33 is prime");
            }
            else
            {
                Console.WriteLine("33 is not prime");
            }

            Console.WriteLine("\nChecking Student exams");
            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalculateAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
