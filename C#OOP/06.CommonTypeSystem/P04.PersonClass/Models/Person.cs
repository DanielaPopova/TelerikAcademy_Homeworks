namespace PersonClass.Models
{
    using System;

    public class Person
    {
        private const int MinAge = 0;
        private const int MaxAge = 110;

        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException(string.Format("Invalid age range [{0} - {1}]", MinAge, MaxAge));
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            string name = string.Format("Name: {0} ", this.Name);
            string age = string.Format("Age: {0}", this.Age == null ? "no info" : this.Age.ToString());

            return name + age; 
        }
    }
}
