namespace Academy.Models
{
    using System;

    using Contracts;
    using Models.Enums;
    using Core.Providers;

    public class HomeworkResource : LectureResource, ILectureResource
    {
        public HomeworkResource(ResourceType type, string name, string url, DateTime dueDate)
            : base(ResourceType.Homework, name, url)
        {
            this.DueDate = dueDate;
        }
        
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format("     - Due date: {0}", this.DueDate);
        }
    }
}
