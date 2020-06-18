using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class DeviceStatus
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LocationId { get; set; }
    }
}
