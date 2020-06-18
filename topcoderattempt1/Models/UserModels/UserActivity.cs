using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        public int UserId {get;set;}

        public UserModel User { get; set; }

        [MaxLength(250)]
        public string ActivityText { get; set; }

        public int LocationId { get; set; }

        [Timestamp]
        public byte[] ActvityTime { get; set; }
    }
}
