using System.ComponentModel.DataAnnotations;
using topcoderattempt1.Backend;

namespace topcoderattempt1.Dtos
{
    public class UpdateNameEmailDto
    {
        [MinLength(1)]
        [MaxLength(250)]
        public string name { get; set; }
        [EmailAddress]
        [EmailUnique]
        [DataType(DataType.EmailAddress)]
        [MaxLength(250)]
        public string email { get; set; }

    }
}