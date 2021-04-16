using System;
using System.Collections.Generic;
using System.Linq;
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

        private Dictionary<string, List<int>> _categories = new Dictionary<string, List<int>>();

        public bool Check(string data)
        {
            return _categories.ContainsKey(data);
        }
        public string Create(string[] data)
        {
            return "To Be Continued...";
        }
        public string Delete(string[] data)
        {
            return "To Be Continued...";
        }
        public string Create(string data, int id)
        {
            string category = data;
            int listingid = id;
            if (Check(category))
            {
                _categories[category].Add(listingid);
                return "Successfully Appended";
            }
            else
            {
                _categories.Add(category, new List<int>());
                _categories[category].Add(listingid);
                return "Successfully Added New Category and Appended";
            }
        }
        public string[] Get(string[] data)
        {
            string category = data[0];
            if (!Check(category))
            {
                return new string[] { "Error - category not found" };
            }
            else
            {
                string[] result = _categories[category].Select(i => i.ToString()).ToArray();
                return result;
            }
        }
        public string Delete(string data, int id)
        {
            string category = data;
            int listingid = id;
            _categories[category].RemoveAt(_categories[category].FindIndex(i => i == listingid));
            return "Successfully Deleted";
        }
    }
}
