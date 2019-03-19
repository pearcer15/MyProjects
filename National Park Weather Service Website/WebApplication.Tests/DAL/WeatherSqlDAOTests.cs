using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class WeatherSqlDAOTests : CapstoneTest
    {
        [TestMethod]
        public void GetParkForecast_ShouldReturn_1_Weather_Object()
        {
            WeatherSqlDAO dao = new WeatherSqlDAO(ConnectionString);
            IList<Weather> forecast = dao.GetParkForecast(ParkCode);
            Assert.AreEqual(1, forecast.Count);
        }

    }
}
