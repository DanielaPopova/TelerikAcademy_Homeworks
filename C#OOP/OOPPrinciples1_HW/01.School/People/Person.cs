namespace Schools.People
{
    using System;
    using Schools.Interfaces;

    public class Person : IComment
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
                    throw new ArgumentNullException("Enter a name!");
                }

                if (value.Length < 6)
                {
                    throw new ArgumentException("Too short entry for both first and last name!");
                }

                this.name = value;
            }
        }

        public virtual void Comment()
        {
            Console.WriteLine("I'm in school");
        }
    }
}
