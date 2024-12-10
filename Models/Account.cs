using BankSystem.Contracts;

namespace BankSystem.Models
{
    public class Account
    {
        public DepositOption DepositDetails { get; set; }
        public IAccountAgreement Agreement { get; set; }
        public double Balance { get; set; }

        public Account(DepositOption depositDetails, IAccountAgreement agreement, double initialBalance)
        {
            DepositDetails = depositDetails;
            Agreement = agreement;
            Balance = initialBalance;
        }
    }
}