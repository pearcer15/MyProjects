// <copyright file="Program.cs">
// Richard Sheaves-Bein & Ryan Pearce
// </copyright>

namespace Capstone
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Stock vm = new Stock();
            Dictionary<string, VMItem> vmStock = vm.BuildStock();
            VendingMachine vM500 = new VendingMachine(vmStock);
            MainMenu mm = new MainMenu();
            mm.Run(vM500);
        }
    }
}
