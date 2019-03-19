using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.Menus
{
    public interface IMainMenu
    {
        /// <summary>
        /// A method to display the main menu
        /// </summary>
        /// <param name="parks">A list of parks</param>
        /// <returns>User Input</returns>
        string DisplayMenu(IList<Park> parks);
    }
}
