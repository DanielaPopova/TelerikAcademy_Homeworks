namespace BankAccounts.Models
{
    using System;

    public class Company : Customer
    {
        private string managerName;

        public Company(string name)
            :base(name)
        {

        }

        public Company(string name, string accountNumber, string companyManager)
            :base(name, accountNumber)
        {

        }

        public string CompanyManager
        {
            get
            {
                return this.managerName;
            }

            private set
            {
                if (value.Length < 7)
                {
                    throw new ArgumentException("Enter both first and last name of the company manager");
                }

                this.managerName = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " [legal entity]";
        }
    }
}
