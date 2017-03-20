namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public abstract class Course : ICourse
    {
        private string name;

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public Course(string courseName) 
            : this(courseName, null, new List<string>())
        {                                        
        }
                
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }

        public ICollection<string> Students { get; set; }        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());            
            result.Append(" }");

            return result.ToString();
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
