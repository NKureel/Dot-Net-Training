using System;
using System.Collections.Generic;

#nullable disable

namespace Testing.Models
{
    public partial class AirlineTbl
    {
        public AirlineTbl()
        {
            InventoryTbls = new HashSet<InventoryTbl>();
        }

        public string AirlineNo { get; set; }
        public string UploadLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }

        public virtual ICollection<InventoryTbl> InventoryTbls { get; set; }
    }
}
