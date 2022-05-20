using System;
using System.Collections.Generic;

#nullable disable

namespace Testing.Models
{
    public partial class InventoryTbl
    {
        public string FlightNumber { get; set; }
        public string AirlineNo { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScheduleDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int? BusinessClassSeat { get; set; }
        public int? NonBusinessClassSeat { get; set; }
        public decimal? TicketCost { get; set; }
        public int? NoOfRows { get; set; }
        public string Meal { get; set; }

        public virtual AirlineTbl AirlineNoNavigation { get; set; }
    }
}
