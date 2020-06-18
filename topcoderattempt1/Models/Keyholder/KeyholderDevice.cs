using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace topcoderattempt1.Models
{
    public class KeyholderDevice
    {
        public int ID { get; set; }
        public int KeyholderId { get; set; }
        public int DeviceId { get; set; }
        public int KeyDevicePermissionId { get; set; }
        public int? Type { get; set; }
        public int? SpaceId { get; set; }

    }
}
