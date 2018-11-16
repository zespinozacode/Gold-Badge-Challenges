using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramUI
    {
        public Outing AddOuting()
        {
            EventTypes eventType = new EventTypes();
            bool typeOfEvent = true;
            while (typeOfEvent)
            {
                Console.WriteLine("Select Event Type\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n");
                string inputT = Console.ReadLine();
                Console.Clear();
                switch (inputT)
                {
                    case "1":
                        eventType = EventTypes.Golf;
                        typeOfEvent = false;
                        Console.Clear();
                        break;
                    case "2":
                        eventType = EventTypes.Bowling;
                        typeOfEvent = false;
                        Console.Clear();
                        break;
                    case "3":
                        eventType = EventTypes.Park;
                        typeOfEvent = false;
                        Console.Clear();
                        break;
                    case "4":
                        eventType = EventTypes.Concert;
                        typeOfEvent = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please enter a defined input value.");
                        break;
                }
            }
            Console.WriteLine("Enter the number of atendees:");
            int numPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the date of the outing: (MM/dd/yyyy)");
            DateTime date = outingRepo.StringToDateTime(Console.ReadLine());
            Console.WriteLine("\nEnter the total cost:");
            decimal totalCost = decimal.Parse(Console.ReadLine());
            Outing outing = new Outing(eventType, numPeople, date, totalCost);
            return outing;
        }
        public string Menu()
        {
            Console.WriteLine("Select an option:\n" +
                "\n" +
                "1. See all outings\n" +
                "2. Add an outing\n" +
                "3. Calculate costs\n" +
                "4. Exit\n");
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        OutingRepository outingRepo = new OutingRepository();
        bool isRunning = true;

        public void Run()
        {           

            while (isRunning)
            {
                string input = Menu();
                List<Outing> outings = outingRepo.GetOutings();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Event Type\t" +
                            "Attended\t" +
                            "Date\t\t" +
                            "Total Cost\t" +
                            "Cost per Person");
                        foreach (Outing outing in outings)
                        {
                            Console.WriteLine(outing);
                        }
                        break;
                    case "2":
                        Outing _outing = AddOuting();
                        outingRepo.AddOutings(_outing);
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Which total cost would you like to view?\n" +
                            "1. Total Cost of all outings\n" +
                            "2. Total Cost of each outing type\n");
                        string input3 = Console.ReadLine();
                        Console.Clear();
                        
                        switch (input3)
                        {
                            case "1":
                                decimal total = outingRepo.TotalCost(outings);
                                Console.WriteLine($"The total cost of all outings is: {total}");
                                Console.WriteLine("\nPress Enter to continue...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "2":
                                EventTypes eventType = new EventTypes();
                                bool isRunning = true;
                                while (isRunning)
                                {
                                    Console.WriteLine("Select Event Type\n" +
                                        "1. Golf\n" +
                                        "2. Bowling\n" +
                                        "3. Amusement Park\n" +
                                        "4. Concert\n");
                                    string typeInput = Console.ReadLine();
                                    Console.Clear();                                    
                                    switch (typeInput)
                                    {
                                        case "1":
                                            eventType = EventTypes.Golf;
                                            isRunning = false;
                                            Console.Clear();
                                            break;
                                        case "2":
                                            eventType = EventTypes.Bowling;
                                            isRunning = false;
                                            Console.Clear();
                                            break;
                                        case "3":
                                            eventType = EventTypes.Park;
                                            isRunning = false;
                                            Console.Clear();
                                            break;
                                        case "4":
                                            eventType = EventTypes.Concert;
                                            isRunning = false;
                                            Console.Clear();
                                            break;
                                        default:
                                            Console.WriteLine("Error: Select defined option");
                                            break;
                                    }
                                }
                                decimal totalC = outingRepo.TotalCostByType(outings, eventType);
                                Console.WriteLine($"The total cost of all {eventType} outings is: {totalC}");
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
