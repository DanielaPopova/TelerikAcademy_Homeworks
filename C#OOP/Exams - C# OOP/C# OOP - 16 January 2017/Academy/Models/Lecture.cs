namespace Academy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class Lecture : ILecture
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 30;

        private string name;       

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException(string.Format("Lecture's name should be between {0} and {1} symbols long!", NameMinLength, NameMaxLength));
                }

                this.name = value;
            }
        }

        public DateTime Date { get; set; }        

        public ITrainer Trainer { get; set; }        

        public IList<ILectureResource> Resources { get; }       

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("  * Lecture:");
            result.AppendLine(string.Format("   - Name: {0}", this.Name));
            result.AppendLine(string.Format("   - Date: {0}", this.Date));
            result.AppendLine(string.Format("   - Trainer username: {0}", this.Trainer.Username));
            result.AppendLine("   - Resources:");

            if (this.Resources.Count == 0)
            {
                result.AppendLine("    * There are no resources in this lecture.");
            }
            else
            {
                foreach (var resource in this.Resources)
                {
                    result.AppendLine(resource.ToString());
                }
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
