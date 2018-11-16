using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        CafeMenuRepository menuRepository = new CafeMenuRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do" +
                    "\n1. Create a new meal" +
                    "\n2. Delete a meal" +
                    "\n3. List Meals" +
                    "\n4. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateMeal();
                        break;
                    case 2:
                        DeleteMeal();
                        break;
                    case 3:
                        ListMeal();
                        break;
                    case 4:
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("INVALID RESPONSE");
                        break;
                }
            }
        }

        private void CreateMeal()
        {
            Console.Clear();
            Menu newMeal = new Menu();
            Console.WriteLine("What number would you like to assign to this meal?");
            newMeal.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat would you like to call this meal?");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("\nWrite a brief description for this meal.");
            newMeal.MealDescription = Console.ReadLine();

            Console.WriteLine("\nWhat ingredients does this meal contain? Write them on one line, seperated by commas.");
            newMeal.MealIngredients = Console.ReadLine();

            Console.WriteLine("\nWhat is the price of this meal?");
            newMeal.MealPrice = decimal.Parse(Console.ReadLine());

            menuRepository.AddItemsToMenu(newMeal);
        }

        private void DeleteMeal()
        {
            Console.Clear();
            List<Menu> meals = menuRepository.GetMenus();
            Console.WriteLine("Which meal number would you like to delete?");
            int input = int.Parse(Console.ReadLine());

            foreach (Menu meal in meals)
            {
                if(input == meal.MealNumber)
                {
                    menuRepository.RemoveItemsFromMenu(meal);
                    break;
                }
            }
              
            
        }
        private void ListMeal()
        {
            Console.Clear();
            List<Menu> menus = menuRepository.GetMenus();
            foreach (Menu menu in menus)
            {
                Console.WriteLine($"{menu.MealNumber}: {menu.MealName}.");
            }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
        }














    }
}
