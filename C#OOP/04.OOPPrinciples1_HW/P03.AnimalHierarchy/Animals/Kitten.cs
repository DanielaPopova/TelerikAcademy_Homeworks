namespace AnimalHierarchy.Animals
{
    using System;
    using AnimalHierarchy.Enumerations;

    public class Kitten : Cat
    {
        public Kitten(string name, double age) : base(name, age, Gender.Female)
        {
        }

        public override void makeSomeSound()
        {
            Console.WriteLine("Meooow (female like)!");
        }
    }
}
