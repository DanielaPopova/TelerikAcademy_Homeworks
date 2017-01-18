namespace Academy.Models
{
    using System;

    using Models.Enums;
    using Models.Contracts;
    using Core.Providers;

    public class VideoResource : LectureResource, ILectureResource
    {
        public VideoResource(ResourceType type, string name, string url, DateTime uploadedOn)
            :base(ResourceType.Video, name, url)
        {            
            this.UploadedOn = uploadedOn;
        }

        public DateTime UploadedOn { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format("     - Uploaded on: {0}", this.UploadedOn);
        }
    }
}
