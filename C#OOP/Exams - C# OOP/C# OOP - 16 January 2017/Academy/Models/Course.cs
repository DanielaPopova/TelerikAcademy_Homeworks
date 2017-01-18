namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Academy.Models.Contracts;

    public class Course : ICourse
    {
        private const int CourseNameMinLength = 3;
        private const int CourseNameMaxLength = 45;
        private const int LecturesPerWeekMin = 1;
        private const int LecturesPerWeekMax = 7;

        private string name;
        private int lecturesPerWeek;        
                
        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;          
            this.LecturesPerWeek = lecturesPerWeek;           
            this.StartingDate = startingDate;
            this.EndingDate = startingDate.AddDays(30);
            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
        }
                
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {  
                if (string.IsNullOrEmpty(value) || value.Length < CourseNameMinLength || value.Length > CourseNameMaxLength)
                {
                    throw new ArgumentException(string.Format("The name of the course must be between {0} and {1} symbols!", CourseNameMinLength, CourseNameMaxLength));
                }

                this.name = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                if (value < LecturesPerWeekMin || value > LecturesPerWeekMax)
                {
                    throw new ArgumentException(string.Format("The number of lectures per week must be between {0} and {1}!", LecturesPerWeekMin, LecturesPerWeekMax));
                }

                this.lecturesPerWeek = value;
            }
        }

        public DateTime StartingDate { get; set; }        

        public DateTime EndingDate { get; set; }        
        
        public IList<IStudent> OnsiteStudents { get; }       

        public IList<IStudent> OnlineStudents { get; }        

        public IList<ILecture> Lectures { get; }       

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("* Course");
            result.AppendLine(string.Format(" - Name: {0}", this.Name));
            result.AppendLine(string.Format(" - Lectures per week: {0}", this.LecturesPerWeek));
            result.AppendLine(string.Format(" - Starting date: {0}", this.StartingDate));
            result.AppendLine(string.Format(" - Ending date: {0}", this.EndingDate));
            result.AppendLine(string.Format(" - Onsite: {0}", this.OnsiteStudents.Count));
            result.AppendLine(string.Format(" - Online: {0}", this.OnlineStudents.Count));
            result.AppendLine(" - Lectures:");

            if (this.Lectures.Count == 0)
            {
                result.AppendLine("  * There are no lectures in this course!");
            }
            else
            {
                foreach (var lecture in this.Lectures)
                {
                    result.AppendLine(lecture.ToString());
                }
            }           

            return result.ToString().TrimEnd();
        }
    }
}
