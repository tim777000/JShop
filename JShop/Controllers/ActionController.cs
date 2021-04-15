using System;
using JShop.Data;
using JShop.Actions;

namespace JShop.Controllers
{
    public class ActionController
    {
        private UserDB _userDB = UserDB.SingletonDB;
        private string result = "";
        public string Actions(string cmd, string[] data)
        {
            if(cmd.Equals("REGISTER"))
            {
                IAction action = new REGISTER();
                result = action.Execute(_userDB, data);
                return result;
            }
            return result;
        }
    }
}
