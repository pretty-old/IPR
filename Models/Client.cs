using System.Collections.Generic;

namespace BankSystem.Models
{
    public class Client
    {
        public string FullName { get; set; }
        public string PassportId { get; set; }
        public List<Account> Accounts { get; set; }

        public Client(string fullName, string passportId)
        {
            FullName = fullName;
            PassportId = passportId;
            Accounts = new List<Account>();
        }
    }
}