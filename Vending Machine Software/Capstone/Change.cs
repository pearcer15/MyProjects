// <copyright file="Change.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class to calculate change
    /// </summary>
    public class Change
    {
        private int quarters = 0;
        private int dimes = 0;
        private int nickels = 0;

        /// <summary>
        /// Change calculator
        /// </summary>
        /// <param name="changeAmt">Amount of money to be changed</param>
        /// <returns>Change in quarters, dimes, and nickels</returns>
        public string GetChange(decimal changeAmt)
        {
            while (changeAmt >= 0.25M)
            {
                this.quarters++;
                changeAmt -= 0.25M;
            }

            while (changeAmt >= 0.10M)
            {
                this.dimes++;
                changeAmt -= 0.10M;
            }

            while (changeAmt >= 0.05M)
            {
                this.nickels++;
                changeAmt -= 0.05M;
            }

            return $"Change: {this.quarters} quarter(s), {this.dimes} dime(s), and {this.nickels} nickel(s).";
        }
    }
}
