using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;


namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [DataTestMethod]
        [DataRow(2.65, "Change: 10 quarter(s), 1 dime(s), and 1 nickel(s).")]
        [DataRow(0.85, "Change: 3 quarter(s), 1 dime(s), and 0 nickel(s).")]
        [DataRow(1.45, "Change: 5 quarter(s), 2 dime(s), and 0 nickel(s).")]
        [DataRow(2.00, "Change: 8 quarter(s), 0 dime(s), and 0 nickel(s).")]
        public void ChangeTestsAutotest(double inputAmt, string expectedOutput)
        {
            Change changeAmt = new Change();

            string actualOutput = changeAmt.GetChange((decimal)inputAmt);

            Assert.AreEqual(expectedOutput, actualOutput, "Change does not match.");
        }
    }
}
