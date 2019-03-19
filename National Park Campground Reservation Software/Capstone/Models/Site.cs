using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Models a camp site in a campground in a park
    /// </summary>
    public class Site
    {
        /// <summary>
        /// The site id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID of the campground the site is in
        /// </summary>
        public int CampgroundID { get; set; }

        /// <summary>
        /// Site Number
        /// </summary>
        public int SiteNumber { get; set; }

        /// <summary>
        /// Maximum occupancy of the site
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Whether or not the site is handicap accessible
        /// </summary>
        public bool Accessible { get; set; }

        /// <summary>
        /// Maximum RV length of the campsite
        /// </summary>
        public int MaxRVLength { get; set; }

        /// <summary>
        /// If the site has a utility hookup
        /// </summary>
        public bool Utilities { get; set; }
    }
}
