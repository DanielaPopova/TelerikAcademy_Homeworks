using Bytes2you.Validation;
using ProjectManager.Commands;
using System;
using System.Linq;

namespace ProjectManager.Common
{
    public class CommandProcessor
    {
        private readonly CommandsFactory factory;

        public CommandProcessor(CommandsFactory factory)
        {
            this.factory = factory;
        }

        public string ProcessCommand(string fullCommand)
        {
            if (string.IsNullOrWhiteSpace(fullCommand))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var commandName = fullCommand.Split(' ')[0];
            var commandParameters = fullCommand.Split(' ').Skip(1).ToList();

            var command = this.factory.CreateCommandFromString(commandName);            

            return command.Execute(commandParameters);
        }
    }
}
