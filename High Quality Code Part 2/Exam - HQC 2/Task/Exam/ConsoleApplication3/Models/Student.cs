namespace SchoolSystem.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Enums;

    public class Student : Person, IStudent
    {
        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade { get; set; }

        public IList<IMark> Marks { get; private set; }

        public string ListMarks()
        {
            var result = new StringBuilder();
            var studentMarks = this.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

            if (this.Marks.Count == 0)
            {
                result.Append("This student has no marks.");
            }
            else
            {
                result.AppendLine("The student has these marks:");
                foreach (var mark in studentMarks)
                {
                    result.AppendLine(mark);
                }
            }

            return result.ToString();
        }
    }
}