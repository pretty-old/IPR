namespace BankSystem.Contracts
{
    public class StandardAgreement : IAccountAgreement
    {
        private readonly double _rate;

        public StandardAgreement(double rate)
        {
            _rate = rate;
        }

        public double ComputeInterest(double balance)
        {
            return balance * _rate / 100;
        }
    }
}