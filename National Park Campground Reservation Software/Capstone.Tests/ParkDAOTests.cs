using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkDAOTests : CapstoneTests
    {
        [TestMethod]
        public void GetAllParks_ShouldReturn_2_Parks()
        {
            ParksSqlDAO dao = new ParksSqlDAO(ConnectionString);
            IList<Park> parks = dao.GetAllParks();
            Assert.AreEqual(2, parks.Count);
        }
    }
}
