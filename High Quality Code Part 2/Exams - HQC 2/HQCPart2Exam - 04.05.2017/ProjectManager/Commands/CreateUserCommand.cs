namespace ProjectManager.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;   
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateUserCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory factory;

        public CreateUserCommand(IDatabase database, IModelsFactory factory)
        {            
            Guard.WhenArgument(database, "CreateUserCommand Database").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateUserCommand ModelsFactory").IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        { 
            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectId = int.Parse(parameters[0]);
            var username = parameters[1];
            var email = parameters[2];            
            var usersList = this.database.Projects[projectId].Users;

            if (usersList.Any() && usersList.Any(x => x.Username == username))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.factory.CreateUser(username, email);
            usersList.Add(user);

            return "Successfully created a new user!";
        }
    }
}