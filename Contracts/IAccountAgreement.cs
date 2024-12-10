namespace BankSystem.Contracts
{
    public interface IAccountAgreement
    {
        double ComputeInterest(double balance);
    }
}