namespace BankSystem.Models
{
    public class DepositOption
    {
        public string Title { get; set; }
        public double Rate { get; set; }

        public DepositOption(string title, double rate)
        {
            Title = title;
            Rate = rate;
        }
    }
}