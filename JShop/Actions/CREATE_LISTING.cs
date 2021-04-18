using System;
using JShop.Data;

namespace JShop.Actions
{
    public class CREATE_LISTING : IAction
    {
        private DB _listingDB;
        private string result;
        public string Execute(DB db, string[] data)
        {
            data = String.Join(' ', data).Split('\'', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (data.Length != 5)
            {
                return "Usage: CREATE_LISTING [Username] [Title] [Description] [Price] [Category]";
            }
            _listingDB = db;
            result = _listingDB.Create(data);
            return result;
        }
    }
}
