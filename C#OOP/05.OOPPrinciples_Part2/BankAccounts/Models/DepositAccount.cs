namespace BankAccounts.Models
{
    using System;
    using Contracts;

    public class DepositAccount : Account, IWithdrawable
    {

        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            :base(customer, balance, interestRate)
        {

        }

        public void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("There is no such amount of money in your account!" + "\nBalance: " + this.Balance);
            }

            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance >= 0 && this.Balance <= 1000)
            {
                return 0;
            }

            return this.InterestRate / 100 * months;
        }
    }
}
