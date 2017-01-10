namespace BankAccounts.Models
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            :base(customer, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is Company)  
            {
                if (months <= 2)
                {
                    return 0;
                }

                return this.InterestRate / 100 * (months - 2);
            }
            else if (this.Customer is Individual)
	        {
		        if (months <= 3)
	            {
                    return 0;
	            }

                return this.InterestRate / 100 * (months - 3);
	        }

            return InterestRate / 100 * (months);
        }
    }
}