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
            else if(!Check(user))
            {
                return "Error - unknown user";
            }
            else
            {
                Listing listing = new Listing(data);
                int listingid = listing.GetListingId();
                _listings.Add(listingid, listing);
                return listingid.ToString();
            }
        }

        public string Get(string[] data)
        {
            return "";
        }

        public string Delete(string[] data)
        {
            string user = data[0];
            int listingID = Int32.Parse(data[1]);
            if(data.Length != 2)
            {
                return "Usage: DELETE_LISTING [Username] [Listing ID]";
            }
            else if(!Check(listingID))
            {
                return "Error - listing does not exist";
            }
            else if(!Check(listingID, user))
            {
                return "Error - listing owner mismatch";
            }
            else
            {
                _listings.Remove(listingID);
                return "Success";
            }
        }
    }
}
