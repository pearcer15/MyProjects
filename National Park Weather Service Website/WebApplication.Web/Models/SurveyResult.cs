using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyResult
    {
        /// <summary>
        /// The code of the park
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The name of the park
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// The votes the park has received
        /// </summary>
        public int Votes { get; set; }
    }
}
