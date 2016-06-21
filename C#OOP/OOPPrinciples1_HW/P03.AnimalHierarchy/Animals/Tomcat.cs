namespace AnimalHierarchy.Animals
{
    using System;
    using AnimalHierarchy.Enumerations;

    public class Tomcat : Cat
    {
        public Tomcat(string name, double age) : base(name, age, Gender.Male)
        {
        }

        public override void makeSomeSound()
        {
            Console.WriteLine("Meoww (male like)");
        }
    }
}
