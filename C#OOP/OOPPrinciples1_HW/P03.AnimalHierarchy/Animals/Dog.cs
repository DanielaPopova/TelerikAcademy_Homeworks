namespace AnimalHierarchy.Animals
{
    using System;
    using AnimalHierarchy.Enumerations;

    public class Dog : Animal
    {
        public Dog(string name, double age, Gender gender) : base(name, age, gender)
        {
        }

        public override void makeSomeSound()
        {
            Console.WriteLine("Djaff djaff!");
        }
    }
}
