using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class Space
    {
        public int ID { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int? State { get; set; }
        public int? StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int Space_Id { get; set; }
    }
}
