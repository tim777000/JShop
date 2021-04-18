using System;
using JShop.Data;

namespace JShop.Actions
{
    public class GET_CATEGORY : IAction
    {
        private DB _listingDB;
        private string[] resultArray;
        private string result;
        public string Execute(DB db, string[] data)
        {
            if (data.Length != 4)
            {
                return "Usage: GET_CATEGORY [Username] [Category] [sort_time|sort_price] [asc|dsc]";
            }
            data[1] = data[1].Trim('\'');
            _listingDB = db;
            resultArray = _listingDB.Get(data);
            result = String.Join('\n', resultArray);
            return result;
        }
    }
}
