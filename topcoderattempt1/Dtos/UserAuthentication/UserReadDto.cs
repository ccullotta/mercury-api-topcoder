using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Dtos
{
    public class UserReadDto : UserDto
    {
        public bool? IsEmailVerified { get; set; }

        public int? LastUpdateBy { get; set; }

        //[DataType(DataType.DateTime)]
        public DateTime LastUpdatedOn { get; set; }
    }
}
