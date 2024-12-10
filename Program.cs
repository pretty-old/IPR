using System;
using System.Collections.Generic;
using BankSystem.Models;

namespace BankSystem
{
    internal class Program
    {
        private static void Main()
        {
            var depositOptions = new List<DepositOption>
            {
                new DepositOption("Savings", 5),
                new DepositOption("Investment", 7)
            };

            var clients = new List<Client>();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a client");
                Console.WriteLine("2. Add an account to a client");
                Console.WriteLine("3. Replenish client account");
                Console.WriteLine("4. Calculate total interest for a client");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ClientManager.RegisterClient(clients);
                        break;
                    case "2":
                        ClientManager.RegisterAccount(clients, depositOptions);
                        break;
                    case "3":
                        ClientManager.ReplenishAccount(clients);
                        break;
                    case "4":
                        ClientManager.CalculateClientInterest(clients);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}