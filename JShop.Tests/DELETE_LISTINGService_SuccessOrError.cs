using System;
using Xunit;
using JShop.Data;
using JShop.Actions;
using JShop.Controllers;

namespace JShop.Tests
{
    public class DELETE_LISTINGService_SuccessOrError
    {
        [Fact]
        public void Test1()
        {
            ActionController actionController = new ActionController();
            string[] listing1 = "user1 \'Phone model 8\' \'Black color, brand new\' 1000 \'Electronics\'".Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            string[] listing2 = "user1 \'Black shoes\' \'Training shoes\' 100 \'Sports\'".Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal("Success", actionController.Actions("REGISTER", new string[] { "user1" }));
            Assert.Equal("Success", actionController.Actions("REGISTER", new string[] { "user2" }));
            Assert.Equal("Error - user already existing", actionController.Actions("REGISTER", new string[] { "user1" }));
            Assert.Equal("1", actionController.Actions("CREATE_LISTING", listing1));
            Assert.Equal("2", actionController.Actions("CREATE_LISTING", listing2));
            Assert.Equal("Success", actionController.Actions("DELETE_LISTING", new string[] { "user1", "2" }));
            Assert.Equal("Error - listing does not exist", actionController.Actions("DELETE_LISTING", new string[] { "user1", "5" }));
            Assert.Equal("Error - listing owner mismatch", actionController.Actions("DELETE_LISTING", new string[] { "user2", "1" }));
        }
    }
}
