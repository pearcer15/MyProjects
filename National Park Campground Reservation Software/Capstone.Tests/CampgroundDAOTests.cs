using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundDAOTests : CapstoneTests
    {
        [TestMethod]
        public void GetAllParksTest()
        {
            GetAllCampgrounds_ByPark_ShouldReturn_Right_Count(park1, 2);
            GetAllCampgrounds_ByPark_ShouldReturn_Right_Count(park2, 1);
        }

        public void GetAllCampgrounds_ByPark_ShouldReturn_Right_Count(int parkID, int expected)
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(ConnectionString);
            IList<Campground> campgrounds = dao.GetAllCampgroundsByPark(parkID);
            Assert.AreEqual(expected, campgrounds.Count);
        }
    }
}
