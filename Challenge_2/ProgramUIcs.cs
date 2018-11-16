using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ProgramUIcs
    {
        static void Main(string[] args)
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claims> claimQueue = claimRepo.ReturnClaims();

            Claims Zach = new Claims(1, ClaimTypes.Vehicle, "Collision on State Road 37", "11/09/2018", "11/12/2018", 1000.00m, true);
            Claims Chris = new Claims(2, ClaimTypes.Home, "Strong hail damaged roof", "01/21/2017", "10/24/2018", 400.00m, false);
            Claims Derek = new Claims(3, ClaimTypes.Theft, "Home invader resulted in stolen property", "07/02/2018", "07/30/2018", 5000.00m, true);
            claimRepo.AddClaimsToQueue(Zach);
            claimRepo.AddClaimsToQueue(Chris);
            claimRepo.AddClaimsToQueue(Derek);

            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. See Claims\n2.Take Care Of Claims\n3.Input New Claim\n4.Exit");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        claimRepo.ReturnClaims();

                        foreach (Claims claim in claimQueue)
                        {
                            Console.WriteLine($"{claim.ClaimID} \t {claim.ClaimType} \t {claim.Description} \t {claim.ClaimAmount} \t {claim.DateOfAccident} \t {claim.DateOfClaim} \t {claim.IsValid}");
                        }
                        Console.WriteLine("Please press Enter...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"{claimQueue.Peek()} \n");
                        Console.WriteLine("Would you like to take care of this claim? y/n");
                        var editClaim = Console.ReadLine();

                        if (editClaim == "y")
                        {
                            claimRepo.RemoveClaim();
                        }
                        Console.WriteLine("Claim filed, press enter to continue...");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please enter claim identification number:");
                        var input2 = Console.ReadLine();
                        var claimID = int.Parse(input2);

                        Console.WriteLine("Please enter the type of claim: 1-Vehicle, 2-Home, 3-Theft");
                        string input3 = Console.ReadLine();
                        int claimType = int.Parse(input3);
                        ClaimTypes claimTypes;
                        if (claimType == 1)
                            claimTypes = ClaimTypes.Vehicle;
                        if (claimType == 2)
                            claimTypes = ClaimTypes.Home;
                        if (claimType == 3)
                            claimTypes = ClaimTypes.Theft;

                        Console.WriteLine("Please write a brief description of the claim:");
                        var description = Console.ReadLine();
                        
                        Console.WriteLine("What is the claim ammount?");
                        var inputAmount = Console.ReadLine();
                        decimal claimAmount = Decimal.Parse(inputAmount);
                        
                        Console.WriteLine("When did the accident occour? mm/dd/yyyy");
                        var dateAccident = Console.ReadLine();

                        Console.WriteLine("When was the accident filed? mm/dd/yyyy");
                        var dateClaim = Console.ReadLine();

                        
                        

                        claimRepo.AddClaimsToQueue(claimType);
                        break;
                }

            }
        }
    }
}
