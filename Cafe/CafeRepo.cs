using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeRepo
    {
        public List<Menu> menu = new List<Menu>();
        public List<Menu> GetMenu()
        {
            return menu;
        }
        public void findMeal(Menu menu)
        {
            Console.WriteLine(menu.Meal);
            Console.WriteLine(menu.MenuNum);
            Console.WriteLine(menu.Description);
            Console.WriteLine(menu.Ingredients);
            Console.WriteLine(menu.Price);
        }
        public Menu GetMenuNumber(int menuNum)
        {
            foreach (Menu menu in menu)
            {
                if (menu.MenuNum == menuNum)
                {
                    return menu;
                }
                else Console.WriteLine("We currently are not selling that item");
            }
            return null;
        }
        public void ShowMenu()
        {
            Console.Clear();
            List<Menu> FullMenu = menu;
            foreach (Menu menu in FullMenu)
            {
                findMeal(menu);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        public void ShowMenuNum()
        {
            Console.Clear();
            Console.WriteLine("Enter the menu number you want");
            int menuNum = Int32.Parse(Console.ReadLine());
            Menu menu = GetMenuNumber(menuNum);
            if (menu == null)
            {
                Console.WriteLine("We currently do not have that item");
            }
            else
            {
                findMeal(menu);
            }
            Console.ReadKey();
        }
        public void AddItemToMenu(){}
        public bool AddItemToMenu(Menu newitem)
        {
            int StartCount = menu.Count;
            menu.Add(newitem);
            bool wasAdded = (menu.Count > StartCount) ? true : false;
            return wasAdded;
        }
        public void NewMenuItem()
        {
            Console.Clear();
            Menu NewItem = new Menu();
            Console.WriteLine("Enter a new Meal Name");
            NewItem.Meal = Console.ReadLine();
            Console.WriteLine("Enter a new menu number");
            NewItem.MenuNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter a new Description");
            NewItem.Description = Console.ReadLine();
            Console.WriteLine("Enter a new Price");
            string PriceAsString = Console.ReadLine();
            double PriceAsDouble = double.Parse(PriceAsString);
            NewItem.Price = PriceAsDouble;
            Console.WriteLine("Enter Meal's Ingredients");
            NewItem.Ingredients = Console.ReadLine();
            AddItemToMenu(NewItem);
        }
        public bool DeleteExistingMenuItem(Menu existingMenuItem)
        {
            bool deleteResult = menu.Remove(existingMenuItem);
            return deleteResult;
        }
        public void DeleteMenuItemByMenuNumber()
        {
            Console.Clear();
            ShowMenu();
            Console.WriteLine("Enter Menu Number to Delete.");
            var menuItemToDelete = Int32.Parse(Console.ReadLine());
            Menu numToDelete = GetMenuNumber(menuItemToDelete);
            bool wasDeleted = DeleteExistingMenuItem(numToDelete);
            if (wasDeleted)
            {
                Console.WriteLine("This item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Item could not be deleted");
            }
        }
    }
}
