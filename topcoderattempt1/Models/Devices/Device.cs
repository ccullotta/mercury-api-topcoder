using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class Device
    {
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(10)]
        [Required]
        public string SerialNumber { get; set; }
        public int LocationId { get; set; }
        public int? StatusId { get; set; }
        public int? DeviceName_ID { get; set; }
    }
}
