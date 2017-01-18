namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Utils.Contracts;
    using Enums;

    public class Student : User, IStudent
    {       
        private Track track;
        
        public Student(string username, Track track)
            :base(username)
        {            
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
        }        
      
        public Track Track
        {
            get
            {
                return this.track;
            }

            set
            {
                if (!Enum.IsDefined(typeof(Track), value))
                {
                    throw new ArgumentException("The provided track is not valid!");
                }

                this.track = value;
            }
        }

        public IList<ICourseResult> CourseResults { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("* Student:");
            result.AppendLine(string.Format(" - Username: {0}", this.Username));
            result.AppendLine(string.Format(" - Track: {0}", this.Track));
            result.AppendLine(" - Course results:");

            if (this.CourseResults.Count == 0)
            {
                result.AppendLine("  * User has no course results!");
            }
            else
            {
                foreach (var courseResult in this.CourseResults)
                {
                    result.AppendLine(courseResult.ToString());
                }
            }           

            return result.ToString().TrimEnd();
        }
    }
}
