namespace InheritanceAndPolymorphism.Models
{    
    using System.Collections.Generic;
    
    public class OffsiteCourse : Course
    { 
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {            
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>(), null)
        {
        }

        public OffsiteCourse(string courseName) 
            : this(courseName, null, new List<string>(), null)
        {
        }

        public string Town { get; set; }

        public override string ToString()
        {
            var baseToString = base.ToString();
            var result = baseToString.Substring(0, baseToString.Length - 2);

            if (this.Town != null)
            {
                result += "; Town = ";
                result += this.Town;
            }

            result += " }";

            return result;
        }
    }
}
