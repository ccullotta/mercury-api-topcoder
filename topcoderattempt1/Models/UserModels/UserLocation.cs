using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class UserLocation
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsToolKitEnabled { get; set; }
        public int? StatusId { get; set; }
        public UserStatus Status { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int State { get; set; }
        [MaxLength(200)]
        #nullable enable
        public string? DisabledReason { get; set; }

        public UserPermission? UserPermission { get; set; }


    }
}
