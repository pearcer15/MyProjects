// <copyright file="VendingMachine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a vending machine
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// Holds the vending machine sales history
        /// </summary>
        private Dictionary<string, int> sales = new Dictionary<string, int>();

        /// <summary>
        /// Holds the vending machine stock
        /// </summary>
        private Dictionary<string, VMItem> stock = new Dictionary<string, VMItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VendingMachine"/> class
        /// </summary>
        /// <param name="stock">vending machine stock</param>
        public VendingMachine(Dictionary<string, VMItem> stock)
        {
            this.stock = stock;
            this.SalesBuild();
        }

        /// <summary>
        /// Gets the current balance in the transaction
        /// </summary>
        public decimal CurrentBalance { get; private set; }

        /// <summary>
        /// Gets total sales of the machine
        /// </summary>
        public decimal TotalSales { get; private set; }

        /// <summary>
        /// Returns contents of the machine in an array
        /// </summary>
        /// <returns>vending machine item</returns>
        public VMItem[] GetContents()
        {
            List<VMItem> contents = new List<VMItem>();
            foreach (KeyValuePair<string, VMItem> slot in stock)
            {
                contents.Add(slot.Value);
            }

            return contents.ToArray();
        }

        /// <summary>
        /// Add money to the current balance
        /// </summary>
        /// <param name="addedMoney">How much money was added</param>
        public void AddMoney(decimal addedMoney)
        {
            decimal startingBalance = this.CurrentBalance;
            this.CurrentBalance += addedMoney;
            LogWriter lw = new LogWriter();
            lw.Logger("FEED MONEY:", startingBalance, this.CurrentBalance);
        }

        /// <summary>
        /// Return current balance for display on purchase menu
        /// </summary>
        /// <returns>current balance</returns>
        public decimal GetBalance()
        {
            return this.CurrentBalance;
        }

        /// <summary>
        /// Return a copy of the sales history dictionary to the history report
        /// </summary>
        /// <returns>sales dictionary</returns>
        public Dictionary<string, int> SalesTotalGet()
        {
            return this.sales;
        }


        /// <summary>
        /// Validate and execute purchase of item
        /// </summary>
        /// <param name="choice">user input</param>
        /// <returns>a vending machine item and a message</returns>
        public (VMItem, string) Purchase(string choice)
        {
            VMItem item = null;
            string output = string.Empty;
            if (!this.stock.ContainsKey(choice))
            {
                output = "Invalid Entry";
            }
            else if (this.CurrentBalance < this.stock[choice].Price)
            {
                output = "Insufficient Funds";
            }
            else if (this.stock[choice].Quantity == 0)
            {
                output = "Item Sold Out";
            }
            else
            {
                decimal startingBalance = this.CurrentBalance;
                this.CurrentBalance -= this.stock[choice].Price;
                this.TotalSales += this.stock[choice].Price;
                item = this.stock[choice];
                this.stock[choice].Quantity--;
                this.sales[this.stock[choice].ProductName]++;
                output = "Enjoy your";
                LogWriter lw = new LogWriter();
                lw.Logger($"{this.stock[choice].ProductName} {this.stock[choice].SlotLocation}", startingBalance, this.CurrentBalance);
            }

            return (item, output);
        }

        /// <summary>
        /// Clears balance when finishing a transaction
        /// </summary>
        public void ClearBalance()
        {
            decimal startingBalance = this.CurrentBalance;
            this.CurrentBalance = 0M;
            LogWriter lw = new LogWriter();
            lw.Logger("GIVE CHANGE:", startingBalance, this.CurrentBalance);
        }

        /// <summary>
        /// Build the dictionary of product names for sales history tracking
        /// </summary>
        private void SalesBuild()
        {
            foreach (KeyValuePair<string, VMItem> item in this.stock)
            {
                this.sales.Add(item.Value.ProductName, 0);
            }
        }

    }
}