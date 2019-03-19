// <copyright file="MainMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Main menu of a vending machine
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// The vending machine
        /// </summary>
        private VendingMachine vM500;

        /// <summary>
        /// RUns the menu
        /// </summary>
        /// <param name="machine">machine menu is running on</param>
        public virtual void Run(VendingMachine machine)
        {
            this.vM500 = machine;

            while (true)
            {
                string choice = string.Empty;
                while (choice != "1" && choice != "2" && choice != "Q")
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the Vendo-Matic 500!");
                    Console.WriteLine();
                    Console.WriteLine("1. Display Vending Machine Items");
                    Console.WriteLine("2. Purchase");
                    Console.WriteLine("Q. Quit");
                    Console.Write("Please make a selection: ");
                    choice = Console.ReadLine().ToUpper();
                }

                switch (choice)
                {
                    case "1":
                        this.DisplayInventory(this.vM500);
                        Console.ReadLine();
                        break;

                    case "2":
                        PurchaseMenu pm = new PurchaseMenu();
                        pm.Run(this.vM500);
                        break;

                    case "Q":
                        this.SalesReport();
                        return;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the inventory of the machine
        /// </summary>
        /// <param name="machine">current vending machine</param>
        protected void DisplayInventory(VendingMachine machine)
        {
            VMItem[] contents = machine.GetContents();
            foreach (VMItem item in contents)
            {
                string quantity = string.Empty;
                if (item.Quantity == 0)
                {
                    quantity = "SOLD OUT";
                }
                else
                {
                    quantity = item.Quantity.ToString();
                }

                Console.WriteLine($"{item.SlotLocation} {item.ProductName, -20} {item.Price:C2} - {quantity}");
            }
        }

        /// <summary>
        /// Print out the total sales history when exitting
        /// </summary>
        private void SalesReport()
        {
            Dictionary<string, int> salesHistory = this.vM500.SalesTotalGet();
            try
            {
                using (StreamWriter sw = new StreamWriter("SalesReport.txt"))
                {
                    foreach (KeyValuePair<string, int> item in salesHistory)
                    {
                        sw.WriteLine(item.Key + "|" + item.Value);
                    }

                    sw.WriteLine();
                    sw.WriteLine($"**TOTAL SALES** {this.vM500.TotalSales:C2}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
