using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Capstone.Menus;
using System.Linq;

namespace Capstone
{
    /// <summary>
    /// A class to control interaction between CLI and DAO
    /// </summary>
    public class NPSystemController
    {
        private IParkDAO parkDAO;
        private ICampgroundDAO campgroundDAO;
        private ISiteDAO siteDAO;
        private IReservationDAO reservationDAO;
        private IMainMenu mainMenu;
        private IParkInfoMenu parkInfoMenu;
        private IParkCampgroundsMenu parkCampgrounds;
        private IReservationMenu reservationMenu;

        public NPSystemController(IParkDAO parkDAO, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO, IMainMenu mainMenu, IParkInfoMenu parkInfoMenu, IParkCampgroundsMenu parkCampgrounds, IReservationMenu reservationMenu)
        {
            this.parkDAO = parkDAO;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.reservationDAO = reservationDAO;
            this.mainMenu = mainMenu;
            this.parkInfoMenu = parkInfoMenu;
            this.parkCampgrounds = parkCampgrounds;
            this.reservationMenu = reservationMenu;
        }

        /// <summary>
        /// Runs the national park reservation system
        /// </summary>
        public void Run()
        {
            //Get the list of parks from the database
            IList<Park> parks = parkDAO.GetAllParks();

            //The loop which keeps us in the menu system until you quit
            while (true)
            {
                //Displaying the main menu
                string mMInput = mainMenu.DisplayMenu(parks);

                //The check for a command to quit
                if (mMInput.ToLower() == "q")
                {
                    break;
                }

                //Converting the user's input into a specific park object
                int parkID = int.Parse(mMInput);
                Park userPark = parks[parkID - 1];

                //The loop which keeps us in the park info menu
                while (true)
                {
                    //Get the list of campgrounds in the park
                    IList<Campground> campgrounds = campgroundDAO.GetAllCampgroundsByPark(parkID);

                    //Display the park info menu
                    int pIInput = parkInfoMenu.DisplayMenu(userPark);

                    //Declaring the variable for input from the campground menu here so it persists outside the if statement where we visit that menu
                    int pCInput = 0;

                    //If the input on the park info menu is 1 we go to the campgrounds menu
                    if (pIInput == 1)
                    {
                        //Displaying the campgrounds menu
                        pCInput = parkCampgrounds.DisplayMenu(userPark, campgrounds);
                    }

                    //If you choose "Search for a Reservation" on either the park info or campground menu
                    if (pIInput == 2 || pCInput == 1)
                    {
                        //Creating a list that will store the the available sites
                        IList<Site> sites = new List<Site>();

                        //Creating a variable to store information returned from the "Display Menu" method of the reservation menu
                        int campgroundID = 0;
                        DateTime requestedStart = new DateTime(1753, 01, 01);
                        DateTime requestedEnd = new DateTime(1753, 01, 01);
                        bool makeReservation = true;
                        var reservationRequest = (campground: campgroundID, from: requestedStart, to: requestedEnd, keepGoing: makeReservation);

                        //A boolean to control when we break out of these nested while loops
                        bool looper = false;

                        //The loop which keeps us in the Reservation Menu's display menu method
                        do
                        {
                            //Making sure this is false whenever we start the loop
                            looper = false;

                            //Displayinng the reservation menu
                            reservationRequest = reservationMenu.DisplayMenu(userPark, campgrounds); Campground thisCampground = new Campground();

                            //Making sure the requested stay is within the open season of the campground
                            if (reservationRequest.campground != 0)
                            {
                                //Getting this specific campground we are looking at
                                List<Campground> camps = new List<Campground>(campgrounds.Where(c => c.ID == reservationRequest.campground));
                                thisCampground = camps[0];

                                if (reservationRequest.from.Month < thisCampground.OpeningMonth || reservationRequest.to.Month > thisCampground.ClosingMonth)
                                {
                                    //Changing the control variable so we stay in this loop
                                    looper = true;
                                    //Displaying the out of range message
                                    reservationMenu.DateOutOfRange();
                                }
                            }

                            //Where we break if the user chooses to cancel
                            if (reservationRequest.keepGoing == false)
                            {
                                //changing the control variable so we return to the top menu
                                looper = true;
                                break;
                            }

                            //retreiving the list of available sites
                            sites = siteDAO.GetAvailableSites(parkID, reservationRequest.campground, reservationRequest.from, reservationRequest.to);
                            if (sites.Count == 0)
                            {
                                //changing the control variable
                                looper = true;

                                //telling the user there were no sites available and checking their choice of whther or not to continue
                                if (!reservationMenu.NoSitesAvailable())
                                {
                                    break;
                                }
                            }

                        } while (looper);

                        //If we display the make reservation menu
                        if (!looper)
                        {
                            //Creating a variable to store information returned from the "make reservation" method of the reservsation menu
                            int selectedSite = 0;
                            string camperName = "";
                            bool pressOnward = true;
                            var camperAndSite = (site: selectedSite, camper: camperName, keepGoing: pressOnward);

                            //Displaying the make reservation menu
                            camperAndSite = reservationMenu.MakeReservation(sites, campgrounds, reservationRequest);

                            //where we allow the user to quit
                            if (camperAndSite.keepGoing == false)
                            {
                                break;
                            }

                            //turning the user's input into a reservation object
                            Reservation newReservation = new Reservation();
                            newReservation.SiteID = camperAndSite.site;
                            newReservation.Name = camperAndSite.camper;
                            newReservation.StartDate = reservationRequest.from;
                            newReservation.EndDate = reservationRequest.to;

                            //Storing the reservation in the database and returning the reservztion id
                            int reservationID = reservationDAO.MakeReservation(newReservation);

                            //Displaying the confirmation message
                            reservationMenu.ConfirmReservation(reservationID);
                            break;
                        }
                    }
                    //The input for return to previous screen
                    else if (pIInput == 3)
                    {
                        break;
                    }
                    //The choice for looking at upcoming reservations
                    else if (pCInput == 2)
                    {
                        //Displaying the upcoming reservations
                        parkCampgrounds.ShowReservations(reservationDAO.GetReservations(userPark));
                    }
                }
            }
        }
    }
}
