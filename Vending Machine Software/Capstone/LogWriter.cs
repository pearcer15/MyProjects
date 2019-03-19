// <copyright file="LogWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// A class to log transactions
    /// </summary>
    public class LogWriter
    {
        /// <summary>
        /// The transaction logger
        /// </summary>
        /// <param name="transaction">log message</param>
        /// <param name="startingBalance">starting balance</param>
        /// <param name="currentBalance">ending balance</param>
        public void Logger(string transaction, decimal startingBalance, decimal currentBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now} {transaction, -25} {startingBalance, -6:C2} {currentBalance, -8:C2}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
