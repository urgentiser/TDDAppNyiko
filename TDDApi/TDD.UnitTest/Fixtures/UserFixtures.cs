using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDApi.Models;

namespace TDD.UnitTest.Fixtures
{
    public static class UserFixtures
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name ="Test User 1",
                    Email ="test@testing.co.za",
                    Address = new Address
                    {
                        Street = "123 Main Street",
                        City = "White CIty",
                        ZipCode ="1618",
                    }
                },
                new User
                {
                    Name ="Test User 2",
                    Email ="nick@testing.co.za",
                    Address = new Address
                    {
                        Street = "16 Left Street",
                        City = "White CIty",
                        ZipCode ="1618",
                    }
                },
            };
    }
}
