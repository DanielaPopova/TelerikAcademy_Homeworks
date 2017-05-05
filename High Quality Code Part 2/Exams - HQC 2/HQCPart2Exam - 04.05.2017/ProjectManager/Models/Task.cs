using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

using ProjectManager.Models.Contracts;
using ProjectManager.Models.Enums;

namespace ProjectManager.Models
{
    using Common.Providers;

    public class Task : ITask
    {
        private readonly Validator validator = new Validator();
        private string name;
        private IUser owner;
        private State state;
        
        public Task(string name, IUser owner, State state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.validator.Validate(value);
                this.name = value;
            }
        }

        [Required(ErrorMessage = "Task Owner is required")]
        public IUser Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                this.validator.Validate(value);
                this.owner = value;
            }            
        }

        public State State
        {
            get
            {
                return this.state;
            }

            private set
            {
                if (value != State.Pending && value != State.InProgress && value != State.Done)
                {
                    throw new ArgumentException("Task State could only be Pending, InProgress or Done!");
                }

                this.state = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + this.Name);
            builder.Append("    State: " + this.State);

            return builder.ToString();
        }
    }
}
