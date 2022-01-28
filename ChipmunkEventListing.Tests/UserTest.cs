using ChipmunkEventListing.Models;
using System;
using Xunit;

namespace ChipmunkEventListing.Tests
{
    public class UserTest
    {
        [Fact]
        public void UserShouldBeEmpty()
        {
            User user = new User { Username = "Username1", Email = "Email", Password = "password", UserCreated = DateTime.Now };

            Assert.Equal(user.Username, "Username1");

        }
    }
}
