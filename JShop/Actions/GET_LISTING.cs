using System;
using JShop.Data;

namespace JShop.Actions
{
    public class GET_LISTING : IAction
    {
        private DB _listingDB;
        private string[] resultArray;
        private string result;
        public string Execute(DB db, string[] data)
        {
            if (data.Length != 2)
            {
                return "Usage: GET_LISTING [Username] [Listing ID]";
            }
            _listingDB = db;
            resultArray = _listingDB.Get(data);
            result = String.Join('|', resultArray);
            return result;
        }
    }
}
