namespace SchoolSystem
{
    using Core;
    using Core.Providers;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();
            var parser = new CommandParserProvider();

            var engine = new Engine(reader, writer, parser);
            engine.Execute();
        }
    }
}
