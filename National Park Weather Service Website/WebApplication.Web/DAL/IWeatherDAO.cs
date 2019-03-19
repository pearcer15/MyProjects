using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IWeatherDAO
    {
        /// <summary>
        /// Gets the park forecast.
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        IList<Weather> GetParkForecast(string parkCode);
    }
}
