using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Menus
{
    public class ParkInfoMenuCLI : IParkInfoMenu
    {
        /// <summary>
        /// The park info display menu.
        /// </summary>
        /// <param name="park">The park</param>
        /// <returns>User input</returns>
        public int DisplayMenu(Park park)
        {
            int input = 0;          

            while (true)
            {
                Console.Clear();
                Console.WriteLine(park.Name);
                Console.WriteLine();
                Console.WriteLine($"Location:           {park.Location}");
                Console.WriteLine($"Established:        {park.EstablishedDate:MMMM dd, yyyy}");
                Console.WriteLine($"Area:               {park.Area:n} sq km");
                Console.WriteLine($"Annual Visitors:    {park.Visitors:n0}");
                Console.WriteLine();
                Console.WriteLine(park.Description);
                Console.WriteLine();
                Console.WriteLine("1: View Campgrounds");
                Console.WriteLine("2: Search for Reservation");
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
                    Console.Clear();
                }
            
            }

            return input;
        }
    }
}
