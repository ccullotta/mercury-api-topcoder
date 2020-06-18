using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Dtos
{
    public class UserCreateDto : UserDto
    {
        [Required]
        [MaxLength(256)]
        // TODO: [DataType(DataType.Password)]  
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string SecurityQuestion { get; set; }

        [Required]
        [MaxLength(200)]
        public string SecurityQuestionAnswer { get; set; }


    }
}
