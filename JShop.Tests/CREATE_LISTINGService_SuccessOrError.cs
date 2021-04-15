using System;
using Xunit;
using JShop.Data;
using JShop.Actions;
using JShop.Controllers;

namespace JShop.Tests
{
    public class CREATE_LISTINGService_SuccessOrError
    {
        private UserDB _userDB = UserDB.SingletonDB;

        [Fact]
        public void Test1()
        {
            ActionController actionController = new ActionController();
            //Assert.Equal("Success", actionController.Actions("REGISTER", new string[] { "user1" }));
            Assert.Equal("1", actionController.Actions("CREATE_LISTING", new string[] { "user1", "\'Phone", "model", "8\'", "\'Black", "color,", "brand", "new\'", "1000", "\'Electronics\'" }));
            Assert.Equal("2", actionController.Actions("CREATE_LISTING", new string[] { "user1", "\'Black", "shoes\'", "\'Training", "shoes\'", "100", "\'Sports\'"}));
        }
    }
}
