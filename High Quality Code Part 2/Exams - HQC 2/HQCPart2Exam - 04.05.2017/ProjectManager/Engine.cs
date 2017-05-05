using Bytes2you.Validation;
using ProjectManager.Commands;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Models;
using System;
using System.Text;

namespace ProjectManager
{
    public class Engine
    {
        private readonly FileLogger logger;
        private readonly CommandProcessor processor;

        public Engine(FileLogger logger, CommandProcessor processor)
        {
            // validate clauses
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;
            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {
                // read from console
                var commandReader = Console.ReadLine();

                if (commandReader.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandReader);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
