using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    /// <summary>
    /// This represents a park
    /// </summary>
    public class Park
    {
        /// <summary>
        /// Gets the park code.
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// Gets the park name.
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets the acreage.
        /// </summary>
        public double Acreage { get; set; }

        /// <summary>
        /// Gets the elevation in feet.
        /// </summary>
        public double ElevationInFeet { get; set; }

        /// <summary>
        /// Gets the combined miles of trails.
        /// </summary>
        public double MilesOfTrail { get; set; }

        /// <summary>
        /// Gets the number of campsites.
        /// </summary>
        public int NumberOfCampsites { get; set; }

        /// <summary>
        /// Gets the climate.
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// Gets the year the park was founded.
        /// </summary>
        public string YearFounded { get; set; }

        /// <summary>
        /// Gets the avergae number of visitors.
        /// </summary>
        public double AnnualNumberOfVisitors { get; set; }

        /// <summary>
        /// Gets a famous quote related to the park.
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// Gets the person to whom the quote is attributed.
        /// </summary>
        public string QuoteSource { get; set; }

        /// <summary>
        /// Gets a description of the park.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the cost to enter the park in dollars.
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Gets the number of animal species found in the park.
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }

        /// <summary>
        /// Gets the weather for the park.
        /// </summary>
        public IList<Weather> Forecast { get; set; }
    }
}
