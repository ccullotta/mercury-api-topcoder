using System;
using System.ComponentModel.DataAnnotations;

namespace topcoderattempt1.Dtos
{
    public class UserActivityCompactDto
    {
        public int id { get; set; }
        [MaxLength(250)]
        public string activityText { get; set; }
        public string activityTime { get; set; }
    }
}