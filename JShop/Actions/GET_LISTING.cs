using System;
using JShop.Data;

namespace JShop.Actions
{
    public class GET_LISTING : IAction
    {
        private DB _listingDB;
        private string result;
        public string Execute(DB db, string[] data)
        {
            _listingDB = db;
            result = _listingDB.Get(data);
            return result;
        }
    }
}
