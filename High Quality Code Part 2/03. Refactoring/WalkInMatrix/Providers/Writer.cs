namespace WalkInMatrix.Providers
{
    using System;

    using WalkInMatrix.Contracts;

    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
