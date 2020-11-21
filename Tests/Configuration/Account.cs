using System;
using System.ComponentModel.DataAnnotations;

namespace Tests.Configuration
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
    }
}