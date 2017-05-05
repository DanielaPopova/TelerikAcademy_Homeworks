using ProjectManager.Commands;
using ProjectManager.Common;

using ProjectManager.Common.Providers;

namespace ProjectManager
{
    using ProjectManager.Data;
    using ProjectManager.Models;

    public class Startup
    {
        public static void Main()
        {            
            var logger = new FileLogger();

            var database = new Database();
            var modelFactory = new ModelsFactory();
            var commandFactory = new CommandsFactory(database, modelFactory); 

            var processor = new CommandProcessor(commandFactory);

            var engine = new Engine(logger, processor);

            engine.Start();
        }
    }
}
