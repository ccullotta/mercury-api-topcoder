using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class Command
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(300)]
        public string Line { get; set; }



        [Required]
        [MaxLength(300)]
        public string Platform { get; set; }
    }

}
