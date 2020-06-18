using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Dtos
{
    public class UserProfileDto
    {
        public int id { get; set; }

        public int locationId { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public ToolkitInfoDto toolkitInfo { get; set; }
    }
}
