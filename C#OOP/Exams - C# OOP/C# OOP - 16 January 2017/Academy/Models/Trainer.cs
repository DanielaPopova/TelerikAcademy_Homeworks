namespace Academy.Models
{
    using System;
    using System.Collections.Generic;

    using Academy.Models.Contracts;
    using System.Text;

    public class Trainer : User, ITrainer
    {
        public Trainer(string username, IList<string> technologies)
            : base(username)
        {            
            this.Technologies = technologies;
        }       

        public IList<string> Technologies { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("* Trainer:");
            result.AppendLine(string.Format(" - Username: {0}", this.Username));
            result.AppendLine(string.Format(" - Technologies: {0}", string.Join("; ", this.Technologies)));

            return result.ToString().TrimEnd();
        }           
    }
}
