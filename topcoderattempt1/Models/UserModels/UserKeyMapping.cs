using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class UserKeyMapping
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [MaxLength(10)]
        public string KeySerialNumber { get; set; }

        public Keyholder Keyholder { get; set; }
        [DataType(DataType.Date)]
        public DateTime AppliedOn { get; set; }
    }
}
