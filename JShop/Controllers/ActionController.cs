using System;
using JShop.Data;
using JShop.Actions;

namespace JShop.Controllers
{
    public class ActionController
    {
        private UserDB _userDB = UserDB.SingletonDB;
        private ListingDB _listingDB = ListingDB.SingletonDB;
        private IAction action;
        private string result = "";
        public string Actions(string cmd, string[] data)
        {
            if(cmd.Equals("REGISTER"))
            {
                action = new REGISTER();
                result = action.Execute(_userDB, data);
                return result;
            }
            else if(cmd.Equals("CREATE_LISTING"))
            {
                action = new CREATE_LISTING();
                result = action.Execute(_listingDB, data);
                return result;
            }
            return result;
        }
    }
}
