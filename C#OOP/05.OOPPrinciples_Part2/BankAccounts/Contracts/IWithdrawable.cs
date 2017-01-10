namespace BankAccounts.Contracts
{
    public interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}
