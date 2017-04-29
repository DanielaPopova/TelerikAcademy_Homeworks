namespace TemplateExample
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var grocery = new Grocery { Product0 = "meat" };
            Console.WriteLine(grocery.Product0);
        }
    }
}
