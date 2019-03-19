using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Web.Models
{
    public class SurveyForm
    {
        /// <summary>
        /// The code of the park voted for
        /// </summary>
        [Display(Name = "CHOOSE A PARK CODE")]
        [Required]
        public string ParkCode { get; set; }

        /// <summary>
        /// The email address of the voter
        /// </summary>
        [Display(Name = "EMAIL")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The home state of the Voter
        /// </summary>
        [Display(Name = "STATE")]
        [Required]
        public string State { get; set; }

        /// <summary>
        /// The Voter's activity level
        /// </summary>
        [Display(Name = "ACTIVITY LEVEL")]
        [Required]
        public string ActivityLevel { get; set; }

        /// <summary>
        /// A list of parks available to vote for
        /// </summary>
        public IList<Park> Parks { get; set; }
    }
}
