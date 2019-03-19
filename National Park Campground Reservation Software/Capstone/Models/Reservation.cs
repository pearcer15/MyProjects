using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// Models a camping reservation
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// ID number for a reservation
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID for the reserved site
        /// </summary>
        public int SiteID { get; set; }

        /// <summary>
        /// Name of the person reserving the site
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Start of the resservation
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End of the reservation
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// When the reservation was created
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
