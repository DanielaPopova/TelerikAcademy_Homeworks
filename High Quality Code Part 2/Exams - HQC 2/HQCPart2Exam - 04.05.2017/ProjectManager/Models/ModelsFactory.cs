namespace ProjectManager.Models
{
    using System;

    using Bytes2you.Validation;
    using Common.Contracts;
    using Common.Exceptions;
    using Contracts;
    using Enums;
    
    public class ModelsFactory : IModelsFactory
    {
        private readonly IValidator validator;

        public ModelsFactory(IValidator validator)
        {
            Guard.WhenArgument(validator, "ModelsFactory Validator").IsNull().Throw();
            this.validator = validator;
        }       

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var project = new Project(name, starting, end, (ProjectState)Enum.Parse(typeof(ProjectState), state));
            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(string name, IUser owner, string state)
        {            
            var task = new Task(name, owner, (TaskState)Enum.Parse(typeof(TaskState), state));
            this.validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email);
            this.validator.Validate(user);

            return user;
        }       
    }
}