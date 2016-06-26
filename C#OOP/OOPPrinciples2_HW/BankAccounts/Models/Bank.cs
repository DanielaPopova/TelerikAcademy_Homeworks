namespace BankAccounts.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bank
    {
        private List<Account> accounts;

        public Bank(string name)
        {
            this.Name = name;
            this.Accounts = new List<Account>();
        }

        public string Name { get; private set; }

        public List<Account> Accounts { get; private set; }

        public void AddAccount(Account account)
        {
            this.Accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            if (this.Accounts.Count == 0)
            {
                throw new ArgumentException("There are no accounts in the collection!");
            }

            this.Accounts.Remove(account);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(this.Name);

            foreach (var account in this.Accounts)
            {
                info.AppendLine(account.ToString());
            }

            return info.ToString();
        }
    }
}
