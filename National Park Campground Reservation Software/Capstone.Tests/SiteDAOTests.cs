using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class SiteDAOTests : CapstoneTests
    {
        [TestMethod]
        public void GetAvailableSitesTest()
        {
            GetAvailableSitesTest_ShouldReturn_Right_Count(park1, campground1, new DateTime(2019, 02, 15), new DateTime(2019, 02, 25), 1);
            GetAvailableSitesTest_ShouldReturn_Right_Count(park1, campground1, new DateTime(2019, 01, 15), new DateTime(2019, 01, 25), 2);
            GetAvailableSitesTest_ShouldReturn_Right_Count(park1, campground2, new DateTime(2019, 02, 15), new DateTime(2019, 02, 25), 1);
            GetAvailableSitesTest_ShouldReturn_Right_Count(park1, campground2, new DateTime(2019, 04, 15), new DateTime(2019, 04, 25), 2); 
            GetAvailableSitesTest_ShouldReturn_Right_Count(park1, 0, new DateTime(2019, 02, 15), new DateTime(2019, 02, 25), 2);           
        }

        public void GetAvailableSitesTest_ShouldReturn_Right_Count(int parkID,int campgroundID, DateTime start, DateTime end, int expected)
        {
            SitesSqlDAO dao = new SitesSqlDAO(ConnectionString);
            IList<Site> sites = dao.GetAvailableSites(parkID, campgroundID, start, end);
            Assert.AreEqual(expected, sites.Count);
        }
    }
}
