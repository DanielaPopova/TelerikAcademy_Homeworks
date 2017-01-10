namespace BankAccounts.Models
{
    using System;
    using Contracts;

    public abstract class Account : IDepositable
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; private set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be a negative number!");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be a negative number!");
                }

                this.interestRate = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("You cannot deposit 0 or smaller amount of money!");
            }

            this.Balance += amount;
        }

        public abstract decimal CalculateInterest(int months);

        public override string ToString()
        {
            return string.Format("{0} owner: {1} | Balance: {2} BGN | Interest Rate: {3}%", this.GetType().Name, this.Customer, this.Balance, this.InterestRate);
        }
    }
}
