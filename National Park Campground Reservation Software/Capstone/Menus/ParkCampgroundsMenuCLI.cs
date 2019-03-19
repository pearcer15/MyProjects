using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Menus
{
    public class ParkCampgroundsMenuCLI : IParkCampgroundsMenu
    {
        /// <summary>
        /// The Park Campgrounds Menu.
        /// </summary>
        /// <param name="park">The park</param>
        /// <param name="campgrounds">The campgrounds</param>
        /// <returns>User input</returns>
        public int DisplayMenu(Park park, IList<Campground> campgrounds)
        {
            int input = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{park.Name} National Park Campgrounds");
                Console.WriteLine();
                Console.WriteLine("      Name                               Open           Close          Daily Fee");
                foreach (Campground campground in campgrounds)
                {
                    string openingMonth = intToMonth(campground.OpeningMonth);
                    string closingMonth = intToMonth(campground.ClosingMonth);
                    Console.WriteLine($"#{campground.ID, -5}{campground.Name, -35}{openingMonth, -15}{closingMonth, -15}{campground.DailyFee, -15:C2}");
                }
                Console.WriteLine();
                Console.WriteLine("1: Search for Reservation");
                Console.WriteLine("2: View upcoming reservations");
                Console.WriteLine("3: Return to Previous Screen");
                Console.Write("Please make a selection: ");
                if (int.TryParse(Console.ReadLine(), out input) && (input > 0 && input < 4))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input, please try again");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }

            return input;
        }

        private string intToMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "How is this possible?";
            }
        }
       
        /// <summary>
        /// Shows a list of reservations.
        /// </summary>
        /// <param name="reservations">The reservations</param>
        public void ShowReservations(IList<Reservation> reservations)
        {
            Console.Clear();
            Console.WriteLine("Upcoming Reservations:");
            Console.WriteLine("Res. ID  Site ID    Camper Name                             Start Date       End Date         Res Created");
            foreach( Reservation res in reservations)
            {
                Console.WriteLine($"{res.ID, -10}{res.SiteID, -10}{res.Name, -40}{res.StartDate:MM/dd/yyyy}       {res.EndDate:MM/dd/yyyy}        {res.CreationDate:MM/dd/yyyy}");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
