using System;
using JShop.Data;

namespace JShop.Actions
{
    public class DELETE_LISTING : IAction
    {
        private DB _listingDB;
        private string result;
        public string Execute(DB db, string[] data)
        {
            if (data.Length != 2)
            {
                return "Usage: DELETE_LISTING [Username] [Listing ID]";
            }
            _listingDB = db;
            result = _listingDB.Delete(data);
            return result;
        }
    }
}
