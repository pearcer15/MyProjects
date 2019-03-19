using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Menus
{
    public interface IParkInfoMenu
    {
        /// <summary>
        /// A method to display park info and retreive user input
        /// </summary>
        /// <param name="park">A Park</param>
        /// <returns>User input</returns>
        int DisplayMenu(Park park);
    }
}
