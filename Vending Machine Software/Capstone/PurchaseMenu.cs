// <copyright file="PurchaseMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The purchase submenu of the vending machine
    /// </summary>
    public class PurchaseMenu : MainMenu
    {
        /// <summary>
        /// List of purchases in the current transaction
        /// </summary>
        private List<VMItem> currentPurchases = new List<VMItem>();

        /// <summary>
        /// The vending machine
        /// </summary>
        private VendingMachine vM500;

        /// <summary>
        /// Runs the purchase menu
        /// </summary>
        /// <param name="machine">The vending machine it runs on</param>
        public override void Run(VendingMachine machine)
        {
            this.vM500 = machine;

            while (true)
            {
                int choice = 0;
                while (choice != 1 && choice != 2 && choice != 3)
                {
                    Console.Clear();
                    Console.WriteLine("1. Feed Money");
                    Console.WriteLine("2. Select Product");
                    Console.WriteLine("3. Finish Transaction");
                    Console.WriteLine($"Current Transaction Balance: {this.vM500.GetBalance():C2}");
                    Console.WriteLine();
                    Console.Write("Please make selection: ");
                    int.TryParse(Console.ReadLine(), out choice);
                }

                switch (choice)
                {
                    case 1:
                        this.AddMoney();
                        break;

                    case 2:
                       this.SelectProduct();
                        break;

                    case 3:
                        this.CompleteTransaction();
                        return;
                }
            }
        }

        /// <summary>
        /// Finishes a vending transaction
        /// </summary>
        private void CompleteTransaction()
        {
            Change change = new Change();
            Console.WriteLine(change.GetChange(this.vM500.GetBalance()));
            this.vM500.ClearBalance();
            foreach (VMItem sale in this.currentPurchases)
            {
                switch (sale.Type)
                {
                    case "Chip":
                        Console.WriteLine("Crunch, Crunch, Yum!");
                        break;

                    case "Candy":
                        Console.WriteLine("Munch, Munch, Yum!");
                        break;

                    case "Drink":
                        Console.WriteLine("Glug, Glug, Yum!");
                        break;

                    case "Gum":
                        Console.WriteLine("Chew, Chew, Yum!");
                        break;
                }
            }

            Console.WriteLine();
            Console.ReadLine();
            this.currentPurchases.Clear();
            return;
        }

        /// <summary>
        /// Selects a product to buy
        /// </summary>
        private void SelectProduct()
        {
            this.DisplayInventory(this.vM500);
            Console.Write("Please select a product: ");
            string choice = Console.ReadLine().ToUpper();
            VMItem purchase = null;
            string message = string.Empty;
            var result = (item: purchase, message: message);
            result = this.vM500.Purchase(choice);
            if (result.item == null)
            {
                Console.WriteLine($"{result.message}");
            }
            else
            {
                Console.WriteLine($"{result.message} {result.item.ProductName}");
                this.currentPurchases.Add(result.item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Feeds money into the machine
        /// </summary>
        private void AddMoney()
        {
            decimal amt = 0;
            while (amt != 1 && amt != 2 && amt != 5 && amt != 10)
            {
                Console.Write("Enter amount of money to add ($1, $2, $5, $10): ");
                decimal.TryParse(Console.ReadLine(), out amt);
            }

            this.vM500.AddMoney(amt);
        }
    }
}
