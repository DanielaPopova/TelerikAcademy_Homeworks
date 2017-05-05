using ProjectManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace ProjectManager.Models
{
    using Contracts;
    using ProjectManager.Common.Providers;

    public class Project : IProject
    {
        private readonly Validator validator = new Validator();

        private string name;
        private DateTime startingDate;
        private DateTime endingDate;
        private State state;

        public Project(string name, DateTime startingDate, DateTime endingDate, State state)
        {
            this.Name = name;
            this.StartingDate = startingDate;
            this.EndingDate = endingDate;
            this.State = state;
            this.Users = new List<IUser>();
            this.Tasks = new List<ITask>();
        }

        [Required(ErrorMessage = "Project Name is required!")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.validator.Validate(value);
                this.name = value;
            }
        }

        [Range(typeof(DateTime), "1800-1-1", "2017-1-1", ErrorMessage = "Project StartingDate must be between 1800-1-1 and 2017-1-1!")]
        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }

            set
            {
                this.validator.Validate(value.ToString("yyyy-MM-dd"));
                this.startingDate = value;
            }
        }

        [Range(typeof(DateTime), "2018-1-1", "2144-1-1", ErrorMessage = "Project EndingDate must be between 2018-1-1 and 2144-1-1!")]
        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }

            set
            {
                this.validator.Validate(value.ToString("yyyy-MM-dd"));
                this.endingDate = value;
            }
        } 
               
        public State State
        {
            get
            {
                return this.state;
            }

            set
            {
                if (value != State.Active && value != State.Inactive)
                {
                    throw new ArgumentException("State coud only be Active or Inactive!");
                }

                this.state = value;
            }
        }
       
        public IList<IUser> Users { get; set; }

        public IList<ITask> Tasks { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Name: " + this.Name);
            builder.AppendLine("  Starting date: " + this.StartingDate.ToString("yyyy-MM-dd"));
            builder.AppendLine("  Ending date: " + this.EndingDate.ToString("yyyy-MM-dd"));
            builder.AppendLine("  State: " + this.State);
            builder.AppendLine("  Users: ");

            builder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Users));

            if (this.Users.Count == 0)
            {
                builder.AppendLine("  - This project has no users!");
                builder.AppendLine("  Tasks: ");
                builder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Tasks));
            }                

            if (this.Tasks.Count == 0)
            {
                builder.Append("  - This project has no tasks!");
            }

            return builder.ToString();
        }
    }
}