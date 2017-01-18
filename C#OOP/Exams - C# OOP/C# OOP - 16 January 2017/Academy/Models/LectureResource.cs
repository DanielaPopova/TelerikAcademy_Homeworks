namespace Academy.Models
{
    using System;
    using System.Text;

    using Contracts;
    using Enums;

    public abstract class LectureResource : ILectureResource
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 15;
        private const int UrlMinLength = 5;
        private const int UrlMaxLength = 150;

        private string name;
        private string url;
        
        public LectureResource(ResourceType type, string name, string url)
        {
            this.ResourceType = type;
            this.Name = name;
            this.Url = url;
        }

        public ResourceType ResourceType { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException(string.Format("Resource name should be between {0} and {1} symbols long!", NameMaxLength, NameMinLength));
                }

                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < UrlMinLength || value.Length > UrlMaxLength)
                {
                    throw new ArgumentException(string.Format("Resource url should be between {0} and {1} symbols long!", UrlMinLength, UrlMaxLength));
                }

                this.url = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("    * Resource:");
            result.AppendLine(string.Format("     - Name: {0}", this.Name));
            result.AppendLine(string.Format("     - Url: {0}", this.Url));
            result.AppendLine(string.Format("     - Type: {0}", this.ResourceType));

            return result.ToString().TrimEnd();
        }
    }
}
