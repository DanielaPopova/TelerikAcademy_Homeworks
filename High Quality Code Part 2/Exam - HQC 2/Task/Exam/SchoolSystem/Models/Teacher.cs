namespace SchoolSystem.Models
{
    using System;

    using Contracts;
    using Enums;

    public class Teacher : Person, ITeacher
    {
        private const int MaxStudentMarks = 20;

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float value)
        {
            if (student.Marks.Count > MaxStudentMarks)
            {
                throw new ArgumentException($"A student cannot have more than {MaxStudentMarks} marks!");
            }

            var mark = new Mark(this.Subject, value);
            student.Marks.Add(mark);
        }
    }
}
