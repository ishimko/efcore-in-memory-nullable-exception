using Microsoft.EntityFrameworkCore;

namespace Tests.Configuration
{
    public class TestContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<AccountUserDevice> AccountUserDevices { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("database");
        }
    }
}