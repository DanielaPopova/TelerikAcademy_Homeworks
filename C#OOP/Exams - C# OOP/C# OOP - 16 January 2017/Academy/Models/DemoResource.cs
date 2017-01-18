namespace Academy.Models
{
    using System;

    using Contracts;
    using Academy.Models.Enums;
    using System.Text;

    public class DemoResource : LectureResource, ILectureResource
    {
        public DemoResource(ResourceType type, string name, string url)
            : base(ResourceType.Demo, name, url)
        {

        }        
    }
}
