namespace BankAccounts.Models
{
    using System;

    public class Individual : Customer
    {
        private string identificationNumber;

        public Individual(string name)
            :base(name)
        {

        }

        public Individual(string name, string accountNumber, string identificationNumber)
            : base(name, accountNumber)
        {
            this.IDNumber = identificationNumber;
        }

        public string IDNumber
        {
            get
            {
                return this.identificationNumber;
            }

            private set
            {
                if (value.Length != 10 )
                {
                    throw new ArgumentException("Identification number consists of exactly 10 digits!");
                }

                this.identificationNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " [individual]";
        }
    }
}
