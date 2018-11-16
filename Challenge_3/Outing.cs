﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum EventTypes
    {
        Golf, Bowling, Park, Concert
    }
    public class Outing
    {
        public Outing(EventTypes eventType, int numPeople, DateTime date, decimal totalCost)
        {
            EventType = eventType;
            NumPeople = numPeople;
            Date = date;
            TotalCost = totalCost;
            TotalCostPerPerson = Math.Round(totalCost / numPeople,2);
        }

        public EventTypes EventType { get; set; }
        public int NumPeople { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostPerPerson { get; set; }


        public override string ToString()
        {
            return $"{EventType}\t\t{NumPeople}\t\t{Date.Month}/{Date.Day}/{Date.Year}\t{TotalCost}\t\t{TotalCostPerPerson}";
        }
    }
}
