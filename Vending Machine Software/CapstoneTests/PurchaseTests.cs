using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class PurchaseTests
    {
        [DataTestMethod]
        [DataRow(1.00, "A1", null, "Insufficient Funds")]
        [DataRow(1.00, "S1", null, "Invalid Entry")]
        public void PurchaseTests_DoGenericTests(double deposit, string selection, VMItem expectedItem, string expectedMessage)
        {
            Stock vm = new Stock();
            Dictionary<string, VMItem> vmStock = vm.BuildStock();
            VendingMachine vM500 = new VendingMachine(vmStock);
            VMItem actualItem = null;
            string actualMessage = string.Empty;
            var result = (item: actualItem, message: actualMessage);

            vM500.AddMoney((decimal)deposit);
            result = vM500.Purchase(selection);

            Assert.AreEqual(expectedItem, result.item);
            Assert.AreEqual(expectedMessage, result.message);
        }

        [TestMethod]
        public void PurchaseTests_OutOfStockItem()
        {
            Stock vm = new Stock();
            Dictionary<string, VMItem> vmStock = vm.BuildStock();
            VendingMachine vM500 = new VendingMachine(vmStock);
            VMItem actualItem = null;
            string actualMessage = string.Empty;
            var result = (item: actualItem, message: actualMessage);

            vM500.AddMoney(5.00M);
            vM500.Purchase("D4");
            vM500.Purchase("D4");
            vM500.Purchase("D4");
            vM500.Purchase("D4");
            vM500.Purchase("D4");
            result = vM500.Purchase("D4");

            Assert.AreEqual(null, result.item);
            Assert.AreEqual("Item Sold Out", result.message);
        }

        [TestMethod]
        public void PurchaseTests_PurchaseValidItem()
        {
            Stock vm = new Stock();
            Dictionary<string, VMItem> vmStock = vm.BuildStock();
            VendingMachine vM500 = new VendingMachine(vmStock);
            VMItem actualItem = null;
            string actualMessage = string.Empty;
            var result = (item: actualItem, message: actualMessage);

            vM500.AddMoney(5.00M);
            result = vM500.Purchase("D4");

            Assert.AreEqual("Triplemint", result.item.ProductName);
            Assert.AreEqual("Enjoy your", result.message);
        }
    }
}
