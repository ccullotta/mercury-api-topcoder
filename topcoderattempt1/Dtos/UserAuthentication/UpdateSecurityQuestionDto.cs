using System.ComponentModel.DataAnnotations;

namespace topcoderattempt1.Dtos
{
    public class UpdateSecurityQuestionDto
    {
        [Required]
        [MaxLength(200)]
        public string question { get; set; }

        [Required]
        [MaxLength(200)]
        public string answer { get; set; }
    }
}