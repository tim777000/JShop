using System;
using System.Collections.Generic;
using JShop.Models;

namespace JShop.Data
{
    public class UserDB : DB
    {
        private static UserDB _userDB;
        private UserDB()
        {
        }

        public static UserDB SingletonDB
        {
            get
            {
                if(_userDB == null)
                {
                    _userDB = new UserDB();
                }
                return _userDB;
            }
        }

        private Dictionary<string, User> _users = new Dictionary<string, User>();

        public bool Check(string data)
        {
            return _users.ContainsKey(data);
        }

        public string Create(string[] data)
        {
            string user = data[0];
            if(!Check(user))
            {
                _users.Add(user, new User(user));
                return "Success";
            }
            else
            {
                return "Error - user already existing";
            }
        }
        public string[] Get(string[] data)
        {
            return new string[] { "To Be Continued..." };
        }
        public string Delete(string[] data)
        {
            return "To Be Continued...";
        }
    }
}
