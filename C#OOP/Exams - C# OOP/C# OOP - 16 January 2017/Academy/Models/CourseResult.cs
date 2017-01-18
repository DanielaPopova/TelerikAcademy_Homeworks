namespace Academy.Models
{
    using System;

    using Contracts;
    using Enums;
    using Utils.Contracts;
    using System.Text;

    public class CourseResult : ICourseResult
    {
        private const int ExamPointsMin = 0;
        private const int ExamPointsMax = 1000;
        private const int CoursePointsMin = 0;
        private const int CoursePointsMax = 125;

        private float examPoints;
        private float coursePoints;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            this.Course = course;
            this.ExamPoints = examPoints;
            this.CoursePoints = coursePoints;
        }

        public ICourse Course { get; private set; }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }

            private set
            {
                if (value < ExamPointsMin || value > ExamPointsMax)
                {
                    throw new ArgumentException(string.Format("Course result's exam points should be between {0} and {1}!", ExamPointsMin, ExamPointsMax));
                }

                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }

            private set
            {
                if (value < CoursePointsMin || value > CoursePointsMax)
                {
                    throw new ArgumentException(string.Format("Course result's course points should be between {0} and {1}!", CoursePointsMin, CoursePointsMax));
                }

                this.coursePoints = value;
            }
        }
       
        public Grade Grade
        {
            get
            {
                if (this.ExamPoints >= 65 || this.CoursePoints >= 75)
                {
                    return Grade.Excellent;
                }

                if (this.ExamPoints <= 65  && this.ExamPoints >= 30 || this.CoursePoints <= 75 && this.CoursePoints >= 45)
                {
                    return Grade.Passed;
                }

                return Grade.Failed;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("  * {0}: Points - {1}, Grade - {2}", this.Course.Name, this.CoursePoints, this.Grade));

            return result.ToString().TrimEnd();
        }
    }
}
