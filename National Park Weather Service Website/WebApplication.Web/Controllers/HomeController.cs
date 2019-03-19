using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
        }

        /// <summary>
        /// The home page of the National Park Geek system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetAllParks();

            return View(parks);
        }

        /// <summary>
        /// A detail view for one park
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            Park park = parkDAO.GetAllParks().First(p => p.ParkCode == parkCode);
            park.Forecast = weatherDAO.GetParkForecast(parkCode);

            return View(park);
        }

        /// <summary>
        /// An overload to save temperature preference to session
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="tempPref"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Detail(string parkCode, string tempPref)
        {
            HttpContext.Session.SetString("TempPreference", tempPref);

            return RedirectToAction("Detail" ,"Home", new { parkCode = parkCode });
        }

        /// <summary>
        /// We've been told this does something, we don't use it though. If we leave the development environment it'll be important.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
