using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            return new Student(username, (Track)Enum.Parse(typeof(Track), track));
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {            
            return new Trainer(username, technologies.Split(','));
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            return new Course(name, int.Parse(lecturesPerWeek), DateTime.Parse(startingDate));
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {              
            return new Lecture(name, DateTime.Parse(date), trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            switch (type)
            {
                case "video":                    
                    return new VideoResource(ResourceType.Video, name, url, currentDate);
                case "presentation":                    
                    return new PresentationResource(ResourceType.Presentation, name, url);
                case "demo":                    
                    return new DemoResource(ResourceType.Demo, name, url);
                case "homework":                    
                    return new HomeworkResource(ResourceType.Homework, name, url, currentDate.AddDays(7));
                default:
                    throw new ArgumentException("Invalid lecture resource type");
            }
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            return new CourseResult(course, float.Parse(examPoints), float.Parse(coursePoints));
        }
    }
}
