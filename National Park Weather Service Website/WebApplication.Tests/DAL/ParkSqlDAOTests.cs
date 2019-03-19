using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class ParkSqlDAOTests :CapstoneTest
    {
        [TestMethod]
        public void GetAllParks_ShouldReturn_1_Park()
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            IList<Park> parks = dao.GetAllParks();
            Assert.AreEqual(1, parks.Count);
        }

    }
}
