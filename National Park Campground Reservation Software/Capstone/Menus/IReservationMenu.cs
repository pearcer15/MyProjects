using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Menus
{
    public interface IReservationMenu
    {
        /// <summary>
        /// A method to display the menu and retrieve user input
        /// </summary>
        /// <param name="park">The park</param>
        /// <param name="campgrounds">List of campgrounds</param>
        /// <returns>A campground, start date, end date, cancel bool</returns>
        (int, DateTime, DateTime, bool) DisplayMenu(Park park, IList<Campground> campgrounds);

        /// <summary>
        /// A method to make a reservation
        /// </summary>
        /// <param name="sites">A list of sites</param>
        /// <param name="campgrounds">A list of campgrounds</param>
        /// <param name="reservationRequest">The user's input from "Display Menu"</param>
        /// <returns>selected site, camper name, cancel bool</returns>
        (int, string, bool) MakeReservation(IList<Site> sites, IList<Campground> campgrounds, (int campground, DateTime from, DateTime to, bool keepGoing) reservationRequest);

        /// <summary>
        /// A method to display the no sites available message
        /// </summary>
        /// <returns>if the user wants to continue</returns>
        bool NoSitesAvailable();

        /// <summary>
        /// A method to confirm a reservation
        /// </summary>
        /// <param name="resID">the reservation ID</param>
        void ConfirmReservation(int resID);

        /// <summary>
        /// A method to tell the user their selected dates are out of range
        /// </summary>
        void DateOutOfRange();
    }
}
