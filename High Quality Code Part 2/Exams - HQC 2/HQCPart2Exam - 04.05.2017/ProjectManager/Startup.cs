namespace ProjectManager
{
    using Commands;
    using Common;
    using Common.Providers;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main()
        {  
            var validator = new Validator();
            var database = new Database();
            var modelFactory = new ModelsFactory(validator);

            var commandFactory = new CommandsFactory(database, modelFactory); 

            var processor = new CommandProcessor(commandFactory);
            var logger = new FileLogger();
            var reader = new Reader();
            var writer = new Writer();
            var engine = new Engine(logger, reader, writer, processor);

            engine.Start();
        }
    }
}
