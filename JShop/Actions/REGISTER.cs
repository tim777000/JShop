using System;
using JShop.Data;

namespace JShop.Actions
{
    public class REGISTER : IAction
    {
        private DB _userDB;
        private string result;
        public string Execute(DB db, string[] data)
        {
            if (data.Length != 1)
            {
                return "Usage: REGISTER [Username]";
            }
            _userDB = db;
            result = _userDB.Create(data);
            return result;
        }
    }
}
