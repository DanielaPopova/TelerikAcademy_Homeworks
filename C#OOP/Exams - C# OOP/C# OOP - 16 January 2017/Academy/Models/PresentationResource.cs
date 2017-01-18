namespace Academy.Models
{
    using System;

    using Models.Contracts;
    using Models.Enums;

    public class PresentationResource : LectureResource, ILectureResource
    {
        public PresentationResource(ResourceType type, string name, string url)
            : base(ResourceType.Presentation, name, url)
        {

        }
    }
}
