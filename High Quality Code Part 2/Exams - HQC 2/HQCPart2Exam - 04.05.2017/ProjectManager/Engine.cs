namespace ProjectManager
{
    using Bytes2you.Validation;    
    using Common.Contracts;
    using Common.Exceptions;    
    using System;

    public class Engine : IEngine
    {
        private readonly IFileLogger logger;        
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor processor;

        public Engine(IFileLogger logger, IReader reader, IWriter writer, ICommandProcessor processor)
        {            
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(reader, "Engine Reader provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Engine Writer provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {                
                var commandReader = this.reader.ReadLine();

                if (commandReader.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandReader);
                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
