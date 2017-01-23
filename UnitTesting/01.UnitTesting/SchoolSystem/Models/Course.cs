namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolSystem.Common;
    using Contracts;
    using System.Text;

    public class Course : ICourse
    {
        private string courseName;
        private ICollection<IStudent> students;

        public Course(string courseName)
        {
            this.CourseName = courseName;
            this.students = new List<IStudent>();
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Course name cannot be null or empty!");
                this.courseName = value;
            }
        }

        public IEnumerable<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }
        }

        public void AddStudent(IStudent student)
        {
            Validator.CheckIfNull(student);

            if (this.students.Count > GlobalConstants.MaxStudentsInCourse)
            {
                throw new ArgumentException(string.Format("There cannot be more than {0} students in this course!", GlobalConstants.MaxStudentsInCourse));
            }

            if (this.students.Contains(student))
            {
                throw new ArgumentException("This student is already in the list!");
            }

            this.students.Add(student);            
        }

        public void RemoveStudent(IStudent student)
        {
            Validator.CheckIfNull(student);

            if (!this.students.Contains(student))
            {
                throw new ArgumentException("This student doesn't exist in the list!");
            }

            this.students.Remove(student);
        }

        //only for console testing
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("Course Name: {0}", this.CourseName));

            if (this.students.Count != 0)
            {
                result.AppendLine(string.Format("Students in this course: {0}", this.students.Count));

                foreach (var student in this.students)
                {
                    result.AppendLine(string.Format("-{0}", student.ToString()));
                }
            }
            else
            {
                result.AppendLine("--No students in this course!--");
            }

            return result.ToString().TrimEnd();
        }
    }
}
