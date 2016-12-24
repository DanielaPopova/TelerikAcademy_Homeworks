namespace Generics
{
    using System;
    using AttributeTask;

    [Version(1, 2)]
    public class StartUp
    {
        public static void Main()
        {
            var listColors = new GenericList<string>(5);
            listColors.AddElement("red");
            listColors.AddElement("green");            
            listColors.AddElement("black");
            listColors.AddElement("pink");
            Console.WriteLine(listColors);
            Console.WriteLine("Index of \"green\" is {0}", listColors.IndexOf("green"));

            Console.WriteLine("Max: {0}", listColors.Max());

            listColors.RemoveElementAt(1);
            Console.WriteLine(listColors);
            Console.WriteLine("Count = {0}", listColors.Count);

            listColors.Clear();
            Console.WriteLine(listColors);

            var listYears = new GenericList<int>(4);
            listYears.AddElement(2);
            listYears.AddElement(3);
            listYears.AddElement(6);
            listYears.AddElement(9);
            Console.WriteLine(listYears);

            listYears.InsertElementAt(100, 3);
            Console.WriteLine(listYears);

            Console.WriteLine("Max: {0}", listYears.Max());
            Console.WriteLine("Min: {0}", listYears.Min());
        }
    }
}
