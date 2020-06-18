using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class ChangeEmailRequest
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public string Email { get; set; }
        public DateTime RequestedOn { get; set; }
        [MaxLength(45)]
        #nullable enable
        public string? VerificationToken { get; set; }
        public DateTime? VerificationTokenExpiry { get; set; }
    }
}
