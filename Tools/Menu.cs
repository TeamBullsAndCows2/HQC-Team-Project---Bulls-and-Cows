using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Common.Tools
{
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

        public int GetUserOption()
        {
            return this.option;
        }

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
