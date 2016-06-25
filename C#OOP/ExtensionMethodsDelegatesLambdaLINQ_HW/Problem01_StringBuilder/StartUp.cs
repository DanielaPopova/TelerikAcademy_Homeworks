namespace Problem1_StringBuilder
{
    using System;    
    using System.Text;
    using Problem1_StringBuilder.Extensions;

    public class StartUp
    {
        public static void Main()
        {
            var someText = new StringBuilder("How are you?");

            StringBuilder wordAre = someText.Substring(4, 3);
            Console.WriteLine(wordAre);
        }
    }
}
