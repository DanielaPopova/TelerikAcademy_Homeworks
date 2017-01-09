namespace AnimalHierarchy.Models
{
    using System;

    using AnimalHierarchy.Contracts;
    using AnimalHierarchy.Enumerations;

    public abstract class Animal : ISound
    {
        private double age;

        public Animal(string name, double age, GenderType gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; private set; }

        public double Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age is a positive number!");
                }

                this.age = value;
            }
        }

        public GenderType Gender { get; private set; }

        public virtual string MakeSound()
        {
            return "Rrrrr!";
        }
    }
}
