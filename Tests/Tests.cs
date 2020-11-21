using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Tests.Configuration;
using TestingContext = Tests.Configuration.TestContext;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public async Task Setup()
        {
            await using var testContext = new TestingContext();
            var account = new Account
            {
                AccountId = Guid.NewGuid()
            };
            await testContext.AddRangeAsync(account);
            await testContext.SaveChangesAsync();
        }

        [Test]
        public async Task LeftJoinWithCondition()
        {
            await using var testContext = new TestingContext();
            var query = from account in testContext.Accounts
                join accountUser in testContext.AccountUsers
                    on account.AccountId equals accountUser.AccountId into accountUsers
                from accountUser in accountUsers.DefaultIfEmpty()
                join accountUserDevice in testContext.AccountUserDevices
                    on new {accountUser.AccountUserId} equals new {accountUserDevice.AccountUserId} into accountUserDevices
                from accountUserDevice in accountUserDevices.DefaultIfEmpty()
                select new
                {
                    account.AccountId,
                    accountUserDevice.Name
                };

            var queryResult = await query.ToArrayAsync();
            
            Assert.AreEqual(1, queryResult.Length);
        }
    }
}