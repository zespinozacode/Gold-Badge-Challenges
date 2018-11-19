using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class ProgramUI
    {
        public BadgeRepository badgeRepo = new BadgeRepository();
        bool isRunning = true;

        public void Run()
        {
            while (isRunning)
            {
                int badgeID;
                string input = Menu();
                Dictionary<int, List<string>> badges = badgeRepo.GetBadges();
                switch (input)
                {
                    case "1":
                        List<string> doorValue = new List<string>();
                        Console.WriteLine("\nWhat is the badge identification number?:");
                        badgeID = int.Parse(Console.ReadLine());
                        bool doorList = true;
                        while (doorList)
                        {
                            Console.WriteLine("\nList a door that it needs access to:");
                            doorValue.Add(Console.ReadLine());
                            bool doorLoop = true;
                            while (doorLoop)
                            {
                                Console.WriteLine("\nAny other doors(y/n)?");
                                string doorInput =Console.ReadLine();
                                switch (doorInput)
                                {
                                    case "y":
                                        doorLoop = false;
                                        doorList = true;
                                        Console.Clear();
                                        break;
                                    case "n":
                                        doorLoop = false;
                                        doorList = false;
                                        Badge badge = new Badge(badgeID, doorValue);
                                        badgeRepo.NewBadge(badge);
                                        Console.Clear();
                                        break;
                                    default:
                                        doorLoop = true;
                                        Console.Clear();
                                        break;
                                }
                            }

                        }
                        break;
                    case "2":
                        Console.WriteLine("What is the ID of the badge you'd like to update?");
                        badgeID = int.Parse(Console.ReadLine());

                        if (badges.Keys.Contains(badgeID))
                        {
                            bool keyLoop = true;
                            while (keyLoop)
                            {
                                Console.WriteLine($"\nBadge {badgeID} can access the following doors: ");
                                badges[badgeID].ForEach(i => Console.Write($"{i},  "));
                                Console.WriteLine("\n\nWhat would you like to do?\n" +
                                    "1. Remove door\n" +
                                    "2. Add door\n" +
                                    "3. Cancel\n");
                                string doorInput = Console.ReadLine();
                                switch (doorInput)
                                {
                                    case "1":
                                        keyLoop = false;
                                        Console.WriteLine("\nSelect a door to remove.");
                                        string remove = Console.ReadLine();
                                        badges[badgeID].Remove(remove);
                                        Console.Clear();
                                        break;
                                    case "2":
                                        keyLoop = false;
                                        Console.WriteLine("\nAdd a door number for access");
                                        string add = Console.ReadLine();
                                        badges[badgeID].Add(add);
                                        Console.Clear();
                                        break;
                                    case "3":
                                        keyLoop = false;
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                            }
                            break;
                        }
                        break;

                    case "3":

                        Console.WriteLine("\nBadgeID\t\tDoorAccess\n");
                        foreach (int id in badges.Keys)
                        {
                            string listDoor = "";
                            foreach (string door in badges[id])
                            {
                                listDoor += door + "\t";
                            }
                            Console.WriteLine($"{id}\t\t{listDoor}");
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
        public string Menu()
        {
            Console.WriteLine($"Hello Security Admin, What would you like to do?\n" +
                "\n" +
                "1. Add new Badge\r\n" +
                "2. Edit existing Badge\n" +
                "3. View all Badges\n" +
                "4. Exit\n");
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
    }
}
