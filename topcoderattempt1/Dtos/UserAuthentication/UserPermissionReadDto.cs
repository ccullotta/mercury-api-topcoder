namespace topcoderattempt1.Dtos
{
    public class UserPermissionReadDto
    {
        public int locationId { get; set; }

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
}