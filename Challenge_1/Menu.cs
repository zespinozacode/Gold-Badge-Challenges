using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public decimal MealPrice { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }

        public Menu(int number, decimal price, string name, string description, string ingredients)
        {
            MealNumber = number;
            MealPrice = price;
            MealName = name;
            MealDescription = description;
            MealIngredients = ingredients;
        }

        public Menu()
        {

        }
    }
}
