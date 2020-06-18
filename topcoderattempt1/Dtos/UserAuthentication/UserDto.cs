using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Backend;

namespace topcoderattempt1.Dtos
{
    public class UserDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [EmailUnique]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
