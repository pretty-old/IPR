using System;
using System.Collections.Generic;
using System.Linq;
using BankSystem.Models;
using BankSystem.Contracts;

namespace BankSystem
{
    public static class ClientManager
    {
        public static void RegisterClient(List<Client> clients)
        {
            Console.Write("Enter client name: ");
            var name = Console.ReadLine();
            Console.Write("Enter client passport ID: ");
            var passport = Console.ReadLine();

            clients.Add(new Client(name, passport));
            Console.WriteLine("Client successfully added.");
        }

        public static void RegisterAccount(List<Client> clients, List<DepositOption> depositOptions)
        {
            Console.Write("Enter client name or passport ID: ");
            var clientIdentifier = Console.ReadLine();
            var client = clients.FirstOrDefault(c => c.FullName == clientIdentifier || c.PassportId == clientIdentifier);

            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            Console.WriteLine("Available deposit options:");
            for (int i = 0; i < depositOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {depositOptions[i].Title} - {depositOptions[i].Rate}%");
            }

            Console.Write("Choose deposit option: ");
            if (!int.TryParse(Console.ReadLine(), out var optionIndex) || optionIndex < 1 || optionIndex > depositOptions.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            var selectedOption = depositOptions[optionIndex - 1];

            Console.Write("Choose agreement type (1 - Standard, 2 - Promotional): ");
            var agreementType = Console.ReadLine();
            IAccountAgreement agreement = agreementType switch
            {
                "1" => new StandardAgreement(selectedOption.Rate),
                "2" => new PromotionalAgreement(selectedOption.Rate),
                _ => null
            };

            if (agreement == null)
            {
                Console.WriteLine("Invalid agreement type.");
                return;
            }

            Console.Write("Enter initial deposit amount: ");
            if (!double.TryParse(Console.ReadLine(), out var initialAmount) || initialAmount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            client.Accounts.Add(new Account(selectedOption, agreement, initialAmount));
            Console.WriteLine("Account added successfully.");
        }

        public static void ReplenishAccount(List<Client> clients)
        {
            Console.Write("Enter client name or passport ID: ");
            var clientIdentifier = Console.ReadLine();
            var client = clients.FirstOrDefault(c => c.FullName == clientIdentifier || c.PassportId == clientIdentifier);

            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            Console.WriteLine("Client accounts:");
            for (int i = 0; i < client.Accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {client.Accounts[i].DepositDetails.Title}, balance: {client.Accounts[i].Balance}");
            }

            Console.Write("Select account to replenish: ");
            if (!int.TryParse(Console.ReadLine(), out var accountIndex) || accountIndex < 1 || accountIndex > client.Accounts.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            var selectedAccount = client.Accounts[accountIndex - 1];

            Console.Write("Enter amount to replenish: ");
            if (!double.TryParse(Console.ReadLine(), out var amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            selectedAccount.Balance += amount;
            Console.WriteLine("Account successfully replenished.");
        }

        public static void CalculateClientInterest(List<Client> clients)
        {
            Console.Write("Enter client name or passport ID: ");
            var clientIdentifier = Console.ReadLine();
            var client = clients.FirstOrDefault(c => c.FullName == clientIdentifier || c.PassportId == clientIdentifier);

            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            var totalInterest = client.Accounts.Sum(a => a.Agreement.ComputeInterest(a.Balance));
            Console.WriteLine($"Total interest for client: {totalInterest:F2}");
        }
    }
}
