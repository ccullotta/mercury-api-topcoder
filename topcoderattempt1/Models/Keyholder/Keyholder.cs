using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class Keyholder
    {
        public int ID { get; set; }
        public int? StatusId { get; set; }
        public int LocationId { get; set; }
        [MaxLength(10)]
        public string KeySerialNumber { get; set; }

        public UserKeyMapping UserKeyMapping { get; set; }
        [MaxLength(200)]
        #nullable enable
        public string? Name { get; set; }
        public int? State { get; set; }
        [MaxLength(4)]
        public string? Pin { get; set; }
    }
}
