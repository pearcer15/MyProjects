using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// List of all parks
        /// </summary>
        /// <returns>A list of parks</returns>
        IList<Park> GetAllParks();
    }
}
