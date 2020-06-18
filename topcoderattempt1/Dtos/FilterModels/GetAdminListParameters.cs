using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Dtos
{
    public class GetAdminListParameters
    {
        public bool onlyToolKitUser { get; set; } = false;
        public int id { get; set; } 
        public string name { get; set; }
        public string email { get; set; }
        public int state { get; set; }
        public int statusId { get; set; }
        public int skips { get; set; } = 0;
        public int takes { get; set; } = 10;
        public string orderBy { get; set; }
        public string orderDirection { get; set; }

    }
}
