namespace ProjectManager.Commands
{
    using Common.Exceptions;
    using Contracts;
    using Data;
    using Models.Contracts;

    public class CommandsFactory : ICommandsFactory
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CommandsFactory(IDatabase database, IModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }
       
        public ICommand CreateCommandFromString(string commandName)
        { 
            switch (commandName.ToLower())
            {
                case "createproject":
                    return this.CreateProjectCommand();
                case "createuser":
                    return this.CreateUserCommand();
                case "createtask":
                    return this.CreateTaskCommand();
                case "listprojects":
                    return this.ListProjectsCommand();
                case "listprojectdetails":
                    return this.ListProjectDetailsCommand();
                default:
                    throw new UserValidationException("The passed command is not valid!");
            }
        }

        public ICommand CreateProjectCommand()
        {
            return new CreateProjectCommand(this.database, this.modelsFactory);
        }

        public ICommand CreateUserCommand()
        {
            return new CreateUserCommand(this.database, this.modelsFactory);
        }

        public ICommand CreateTaskCommand()
        {
            return new CreateTaskCommand(this.database, this.modelsFactory);
        }

        public ICommand ListProjectsCommand()
        {
            return new ListProjectsCommand(this.database);
        }

        public ICommand ListProjectDetailsCommand()
        {
            return new ListProjectDetailsCommand(this.database);
        }
    }
}