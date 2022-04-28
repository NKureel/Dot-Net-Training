using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Models
{
    [Table("AirlineTbl",Schema ="dbo")]
    public class AirlineTbl
    {       
        [Key]
        public string AirlineNo { get ; set ; }
        public string UploadLogo { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
    }
}
