namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class Engine
    {
        protected readonly IReader reader;
        protected readonly IWriter writer;
        protected readonly IParser parser;

        public Engine(IReader reader, IWriter writer, IParser parser)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Reader cannot be null!");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null!");
            }

            if (parser == null)
            {
                throw new ArgumentNullException("Parser cannot be null!");
            }

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;

            Teachers = new Dictionary<int, ITeacher>();
            Students = new Dictionary<int, IStudent>();
        }

        public static Dictionary<int, ITeacher> Teachers { get; set; }

        public static Dictionary<int, IStudent> Students { get; set; }

        public void Execute()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == "End")
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty!");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var resultMessage = command.Execute(parameters);
            this.writer.WriteLine(resultMessage);
        }
    }
}
