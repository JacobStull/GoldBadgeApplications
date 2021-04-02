using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Menu
    {
        public string Meal { get; set; }
        public int MenuNum { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public Menu(string meal, int menuNum, string description, string ingredients, double price)
        {
            Meal = meal;
            MenuNum = menuNum;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public Menu() { }
    }
}
