using System;
using System.Collections.Generic;

#nullable disable

namespace Testing.Models
{
    public partial class FlightDetail
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string SeatNo { get; set; }
        public string SeatClass { get; set; }
        public string Status { get; set; }
    }
}
