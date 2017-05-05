namespace ProjectManager.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;    
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateTaskCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory factory;

        public CreateTaskCommand(IDatabase database, IModelsFactory factory)
        {
            // guard clause
            Guard.WhenArgument(database, "CreateTaskCommand Database").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateTaskCommand ModelsFactory").IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            } 

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectId = int.Parse(parameters[0]);
            var userId = int.Parse(parameters[1]);
            var userName = parameters[2];
            var state = parameters[3];

            var project = this.database.Projects[projectId];
            var owner = project.Users[userId];

            var task = this.factory.CreateTask(userName, owner, state);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}