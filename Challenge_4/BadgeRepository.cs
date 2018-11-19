using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> badgePairs = new Dictionary<int, List<string>>();


        public void NewBadge(Badge badge)
        {
            badgePairs.Add(badge.BadgeID, badge.Door);
        }
      

        public Dictionary<int, List<string>> GetBadges()
        {
            return badgePairs;
        }
    }
}
