using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using topcoderattempt1.Dtos;
using topcoderattempt1.Profiles;

namespace topcoderattempt1.Models
{
    public class UserPermissionCompactDto
    {
        public bool? HasAdminRead { get; set; }
        public bool? HasAdminEdit { get; set; }
        public bool? HasKeyholderRead { get; set; }
        public bool? HasKeyholderEdit { get; set; }
        public bool? HasDeviceRead { get; set; }
        public bool? HasDeviceEdit { get; set; }
        public bool? HasSpaceRead { get; set; }
        public bool? HasSpaceEdit { get; set; }
        public bool? HasConfigRead { get; set; }
        public bool? HasConfigEdit { get; set; }
    }
    public class UserPermission : UserPermissionCompactDto
    {
        public int ID { get; set; }
        public int UserLocationID { get; set; }


        public int LastUpdateBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public UserLocation UserLocation { get; set; }

        public bool IsEqualToReadDto(UserPermissionReadDto dto)
        {
            if (dto == null)
            {
                return false;
            }
            return dto.HasAdminEdit == HasAdminEdit && dto.HasAdminRead == HasAdminRead &&
                dto.HasConfigEdit == HasConfigEdit && dto.HasConfigRead == HasConfigRead &&
                dto.HasDeviceEdit == HasDeviceEdit && dto.HasDeviceRead == HasDeviceRead &&
                dto.HasKeyholderEdit == HasKeyholderEdit && dto.HasKeyholderRead == HasKeyholderRead &&
                dto.HasSpaceEdit == HasSpaceEdit && dto.HasSpaceRead == HasSpaceRead &&
                dto.locationId == UserLocationID;
        }

    }
}
