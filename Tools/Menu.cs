namespace BullsAndCows.Common.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The class displayes the menu and handles the users input on navigation to the menu and has options to return the user's selection of this menu
    /// </summary>
    public class Menu
    {
        private List<string> menuItems;
        private readonly char userPointer = '>';
        private int option = 0;

        public Menu()
        {
            this.menuItems = new List<string>();
            this.menuItems.Add("Singleplayer");
            this.menuItems.Add("Multyplayer");
            this.menuItems.Add("Show top");
            this.menuItems.Add("Exit");
        }

        /// <summary>
        /// Display the menu on the console
        /// </summary>
        public void DisplayMenu()
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == option)
                {
                    Console.WriteLine("{0} {1}", userPointer, menuItems[i]);
                }
                else
                {
                    Console.WriteLine("  {0}", menuItems[i]);
                }
            }
        }

        /// <summary>
        /// Gets the user's selected option
        /// </summary>
        /// <returns></returns>
        public int GetUserOption()
        {
            return this.option;
        }

        /// <summary>
        /// Handles the user input from the console
        /// </summary>
        /// <param name="keypress">Information about the key that is pressed</param>
        /// <returns>Returns the picked from the player selection</returns>
        public int HandleUserMenuPick(ConsoleKeyInfo keypress)
        {
            if (keypress.Key == ConsoleKey.DownArrow)
            {
                if (this.option == menuItems.Count - 1)
                {
                    this.option = 0;
                }
                else
                {
                    this.option++;
                }
                this.DisplayMenu();
            }
            else if (keypress.Key == ConsoleKey.UpArrow)
            {
                if (this.option == 0)
                {
                    this.option = menuItems.Count - 1;
                }
                else
                {
                    this.option--;
                }
                this.DisplayMenu();
            }
            else if (keypress.Key == ConsoleKey.Enter || keypress.Key == ConsoleKey.Spacebar)
            {
                return GetUserOption();
            }

            return -1;
        }
    }
}
