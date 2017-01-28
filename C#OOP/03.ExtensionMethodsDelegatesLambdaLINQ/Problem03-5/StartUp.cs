namespace Problem3_5
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var students = new[]
            {
                new { FirstName = "Ivan", LastName = "Popov", Age = 23 },
                new { FirstName = "Denitsa", LastName = "Laleva", Age = 15 },
                new { FirstName = "Svetoslav", LastName = "Nenov", Age = 30 },
                new { FirstName = "George", LastName = "Stefanov", Age = 18 },
                new { FirstName = "Martin", LastName = "Dimov", Age = 27 },
                new { FirstName = "Ivan", LastName = "Tipov", Age = 24 }
            };

            Console.WriteLine("Students with first names before last");

            // first before last
            var fblStudents = students
                .Where(s => string.Compare(s.FirstName, s.LastName) < 0)
                .ToArray();
				
			//var fblStudents = students
            //    .Where(st => st.FirstName.CompareTo(st.LastName) == -1);

            foreach (var student in fblStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            Console.WriteLine("\nStudents between 18 and 24 years");

            // age range
            var ageRangeStudents = students
                .Where(s => s.Age >= 18 && s.Age <= 24)
                .Select(s => s.FirstName + " " + s.LastName);

            foreach (var student in ageRangeStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\nSorted students in descending order");

            // sort students with extension methods and lambda expressions
            var sortedStudents = students
                .OrderByDescending(s => s.FirstName)
                .ThenByDescending(s => s.LastName);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            Console.WriteLine("\nSorted students in descending order with LINQ");

            // sort students with LINQ
            var sortedStudentsLinq =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            foreach (var student in sortedStudentsLinq)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}