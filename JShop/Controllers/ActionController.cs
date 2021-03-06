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
        private string result = "Wrong Usage! See Manual!";
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
            else if(cmd.Equals("DELETE_LISTING"))
            {
                action = new DELETE_LISTING();
                result = action.Execute(_listingDB, data);
                return result;
            }
            else if(cmd.Equals("GET_LISTING"))
            {
                action = new GET_LISTING();
                result = action.Execute(_listingDB, data);
                return result;
            }
            else if(cmd.Equals("GET_CATEGORY"))
            {
                action = new GET_CATEGORY();
                result = action.Execute(_listingDB, data);
                return result;
            }
            else if (cmd.Equals("GET_TOP_CATEGORY"))
            {
                action = new GET_TOP_CATEGORY();
                result = action.Execute(_listingDB, data);
                return result;
            }
            action = null;
            result = "Wrong Usage! See Manual!";
            return result;
        }
    }
}
