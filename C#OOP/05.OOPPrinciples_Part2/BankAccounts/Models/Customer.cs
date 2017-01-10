namespace BankAccounts.Models
{
    using System;

    public abstract class Customer
    {
        private string accountNumber;

        public Customer(string name)
        {
            this.Name = name;
        }

        public Customer(string name, string accountNumber)
            : this(name)
        {            
            this.AccontNumber = accountNumber;
        }

        public string Name { get; private set; }

        public string AccontNumber
        {
            get
            {
                return this.accountNumber;
            }

            private set
            {
                if (value.Length != 16)
                {
                    throw new ArgumentException("Account number must be exactly 16 digits!");
                }

                this.accountNumber = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
