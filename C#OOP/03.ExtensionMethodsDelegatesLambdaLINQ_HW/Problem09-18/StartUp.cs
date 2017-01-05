namespace Problem09_15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Problem09_15.Extensions;

    public class StartUp
    {
        public static void Main()
        {
            var students = new List<Student>
            {
                new Student("Ivan", "Georgiev", 456406, "028774556", "i.georg@abv.bg", new List<int> { 4, 2, 6, 2, 3 }, 10),
                new Student("Peter", "Videnov", 568908, "0894652321", "peter.v@gmail.com", new List<int> { 3, 5, 2, 2, 5 }, 2),
                new Student("Galia", "Laleva", 124515, "029756352", "galia_laleva@abv.bg", new List<int> { 5, 5, 3, 6, 4 }, 2),
                new Student("Stoian", "Toshev", 659806, "0883224530", "st.toshev@yahoo.com", new List<int> { 2, 4, 6, 2, 2 }, 5),
                new Student("Alex", "Dimov", 250115, "0888245666", "alex-dimovg@abv.bg", new List<int> { 4, 5, 6, 6, 3 }, 7),
            };
            
            // task 9 - students from group 2, ordered by first name
            var groupTwoStudents = students
                .Where(s => s.GroupNumber == 2)
                .OrderBy(s => s.FirstName);

            foreach (var student in groupTwoStudents)
            {
                Console.WriteLine("Name: " + student.FirstName + " " + student.LastName + " Group: " + student.GroupNumber);
            }

            Console.WriteLine(new string('-', 40));

            // task 10 - like task 9 but with extension method
            var groupTwo = students.GroupTwoStudents();

            foreach (var student in groupTwo)
            {
                Console.WriteLine("Name: " + student.FirstName + " " + student.LastName + " Group: " + student.GroupNumber);                
            }
            
            Console.WriteLine(new string('-', 40));

            // task 11 - students with abv.bg mail
            var abvStudents = students
                .Where(s => s.Email.EndsWith("abv.bg"));

            foreach (var student in abvStudents)
            {
                Console.WriteLine("Name: " + student.FirstName + " " + student.LastName + " Email: " + student.Email);
            }

            Console.WriteLine(new string('-', 40));

            // task 12 - extract students with phones in Sofia
            var sofiaStudents = students
                .Where(s => s.PhoneNumber.StartsWith("02"));                                

            foreach (var student in sofiaStudents)
            {
                Console.WriteLine("Name: " + student.FirstName + " " + student.LastName + " Phone: " + student.PhoneNumber);
            }

            Console.WriteLine(new string('-', 40));

            // task 13 - extract students with mark 6 into new anonymous type
            var excellentStudents = students
                .Where(s => s.Marks.Contains(6))
                .Select(s => new { FullName = s.FirstName + " " + s.LastName, Marks = s.Marks });

            foreach (var student in excellentStudents)
            {
                Console.WriteLine("Full Name: " + student.FullName + " Marks: " + string.Join(" ", student.Marks));
            }

            Console.WriteLine(new string('-', 40));

            // task 14
            var studentsWithTwoMarksTwo = students.StudentsWithTwoMarksTwo();

            foreach (var student in studentsWithTwoMarksTwo)
            {
                Console.WriteLine("Full Name: " + student.FirstName + " " + student.LastName  + " Marks: " + string.Join(" ", student.Marks));
            }

            Console.WriteLine(new string('-', 40));

            // task 15 - extract all marks of students 2006
            var students06 = students
                .Where(s => s.FacultyNumber.ToString().EndsWith("06"))
                .Select(s => s.Marks);

            foreach (var marks in students06)
            {
                Console.WriteLine("Marks: {0}", string.Join(" ", marks));
            }

            Console.WriteLine(new string('-', 40));

            // task 16 - extract students from "Mathematics" using join operator
            var groups = new List<Group>
            {
                new Group(2, "Mathematics"),
                new Group(10, "Criminology"),
                new Group(5, "Genetics"),                
                new Group(4, "Psychology")
            };

            var mathStudents =
                from student in students
                where student.GroupNumber == 2
                join someGroup in groups on student.GroupNumber equals someGroup.GroupNumber
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Department = someGroup.Department
                };

            foreach (var student in mathStudents)
            {
                Console.WriteLine("Name: {0} Department: {1}", student.FullName, student.Department);
            }

            Console.WriteLine(new string('-', 40));
            
            // task 18 - extract students grouped by group number
            var groupedNumberStudents = students
                .GroupBy(s => s.GroupNumber)                        // .Select(gr => gr.Select(st => new {Group = gr.Key, Name = st.FirstName + " " + st.LastName}))
                .ToList();

            foreach (var group in groupedNumberStudents)
            {
                Console.WriteLine("Group: {0}", group.Key);

                foreach (var student in group)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
            }

            Console.WriteLine(new string('-', 40));

            // task 19 - like task 18 but with extension method
            students.GroupStudentsByGroupNumber();
        }
    }
}
