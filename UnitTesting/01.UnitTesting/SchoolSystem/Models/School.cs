namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolSystem.Contracts;
    using Common;
    using System.Text;

    public class School : ISchool
    {
        private string name;
        private ICollection<ICourse> courses;
        private ICollection<IStudent> students;

        public School(string name)
        {
            this.SchoolName = name;
            this.courses = new List<ICourse>();
            this.students = new List<IStudent>();
        }

        public string SchoolName
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Name cannot be null or empty!");
                this.name = value;
            }
        }

        public IEnumerable<ICourse> Courses
        {
            get
            {
                return new List<ICourse>(this.courses);
            }
        }

        public IEnumerable<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }
        }

        public void AddCourse(ICourse course)
        {
            Validator.CheckIfNull(course);

            if (this.courses.Contains(course))
            {
                throw new ArgumentException("This course is already in the list!");
            }

            this.courses.Add(course);
        }

        public void AdmitStudent(IStudent student)
        {
            Validator.CheckIfNull(student);

            if (this.students.Contains(student))
            {
                throw new ArgumentException("This student is already in the list!");
            }

            this.students.Add(student);
        }

        public void RemoveCourse(ICourse course)
        {
            Validator.CheckIfNull(course);

            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("There is no such course in the list!");
            }

            this.courses.Remove(course);
        }

        public void ExpellStudent(IStudent student)
        {
            Validator.CheckIfNull(student);

            if (!this.students.Contains(student))
            {
                throw new ArgumentException("There is no such student in the list!");
            }

            StudentIDGenerator.allIDs.Remove(student.ID);  //student is expelled, her/his id is back in the game
            this.students.Remove(student);
        }

        //only for console testing
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("---School: {0}---", this.SchoolName));

            if (this.courses.Count != 0)
            {
                foreach (var course in this.courses)
                {
                    result.AppendLine(string.Format("  {0}", course.ToString()));
                }
            }
            else
            {
                result.AppendLine("--No courses in this school--");
            }

            if (this.students.Count != 0)
            {
                foreach (var student in this.students)
                {
                    result.AppendLine(string.Format("  {0}", student.ToString()));
                }
            }
            else
            {
                result.AppendLine("--No students in this school--");
            }

            return result.ToString().TrimEnd();
        }
    }
}
