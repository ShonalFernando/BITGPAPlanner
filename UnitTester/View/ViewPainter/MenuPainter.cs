using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.View.ViewPainter
{
    public class MenuPainter
    {
        private Dictionary<string, Action> _menuItems;

        public MenuPainter(Dictionary<string, Action> menuItems)
        {
            _menuItems = menuItems;
        }

        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("==== Main Menu ====");
                int index = 1;
                foreach (var menuItem in _menuItems.Keys)
                {
                    Console.WriteLine($"{index}. {menuItem}");
                    index++;
                }
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter the number of the menu item: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                    {
                        exit = true;
                        Console.WriteLine("Exiting...");
                    }
                    else if (choice > 0 && choice <= _menuItems.Count)
                    {
                        var selectedItem = GetMenuItemByIndex(choice);
                        _menuItems[selectedItem]?.Invoke();
                        Console.WriteLine("\nPress any key to go back to the menu...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }

        private string GetMenuItemByIndex(int index)
        {
            int currentIndex = 1;
            foreach (var menuItem in _menuItems.Keys)
            {
                if (currentIndex == index)
                {
                    return menuItem;
                }
                currentIndex++;
            }
            return null;
        }
    }
}
