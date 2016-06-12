namespace Generic
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
            listColors[2] = "blue";
            listColors[3] = "pink";
            listColors.AddElement("black");
            Console.WriteLine(listColors);

            Console.WriteLine("Max: {0}", listColors.Max());

            listColors.RemoveElement(2);
            Console.WriteLine(listColors);
            Console.WriteLine("Count = {0}", listColors.Count);
           
            listColors.ClearElements();
            Console.WriteLine(listColors);

            var listYears = new GenericList<int>(5);
            listYears.AddElement(2);
            listYears.AddElement(3);
            listYears[2] = 4;
            listYears.AddElement(6);
            listYears.AddElement(9);
            Console.WriteLine(listYears);

            Console.WriteLine("Max: {0}", listYears.Max());
            Console.WriteLine("Min: {0}", listYears.Min());            
        }
    }
}