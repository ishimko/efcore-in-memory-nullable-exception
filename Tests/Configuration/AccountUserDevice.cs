using System;
using System.ComponentModel.DataAnnotations;

namespace Tests.Configuration
{
    public class AccountUserDevice
    {
        [Key]
        public Guid AccountUserDeviceId { get; set; }

        public Guid AccountUserId { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}