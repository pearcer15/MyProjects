using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// Represents weather.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Gets the park code.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets the forecast day.
        /// </summary>
        public int ForecastDay { get; set; }

        /// <summary>
        /// Gets the expected low temperature.
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// Gets the expected high temperature.
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Gets the expected weather.
        /// </summary>
        public string Forecast { get; set; }

        /// <summary>
        /// Gets the temp warning
        /// </summary>
        public string TempWarning
        {
            get
            {
                string warning = "";

                if(High > 75)
                {
                    warning += "Bring an extra gallon of water.";
                }
                
                if(Low < 20)
                {
                    warning += "WARNING: Dangers of exposure to frigid temperatures.";
                }

                if(High - Low > 20)
                {
                    warning += "Wear breathable layers";
                }

                return warning;
            }
        }

        public string WeatherWarning
        {
            get
            {
                if(Forecast == "snow")
                {
                    return "Pack snowshoes!";
                }

                if(Forecast == "rain")
                {
                    return "Pack rain gear and wear waterproof shoes.";
                }

                if(Forecast == "thunderstorms")
                {
                    return "Seek shelter and avoid hiking on exposed ridges.";
                }

                if(Forecast == "sun")
                {
                    return "Pack sunblock! It's gonna be a hot one!";
                }

                else
                {
                    return "";
                }

            }
        }
    }
}
