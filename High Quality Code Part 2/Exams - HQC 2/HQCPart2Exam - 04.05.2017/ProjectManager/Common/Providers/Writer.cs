namespace ProjectManager.Common.Providers
{
    using Contracts;
    using System;

    public class Writer : IWriter
    {
        public void Write(object value)
        {
            Console.Write(value);
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value);
        }
    }
}
