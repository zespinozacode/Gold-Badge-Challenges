using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public enum ClaimTypes { Vehicle = 1, Home = 2, Theft = 3, Default = 4}
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public string DateOfAccident { get; set; }
        public string DateOfClaim { get; set; }
        public decimal ClaimAmount { get; set; }
        public bool IsValid { get; set; }

        public Claims(int claimID, ClaimTypes claimType, string description, string dateAccident, string dateClaim, decimal claimAmount, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            DateOfAccident = dateAccident;
            DateOfClaim = dateClaim;
            ClaimAmount = claimAmount;
            IsValid = isValid;
        }

        public override string ToString() => $"ClaimID: {ClaimID}\n Type: {ClaimType}\n Description: {Description}\n Date of Accident: {DateOfAccident}\n Date of Claim: {DateOfClaim}\n Claim Amount: {ClaimAmount}\n Valid Claim: {IsValid}";

        public bool TimeSpanBool(Claims content)
        {
            TimeSpan AccidentDifference = Convert.ToDateTime(content.DateOfClaim) - Convert.ToDateTime(content.DateOfAccident);

            bool IsValid;
            if (AccidentDifference.Days <= 30)
                isValid = true;
            else isValid = false;
            IsValid = isValid;

            return IsValid;
        }
    }
}
