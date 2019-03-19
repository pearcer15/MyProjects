using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        /// <summary>
        /// List of available campsites.
        /// </summary>
        /// <param name="park_id">Id of the park.</param>
        /// <param name="campground_id">Id of the campground.</param>
        /// <param name="startingDate">Starting date of reservation.</param>
        /// <param name="endingDate">Ending date of reservation</param>
        /// <returns>Returns list of available sites.</returns>
        IList<Site> GetAvailableSites(int park_id, int campground_id, DateTime startingDate, DateTime endingDate);
    }
}
