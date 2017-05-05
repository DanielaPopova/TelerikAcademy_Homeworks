namespace SchoolSystem.Models
{
    using System;
    using System.Text.RegularExpressions;

    using Contracts;

    public abstract class Person : IPerson
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 31;

        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.CheckNameLength(value);
                this.CheckInvalidSymbolsInName(value);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.CheckNameLength(value);
                this.CheckInvalidSymbolsInName(value);

                this.lastName = value;
            }
        }

        private void CheckNameLength(string name)
        {
            if (name.Length < MinNameLength || name.Length > MaxNameLength)
            {
                throw new ArgumentException($"{name} length must be between {MinNameLength} and {MaxNameLength} characters!");
            }
        }

        private void CheckInvalidSymbolsInName(string name)
        {
            var regex = new Regex(@"^[a-zA-Z]+$");

            if (!regex.IsMatch(name))
            {
                throw new ArgumentException($"{name} has some invalid non-latin symbols!");
            }
        }
    }
}
