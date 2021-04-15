using System;
using System.Collections.Generic;
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

        public bool Check(string data)
        {
            return _userDB.Check(data);
        }

        public string Create(string[] data)
        {
            data = String.Join(' ', data).Split('\'', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);
            string user = data[0];
            if (data.Length != 5)
            {
                return "Usage: CREATE_LISTING [Username] [Title] [Description] [Price] [Category]";
            }
            else if(!Check(user))
            {
                return "Error - unknown user";
            }
            else
            {
                Listing listing = new Listing(data);
                int listingid = listing.GetListingId();
                _listings.Add(listingid, listing);
                foreach(string s in listing.GetListingData())
                    Console.WriteLine(s);
                return listingid.ToString();
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
