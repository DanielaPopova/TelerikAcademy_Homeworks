namespace ProjectManager.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateProjectCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory factory;

        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
        {            
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory").IsNull().Throw();

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
                
            if (this.database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var projectName = parameters[0];
            var startingDate = parameters[1]; 
            var endingDate = parameters[2];
            var state = parameters[3];

            var project = this.factory.CreateProject(projectName, startingDate, endingDate, state);
            this.database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}