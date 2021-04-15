using System;
using Xunit;
using JShop.Data;
using JShop.Actions;
using JShop.Controllers;

namespace JShop.Tests
{
    public class REGISTERService_SuccessOrError
    {
        private UserDB _userDB = UserDB.SingletonDB;

        [Fact]
        public void Test1()
        {
            ActionController actionController = new ActionController();
            Assert.Equal("Success", actionController.Actions("REGISTER", new string[] { "user1" }));
            Assert.Equal("Error - user already existing", actionController.Actions("REGISTER", new string[] { "user1" }));
        }
    }
}
