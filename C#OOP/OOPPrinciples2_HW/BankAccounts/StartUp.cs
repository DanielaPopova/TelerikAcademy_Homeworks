namespace BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BankAccounts.Interfaces;
    using BankAccounts.Models;

    public class StartUp
    {
        public static void Main()
        {
            var bank = new Bank("UniReddit");

            bank.AddAccount(new DepositAccount(new Individual("Peter Dashev"), 1500, 1));
            bank.AddAccount(new LoanAccount(new Company("Mims IT"), 5000, 5));
            bank.AddAccount(new MortgageAccount(new Individual("Marta Hristova"), 500, 0.5m));
            bank.AddAccount(new DepositAccount(new Company("LOLS"), 10000, 2.5m));
            bank.AddAccount(new LoanAccount(new Individual("Ivan Geshov"), 2200, 1.5m));

            Console.WriteLine(bank);

            Console.WriteLine("\nInterest for next 12 mounts:");
            foreach (var account in bank.Accounts)
            {
                Console.WriteLine("{0}  -> {1:F3} per month", account.Customer.Name, account.CalculateInterest(12));
            }
        }
    }
}
