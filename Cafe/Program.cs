using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuUI ui = new MenuUI();
            ui.Run();
        }
        public class MenuUI
        {
            private CafeRepo _menu = new CafeRepo();
            public void Run()
            {

                MenuFront();
            }

            public void MenuFront()
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the Number you want to select:\n" +
                        "1. Show Menu\n" +
                        "2. Find item by Menu Number\n" +
                        "3. Add new menu items\n" +
                        "4. Update existing menu Items\n" +
                        "5. Remove menu Items\n" +
                        "6. Exit");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            _menu.ShowMenu();
                            break;
                        case "2":
                            _menu.ShowMenuNum();
                            break;
                        case "3":
                            _menu.NewMenuItem();
                            break;
                        case "4":
                            _menu.DeleteMenuItemByMenuNumber();
                            break;
                        case "5":

                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}

