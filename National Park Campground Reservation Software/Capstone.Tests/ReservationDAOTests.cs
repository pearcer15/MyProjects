using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationDAOTests : CapstoneTests
    {
        [TestMethod]
        public void MakeReservation_Should_Return1MoreReservation()
        {
            ReservationsSqlDAO dao = new ReservationsSqlDAO(ConnectionString);
            int startingRows = GetRowCount("reservation");
            Reservation res = new Reservation();
            res.SiteID = siteID;
            res.Name = "Huntr BitBucket";
            res.StartDate = DateTime.Now;
            res.EndDate = DateTime.Now;

            dao.MakeReservation(res);
            int endingRows = GetRowCount("reservation");

            Assert.AreEqual(startingRows + 1, endingRows);
        }

    }
}
