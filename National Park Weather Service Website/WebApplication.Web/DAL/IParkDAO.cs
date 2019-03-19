using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Gets a list of all parks.
        /// </summary>
        /// <returns></returns>
        IList<Park> GetAllParks();
    }
}
