using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public class ProgramUI
    {
        CarRepository carRepo = new CarRepository();

        public void Run()
        {            
            bool isRunning = true;
            while (isRunning)
            {
                string input = ConsoleMenu();
                switch (input)
                {
                    case "1":
                        CreateCar();
                        break;
                    case "2":
                        EditCar();
                        break;
                    case "3":
                        ViewCar();
                        break;
                    case "4":
                        ViewTypeCars();
                        break;
                    default:
                        break;
                }
            }
        }

        public string ConsoleMenu()
        {
            Console.WriteLine("\nWhat would you like to do?\n" +
                "\n" +
                "1. Add new Car\n" +
                "2. Edit existing Car information\n" +
                "3. View Car\n" +
                "4. View Cars by Type\n" +
                "5. Exit\n");
            string input = Console.ReadLine();
            return input;
        }

        public void CreateCar()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car is this?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n" +
                "4. Cancel\n");
            string input = Console.ReadLine();
            int createInt = int.Parse(input);
            if (createInt == 1 || createInt == 2 || createInt == 3)
            {
                Console.WriteLine("\nEnter the make:");
                string make = Console.ReadLine();
                Console.WriteLine("\nEnter the model:");
                string model = Console.ReadLine();
                Console.WriteLine("\nEnter the year:");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter the MPG / MPGe:");
                decimal mpg = decimal.Parse(Console.ReadLine());
                Car newCar = new Car(make, model, year, mpg, (CarTypes)createInt - 1);
                carRepo.AddCar(newCar);
            }
            Console.Clear();
        }

        public void EditCar()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car is this?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n" +
                "4. Cancel\n");
            string input = Console.ReadLine();
            Console.Clear();
            int editInt = int.Parse(input);
            if ( editInt== 1 || editInt == 2 || editInt == 3)
            {
                List<Car> search = carRepo.GetCars((CarTypes)editInt - 1);
                Console.WriteLine("\nEnter the make:");
                string make = Console.ReadLine();
                Console.WriteLine("\nEnter the model:");
                string model = Console.ReadLine();
                Console.WriteLine("\nEnter the year:");
                int year = int.Parse(Console.ReadLine());

                Console.Clear();
                foreach (Car car in search)
                {
                    if (car.Make == make && car.Model == model && car.Year == year)
                    {
                        bool running = true;
                        while (running)
                        {
                            Console.WriteLine("Make\t\tModel\t\tYear\t\tMPG\t\tType\n");
                            Console.WriteLine(car);
                            Console.WriteLine("\n" +
                                "What would you like to update?\n" +
                                "1. Make\n" +
                                "2. Model\n" +
                                "3. Year\n" +
                                "4. MPG\n" +
                                "5. Type of Car\n" +
                                "6. Delete Car\n" +
                                "7. Nothing\n");
                            string inputEdit = Console.ReadLine();
                            Console.Clear();
                            int edit = int.Parse(inputEdit);
                            if (edit == 1 || edit == 2 || edit == 3 || edit == 4 || edit == 5 || edit == 6)
                            {
                                UpdateCar(car, edit);
                            }
                            else
                            {
                                running = false;
                                break;
                            }
                        }
                    }
                }
                Console.Read();
            }
        }

        public void ViewCar()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car is this?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n" +
                "4. Cancel\n");
            string input = Console.ReadLine();
            Console.Clear();
            int type = int.Parse(input);
            if (type == 1 || type == 2 || type == 3)
            {
                List<Car> search = carRepo.GetCars((CarTypes)type - 1);
                Console.WriteLine("\nEnter the make:");
                string make = Console.ReadLine();
                Console.WriteLine("\nEnter the model:");
                string model = Console.ReadLine();
                Console.WriteLine("\nEnter the year:");
                int year = int.Parse(Console.ReadLine());

                Console.Clear();
                foreach (Car car in search)
                {
                    if (car.Make == make && car.Model == model && car.Year == year)
                    {
                        Console.WriteLine("Make\t\tModel\t\tYear\t\tMPG\t\tType\n");
                        Console.WriteLine(car);
                        Console.WriteLine("\n\n" +
                            "Press Enter to Continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
        }

        public void ViewTypeCars()
        {
            Console.Clear();
            Console.WriteLine("\nWhat type of car?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n" +
                "4. Cancel\n");
            string input = Console.ReadLine();
            Console.Clear();
            int type = int.Parse(input);
            if (type == 1 || type == 2 || type == 3)
            {
                List<Car> search = carRepo.GetCars((CarTypes)type - 1);
                Console.Clear();
                Console.WriteLine("Make\t\tModel\t\tYear\t\tMPG\t\tType\n");
                foreach (Car car in search)
                {
                    Console.WriteLine(car);
                }
                Console.WriteLine("\n\n" +
                    "Press Enter to Continue:");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void UpdateCar(Car editCar, int editChoice1to6)
        {
            switch (editChoice1to6)
            {
                case 1:
                    //--Edit Make
                    carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new Make:");
                    string make = Console.ReadLine();
                    editCar.Make = make;
                    Console.Clear();

                    carRepo.AddCar(editCar);
                    break;
                case 2:
                    //--Edit Model
                    carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new Model:");
                    string model = Console.ReadLine();
                    editCar.Model = model;
                    Console.Clear();

                    carRepo.AddCar(editCar);
                    break;
                case 3:
                    //--Edit Year
                    carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new Year:");
                    int year = int.Parse(Console.ReadLine());
                    editCar.Year = year;
                    Console.Clear();

                    carRepo.AddCar(editCar);
                    break;
                case 4:
                    //--Edit MPG
                    carRepo.RemoveCar(editCar);
                    Console.WriteLine("Enter the new MPG:");
                    decimal mpg = decimal.Parse(Console.ReadLine());
                    editCar.MPG = mpg;
                    Console.Clear();

                    carRepo.AddCar(editCar);
                    break;
                case 5:
                    //--Edit Type
                    Console.WriteLine("\nWhat new type of car is this?\n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas\n" +
                        "4. Cancel\n");
                    string input = Console.ReadLine();
                    int type = int.Parse(input);
                    if (type == 1 || type == 2 || type == 3)
                    {
                        carRepo.RemoveCar(editCar);
                        editCar.CarType = (CarTypes)type - 1;
                        carRepo.AddCar(editCar);

                    }
                    Console.Clear();

                    break;
                case 6:
                    //--Delete Car
                    Console.WriteLine("Are you sure?\n" +
                        "y/n\n");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "y":
                            carRepo.RemoveCar(editCar);
                            break;

                        default:
                            break;
                    }
                    Console.Clear();
                    break;
                default:
                    break;
            }

        }
    }
}
