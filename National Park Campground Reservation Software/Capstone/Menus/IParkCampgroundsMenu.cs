using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Menus
{
    public interface IParkCampgroundsMenu
    {
        /// <summary>
        /// A method to display the menu and retreive user input
        /// </summary>
        /// <param name="park">The selected park</param>
        /// <param name="campgrounds">The park's campgrounds</param>
        /// <returns>User Input</returns>
        int DisplayMenu(Park park, IList<Campground> campgrounds);

        /// <summary>
        /// A method to show upcoming reservations
        /// </summary>
        /// <param name="">A list of reservations</param>
        void ShowReservations(IList<Reservation> reservations);
    }
}
