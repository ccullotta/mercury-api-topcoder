using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Dtos
{
    public class CommandCreateDto
    {
        //public int Id { get; set; } remove this as it is automatic
        [Required]
        [MaxLength(300)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }

    }
}
