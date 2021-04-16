using System;
using System.Collections.Generic;
using System.Linq;
using JShop.Models;

namespace JShop.Data
{
    public class ListingDB : DB
    {
        private static ListingDB _listingDB;
        private ListingDB()
        {
        }

        public static ListingDB SingletonDB
        {
            get
            {
                if (_listingDB == null)
                {
                    _listingDB = new ListingDB();
                }
                return _listingDB;
            }
        }

        private Dictionary<int, Listing> _listings = new Dictionary<int, Listing>();
        private UserDB _userDB = UserDB.SingletonDB;
        private CategoryDB _categoryDB = CategoryDB.SingletonDB;

        public bool Check(string username)
        {
            return _userDB.Check(username);
        }

        public bool Check(int listingid)
        {
            return _listings.ContainsKey(listingid);
        }

        public bool Check(int listingid, string username)
        {
            return username.Equals(_listings[listingid].GetName());
        }

        public string Create(string[] data)
        {
            data = String.Join(' ', data).Split('\'', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);
            string user = data[0];
            if (data.Length != 5)
            {
                return "Usage: CREATE_LISTING [Username] [Title] [Description] [Price] [Category]";
            }
            else if (!Check(user))
            {
                return "Error - unknown user";
            }
            else
            {
                Listing listing = new Listing(data);
                int listingid = listing.GetListingId();
                _listings.Add(listingid, listing);
                _categoryDB.Create(listing.GetCategory(), listingid);
                return listingid.ToString();
            }
        }

        public string[] Get(string[] data)
        {
            if (data.Length == 4)
            {
                if (data[2].Equals("sort_time") || data[2].Equals("sort_price"))
                {
                    return GetCategory(data);
                }
                else
                {
                    return new string[] { "Usage: GET_CATEGORY [Username] [Category] [sort_time|sort_price] [asc|dsc]" };
                }
            }
            string user = data[0];
            int listingID = Int32.Parse(data[1]);
            if (data.Length != 2)
            {
                return new string[] { "Usage: GET_LISTING [Username] [Listing ID]" };
            }
            else if (!Check(listingID))
            {
                return new string[] { "Error - not found" };
            }
            else if (!Check(user))
            {
                return new string[] { "Error - unknown user" };
            }
            else
            {
                Listing listing = _listings[listingID];
                string[] result = listing.GetListingData();
                return result;
            }
        }

        public string Delete(string[] data)
        {
            string user = data[0];
            int listingID = Int32.Parse(data[1]);
            if (data.Length != 2)
            {
                return "Usage: DELETE_LISTING [Username] [Listing ID]";
            }
            else if (!Check(listingID))
            {
                return "Error - listing does not exist";
            }
            else if (!Check(listingID, user))
            {
                return "Error - listing owner mismatch";
            }
            else
            {
                _categoryDB.Delete(_listings[listingID].GetCategory(), listingID);
                _listings.Remove(listingID);
                return "Success";
            }
        }

        public string[] GetCategory(string[] data)
        {
            string[] resultID;
            string user = data[0];
            string category = data[1].Trim('\'');
            List<Listing> resultListing = new List<Listing>();
            List<string> resultArray = new List<string>();
            if (!Check(user))
            {
                return new string[] { "Error - unknown user" };
            }
            else
            {
                resultID = _categoryDB.Get(new string[] { category });
                if(resultID[0].Equals("Error - category not found"))
                {
                    return new string[] { "Error - category not found" };
                }
                foreach (string s in resultID)
                {
                    resultListing.Add(_listings[Int32.Parse(s)]);
                }
                string sortingBase = data[2];
                string sortingWay = data[3];
                if(sortingBase.Equals("sort_price"))
                {
                    if(sortingWay.Equals("asc"))
                    {
                        resultListing = resultListing.OrderBy(l => l.GetPrice()).ToList();
                    }
                    else
                    {
                        resultListing = resultListing.OrderByDescending(l => l.GetPrice()).ToList();
                    }
                }
                else
                {
                    if (sortingWay.Equals("asc"))
                    {
                        resultListing = resultListing.OrderBy(l => DateTime.ParseExact(l.GetCreateTime(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture)).ToList();
                    }
                    else
                    {
                        resultListing = resultListing.OrderByDescending(l => DateTime.ParseExact(l.GetCreateTime(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture)).ToList();
                    }
                }
                foreach(Listing l in resultListing)
                {
                    resultArray.Add(String.Join('|', l.GetListingData()));
                }
                string[] result = resultArray.ToArray();
                return result;
            }
        }
    }
}
