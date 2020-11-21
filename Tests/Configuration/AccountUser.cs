using System;
using System.ComponentModel.DataAnnotations;

namespace Tests.Configuration
{
    public class AccountUser
    {
        [Key]
        public Guid AccountUserId { get; set; }
        public Guid AccountId { get; set; }
    }
}