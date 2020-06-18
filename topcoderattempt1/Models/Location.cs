using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class Location
    {
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public ICollection<UserLocation> UserLocations { get; set; }
        public ICollection<UserKeyMapping> UserKeyMappings { get; set; }

        public ICollection<UserStatus> UserStatuses { get; set; }

    }
}
