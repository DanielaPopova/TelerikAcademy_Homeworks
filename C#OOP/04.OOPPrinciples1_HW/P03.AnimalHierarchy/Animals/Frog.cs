namespace AnimalHierarchy.Animals
{
    using System;
    using AnimalHierarchy.Enumerations;

    public class Frog : Animal
    {
        public Frog(string name, double age, Gender gender) : base(name, age, gender)
        {
        }

        public override void makeSomeSound()
        {
            Console.WriteLine("Qua qua!");
        }
    }
}
