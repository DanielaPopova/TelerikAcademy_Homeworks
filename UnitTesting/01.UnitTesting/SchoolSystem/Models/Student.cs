namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolSystem.Contracts;
    using SchoolSystem.Common;
    using System.Text;

    public class Student : IStudent
    {
        private string name;
        private uint id;
        private ICollection<string> courses;    

        public Student(string name, uint id)
        {
            this.Name = name;
            this.ID = StudentIDGenerator.GenerateID(id);
            this.courses = new List<string>();          
        }

        public string Name
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

        public uint ID
        {
            get
            {
                return this.id;
            }

            private set
            {
                Validator.CheckUIntRange(value, GlobalConstants.MinStudentID, GlobalConstants.MaxStudentID, string.Format("IDs are in range {0} - {1}", GlobalConstants.MinStudentID, GlobalConstants.MaxStudentID));                

                this.id = value;
            }
        }

        public IEnumerable<string> Courses
        {
            get
            {
                return new List<string>(this.courses);
            }
        }

        public void JoinCourse(ICourse course)
        {
            Validator.CheckIfNull(course);           
                  
            course.AddStudent(this);
            this.courses.Add(course.CourseName);
        }

        public void LeaveCourse(ICourse course)
        {
            Validator.CheckIfNull(course);           
            
            course.RemoveStudent(this);
            this.courses.Remove(course.CourseName);
        }

        //only for console testing
        public override string ToString()
        {
            int count = 1;
            var result = new StringBuilder();

            result.AppendLine(string.Format("Student: {0} ID: {1}", this.Name, this.ID));

            if (this.courses.Count != 0)
            {
                result.AppendLine(string.Format("Courses: {0}", this.courses.Count));

                foreach (var course in this.courses)
                {
                    result.AppendLine(string.Format("{0}. {1}", count, course.ToString()));
                    count++;
                }
            }
            else
            {
                result.AppendLine("   --No courses--");
            }

            return result.ToString().TrimEnd();
        }
    }
}
