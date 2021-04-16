﻿using System;
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
            _listingDB = db;
            resultArray = _listingDB.Get(data);
            result = String.Join('\n', resultArray);
            return result;
        }
    }
}
