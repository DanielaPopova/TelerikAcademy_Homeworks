namespace BankAccounts.Models
{
   public class MortgageAccount : Account
    {
       public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            :base(customer, balance, interestRate)
        {
        }

       public override decimal CalculateInterest(int months)
       {
           if (this.Customer is Company)
           {
               if (months <= 12)
               {
                   return (this.InterestRate / 100 * months) / 2;
               }

               return (this.InterestRate / 100 * (months - 12)) + (this.InterestRate / 100 * months) / 2;
           }
           else if (this.Customer is Individual)
           {
               if (months <= 6)
               {
                   return 0;
               }

               return this.InterestRate / 100 * (months - 6);
           }

           return this.InterestRate / 100 * months;
       }
    }
}
