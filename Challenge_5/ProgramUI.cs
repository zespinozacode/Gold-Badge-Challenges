using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class ProgramUI
    {
        CustomerRepository customerRepo = new CustomerRepository();

        public void Run()
        {
            List<Customer> customers = customerRepo.ReturnCustomers();
            bool running = true;

            while (running)
            {
                string input = ConsoleMenu();
                switch (input)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        Console.WriteLine("What is the last name of the customer you would like to edit?\n");
                        string lastName1 = Console.ReadLine();
                        EditCustomer(lastName1);
                        break;
                    case "3":
                        Console.WriteLine("\nWhat is the last name of the customer you would like to view?\n");
                        string lastName = Console.ReadLine();
                        GetCustomer(lastName);
                        break;
                    case "4":
                        
                        ViewCustomers();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public string ConsoleMenu()
        {
            Console.WriteLine("Welcome administrator, what would you like to do today?\n" +
                "\n" +
                "1. Add new Customer\n" +
                "2. Edit existing Customer information\n" +
                "3. Find Customer\n" +
                "4. View all Customers\n" +
                "5. Exit\n");
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
        public void GetCustomer(string lastName)
        {
            Console.Clear();
            int count = 0;
            List<Customer> customersList = customerRepo.ReturnCustomers();
            List<Customer> foundCustomers = new List<Customer>();
            foreach (Customer customer in customersList)
            {
                if (customer.LastName == lastName)
                {
                    count++;
                    foundCustomers.Add(customer);
                }
            }
            if (count == 1)
            {
                Console.WriteLine("First \tLast \t\tType\t\tEmail\n");
                Console.WriteLine(foundCustomers[0]);
                Console.WriteLine("\n\nPress Enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Multiple Customers Found:\n" +
                    "\n");
                Console.WriteLine("First \tLast \t\tType\t\tEmail\n");
                foreach (Customer customer in foundCustomers)
                {
                    Console.WriteLine(customer);
                }
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public string GetEmail(CustomerType customerInput)
        {
            switch (customerInput)
            {
                case CustomerType.Potential:
                    return "We currently have the lowest rates on Helicopter Insurance!";
                case CustomerType.Current:
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                case CustomerType.Past:
                    return "It's been a long time since we've heard from you, we want you back.";
                default:
                    return "This is an error.";
            }
        }
        public void AddCustomer()
        {
            Console.Clear();
            bool addLoop = true;
            Console.WriteLine("Enter the Customer's First Name:\t");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nEnter the Customer's Last Name:\t");
            string lastName = Console.ReadLine();
            while (addLoop)
            {
                Console.WriteLine("\n What is the Customer's status:\n" +
                    "1. Potential\n" +
                    "2. Current\n" +
                    "3. Past\n");

                string response = Console.ReadLine();
                Console.Clear();

                CustomerType type;
                string email = "";
                Customer customer;
                switch (response)
                {
                    case "1":

                        type = CustomerType.Potential;
                        addLoop = false;
                        email = GetEmail(type);
                        customer = new Customer(firstName, lastName, type, email);
                        customerRepo.AddToList(customer);
                        Console.Clear();
                        break;
                    case "2":
                        type = CustomerType.Current;
                        addLoop = false;
                        email = GetEmail(type);
                        customer = new Customer(firstName, lastName, type, email);
                        customerRepo.AddToList(customer);
                        Console.Clear();
                        break;
                    case "3":
                        type = CustomerType.Past;
                        addLoop = false;
                        email = GetEmail(type);
                        customer = new Customer(firstName, lastName, type, email);
                        customerRepo.AddToList(customer);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Error: Select defined option");
                        break;
                }
            }

        }
        public void ViewCustomers()
        {
            List<Customer> customers = customerRepo.ReturnCustomers();

            Console.Clear();
            Console.WriteLine("First\tLast \t\tType\t\tEmail");
            var orderedList = customers.OrderBy(c => c.LastName).ToList();
            foreach (Customer customer in orderedList)
            {
                Console.WriteLine(customer);
            }
        }
        public void EditCustomer(string lastName)
        {
            Console.Clear();
            int count = 0;
            List<Customer> allCustomers = customerRepo.ReturnCustomers();
            List<Customer> foundCustomers = new List<Customer>();
            foreach (Customer customer in allCustomers)
            {
                if (customer.LastName == lastName)
                {
                    count++;
                    foundCustomers.Add(customer);
                }
            }
            if (count == 1)
            {
                Console.WriteLine("First \tLast \tType\t\tEmail\n");
                Console.WriteLine(foundCustomers[0]);
                Console.WriteLine("\n\nPress Enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Multiple Customers Found:\n" +
                    "\n");
                Console.WriteLine("First \tLast \t\tType\t\tEmail\n");
                foreach (Customer customer in foundCustomers)
                {
                    Console.WriteLine(customer);
                }
                Console.WriteLine("Enter the first name of the customer you would like to edit");
                count = 0;
                string firstName = Console.ReadLine();
                foreach (Customer customer in foundCustomers)
                {
                    if (customer.FirstName == firstName)
                    {
                        Console.WriteLine("\nWhat would you like to do?\n" +
                            "\n" +
                            "1. Change customer status\n" +
                            "2. Delete customer\n" +
                            "3. Cancel\n");
                        string input = Console.ReadLine();
                        Console.Clear();
                        
                    }
                }
            }
        }
    }
}
