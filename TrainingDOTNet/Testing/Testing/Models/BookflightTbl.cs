using System;
using System.Collections.Generic;

#nullable disable

namespace Testing.Models
{
    public partial class BookflightTbl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public int? PersonId { get; set; }
        public string Meal { get; set; }
        public string FlightNumber { get; set; }
        public string Pnr { get; set; }
    }
}
