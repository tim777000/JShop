using System;
using System.Collections.Generic;
using JShop.Models;

namespace JShop.Data
{
    public class CategoryDB : DB
    {
        private static CategoryDB _categoryDB;
        private CategoryDB()
        {
        }

        public static CategoryDB SingletonDB
        {
            get
            {
                if (_categoryDB == null)
                {
                    _categoryDB = new CategoryDB();
                }
                return _categoryDB;
            }
        }

        private Dictionary<string, List<Listing>> _categories = new Dictionary<string, List<Listing>>();
        public bool Check(string data)
        {
            return _categories.ContainsKey(data);
        }
        public string Create(string[] data)
        {
            string category = data[4];
            if(Check(category))
            {
                _categories[category].Add(new Listing(data));
                return "Successfully Appended";
            }
            else
            {
                _categories.Add(category, new List<Listing>());
                _categories[category].Add(new Listing(data));
                return "Successfully Added New Category and Appended";
            }
        }
        public string Get(string[] data)
        {
            return "";
        }
        public string Delete(string[] data)
        {
            return "";
        }
    }
}
