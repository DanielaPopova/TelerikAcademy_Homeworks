namespace Problem09_15.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class StudentListExtension
    {
        public static List<Student> GroupTwoStudents(this List<Student> students)
        {
            var groupTwo =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            return groupTwo.ToList();

            // var grouptTwo = students
            //    .Where(s => s.GroupNumber == 2)
            //    .OrderBy(s => s.FirstName)
            //    .ToList();

            // return grouptTwo;
        }

        public static List<Student> StudentsWithTwoMarksTwo(this List<Student> students)
        {
            int count = 0;
            List<Student> weakStudents = new List<Student>();

            foreach (var student in students)
            {
                foreach (var mark in student.Marks)
                {
                    if (mark == 2)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    weakStudents.Add(student);
                }

                count = 0;
            }

            return weakStudents;
        }

        public static void GroupStudentsByGroupNumber(this List<Student> students)
        {
            var groups = new List<int>();

            foreach (var student in students)
            {
                int groupNum = student.GroupNumber;

                if (!groups.Contains(groupNum))
                {
                    groups.Add(groupNum);
                }
            }

            foreach (var groupNum in groups)
            {
                Console.WriteLine("Group {0}", groupNum);

                foreach (var student in students)
                {
                    if (student.GroupNumber.Equals(groupNum))
                    {
                        Console.WriteLine(student.FirstName + " " + student.LastName);
                    }
                }
            }             
        }
    }
}
