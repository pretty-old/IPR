namespace BankSystem.Contracts
{
    public class PromotionalAgreement : IAccountAgreement
    {
        private readonly double _rate;

        public PromotionalAgreement(double rate)
        {
            _rate = rate - 10;
        }

        public double ComputeInterest(double balance)
        {
            return balance * _rate / 100;
        }
    }
}