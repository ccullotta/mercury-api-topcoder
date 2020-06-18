using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Backend;

namespace topcoderattempt1.Models
{
    //int size is determined on model creat
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [EmailUnique]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        // TODO: [DataType(DataType.Password)]  
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(200)]
        public string SecurityQuestion { get; set; }

        [Required]
        [MaxLength(200)]
        public string SecurityQuestionAnswer { get; set; }

        [MaxLength(45)]
        [AllowNull]
#nullable enable
#nullable enable
        public string? VerificationToken { get; set; }
        //TODO: hope this works 
        public DateTime? VerificationTokenExpiry { get; set; }

        public bool? IsEmailVerified { get; set; }

        public bool? IsTemporaryPassword { get; set; }

        public int? LastUpdateBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.DateTime)]
        public DateTime? LastUpdatedOn { get; set; }

        public List<UserLocation>? UserLocations { get; set; }
        public List<ChangeEmailRequest>? ChangeEmailRequests { get; set; }

        public ICollection<UserKeyMapping>? UserKeyMappings { get; set; }

        public ICollection<UserActivity> UserActivities { get; set; }

        public int User_id
        {
            get
            {
                return UserID;
            }
        }
    }
}
