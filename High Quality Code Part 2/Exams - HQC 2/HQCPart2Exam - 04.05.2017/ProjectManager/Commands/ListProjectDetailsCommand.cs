namespace ProjectManager.Commands
{
    using Bytes2you.Validation;
    using Common.Exceptions;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListProjectDetailsCommand : ICommand
    {
        private readonly IDatabase database;

        public ListProjectDetailsCommand(IDatabase database)
        {            
            Guard.WhenArgument(database, "ListProjectDetails Database").IsNull().Throw();
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projectId = int.Parse(parameters[0]);
            var project = this.database.Projects[projectId];

            return project.ToString();
        }
    }
}
