using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Models a campground in a park
    /// </summary>
    public class Campground
    {
        /// <summary>
        /// ID number of the campground
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Campground's Park ID
        /// </summary>
        public int ParkID { get; set; }

        /// <summary>
        /// Name of the campground
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Month the campground opens
        /// </summary>
        public int OpeningMonth { get; set; }

        /// <summary>
        /// Month the campground closes
        /// </summary>
        public int ClosingMonth { get; set; }

        /// <summary>
        /// Cost of the campground per day
        /// </summary>
        public decimal DailyFee { get; set; }
    }
}
