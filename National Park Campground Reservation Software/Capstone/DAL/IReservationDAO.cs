using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        /// <summary>
        /// Makes a reservation.
        /// </summary>
        /// <param name="reservation">The reservation</param>
        /// <returns>reservation id</returns>
        int MakeReservation(Reservation reservation);

        /// <summary>
        /// Returns list of upcoming reservations.
        /// </summary>
        /// <param name="park">Park of reservations.</param>
        /// <returns>List of upcoming reservations.</returns>
        IList<Reservation> GetReservations(Park park);
        
    }
}
