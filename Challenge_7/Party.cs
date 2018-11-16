﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class Party
    {
        public Party() { }

        public Party(int partyID, List<Booth> booths)
        {
            Booths = booths;
            foreach (Booth booth in booths)
            {
                TotalTickets += booth.TotalTickets;
                TotalCost += booth.TotalCost;
            }
            PartyID = partyID;
        }
        public List<Booth> Booths { get; set; }
        public int PartyID { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalCost { get; set; }
    }
}
