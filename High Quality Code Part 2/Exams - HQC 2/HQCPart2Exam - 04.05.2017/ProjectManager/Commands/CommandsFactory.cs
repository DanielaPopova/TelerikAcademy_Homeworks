using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models.Contracts;
using System;

namespace ProjectManager.Commands
{
    public class CommandsFactory
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CommandsFactory(IDatabase database, IModelsFactory modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        // TODO: Fill other commands, document
        public ICommand CreateCommandFromString(string commandName)
        {
            var cmd = this.BuildCommand(commandName);

            switch (cmd)
            {
                case "createproject":
                    return new CreateProjectCommand(this.database, this.modelsFactory);
                case "createuser":
                    return new CreateUserCommand(this.database, this.modelsFactory);
                case "createtask":
                    return new CreateTaskCommand(this.database, this.modelsFactory);
                case "listprojects":
                    return new ListProjectsCommand(this.database);
                default:
                    throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string parameters)
        {
            var cmd = string.Empty;
           
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd += parameters[i].ToString().ToLower();
            }

            return cmd;
        }
    }
}