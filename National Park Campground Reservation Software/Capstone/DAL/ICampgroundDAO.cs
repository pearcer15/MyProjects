using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ICampgroundDAO
    {
        /// <summary>
        /// Gets a list of campgrounds in a park
        /// </summary>
        /// <returns>List of campgrounds</returns>
        IList<Campground> GetAllCampgroundsByPark(int parkID);
    }
}
