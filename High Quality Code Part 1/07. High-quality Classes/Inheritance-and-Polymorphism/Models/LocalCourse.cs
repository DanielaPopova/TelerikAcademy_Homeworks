namespace InheritanceAndPolymorphism.Models
{    
    using System.Collections.Generic;
    
    public class LocalCourse : Course
    {
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
           : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {            
        }

        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {            
        }

        public LocalCourse(string courseName) 
            : this(courseName, null, new List<string>(), null)
        {            
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var baseToString = base.ToString();
            var result = baseToString.Substring(0, baseToString.Length - 2);

            if (this.Lab != null)
            {
                result += "; Lab = ";
                result += this.Lab;
            }

            result += " }";

            return result;
        }
    }
}
