using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    /// <summary>
    /// This models a park
    /// </summary>
    public class Park
    {
        /// <summary>
        /// The park id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the park
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location of the park
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Date of park establishment
        /// </summary>
        public DateTime EstablishedDate { get; set; }

        /// <summary>
        /// Area of park in square kilometers
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Annual visitors to the park
        /// </summary>
        public int Visitors { get; set; }

        /// <summary>
        /// Description of the park
        /// </summary>
        public string Description { get; set; }
    }
}
