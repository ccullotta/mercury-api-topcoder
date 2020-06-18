using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using topcoderattempt1.Models;

namespace topcoderattempt1.Dtos
{
    public class AdminListByLocationDto
    {
        public int totalItems { get; set; }

        public List<AdminListItem> items { get; set; }
    }
    public class AdminListItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string disabledReason { get; set; }

        public Dictionary<string, string> status { get; set; }
        public ToolkitInfoDto toolkitInfo { get; set; }

        public UserPermissionCompactDto permissions { get; set; }

        public UserActivityCompactDto recentActivity { get; set; }

    }
}
