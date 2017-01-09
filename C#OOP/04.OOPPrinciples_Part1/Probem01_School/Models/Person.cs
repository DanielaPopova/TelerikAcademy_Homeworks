namespace SchoolSystem.Models
{
    using System;

    using SchoolSystem.Contracts;

    public abstract class Person : IComment
    {
        private string name;

        public Person(string name)
        {
            this.Name = name;
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
                    throw new ArgumentException("Enter a name!");
                }

                if (value.Length < 6)
                {
                    throw new ArgumentException("Enter both first and last name!");
                }

                this.name = value;
            }
        }

        public virtual string Comment()
        {
            return "Enter comments here.";
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
