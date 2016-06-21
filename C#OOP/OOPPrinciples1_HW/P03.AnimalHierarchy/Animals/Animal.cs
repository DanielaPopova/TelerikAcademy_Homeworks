namespace AnimalHierarchy.Animals
{
    using System;
    using AnimalHierarchy.Enumerations;
    using AnimalHierarchy.Interfaces;

    public abstract class Animal : ISound
    {
        private string name;
        private double age;

        public Animal(string name, double age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter value for name");
                }

                this.name = value;
            }
        }

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

        public Gender Gender { get; private set; }

        public virtual void makeSomeSound()
        {
            Console.WriteLine("Rrrr"); ;
        }
    }
}