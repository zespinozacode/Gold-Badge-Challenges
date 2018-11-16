using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        Queue<Claims> _claimQueue = new Queue<Claims>();
        bool isValid;

        public Queue<Claims> ReturnClaims()
        {
            return _claimQueue;
        }

        public Queue<Claims> RemoveClaim()
        {
            _claimQueue.Dequeue();
            return _claimQueue;
        }

        public void AddClaimsToQueue(Claims content)
        {
            _claimQueue.Enqueue(content);
        }

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
