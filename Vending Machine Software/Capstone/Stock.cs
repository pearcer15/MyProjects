// <copyright file="Stock.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Builds the stock of a vending machine
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// A vending machine's stock
        /// </summary>
        /// <returns>Dictionary representing the vending machine's stock</returns>
        public Dictionary<string, VMItem> BuildStock()
        {
            Dictionary<string, VMItem> output = new Dictionary<string, VMItem>();
            try
            {
                using (StreamReader sr = new StreamReader("vendingmachine.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] properties = new string[4];
                        properties = line.Split('|');
                        string slotLocation = properties[0];
                        string productName = properties[1];
                        decimal price = decimal.Parse(properties[2]);
                        string type = properties[3];

                        VMItem item = new VMItem(slotLocation, productName, price, type);
                        output.Add(properties[0], item);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
    }
}
