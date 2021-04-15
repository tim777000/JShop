using System;

namespace JShop.Models
{
    public class Listing
    {
        private static int _counter;
        private static int Counter()
        {
            _counter++;
            return _counter;
        }

        public Listing(string[] args)
        {
            _userName = args[0];
            _title = args[1];
            _description = args[2];
            _price = Int32.Parse(args[3]);
            _category = args[4];
            _listingId = Counter();
            _createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string _userName;
        private string _title;
        private string _description;
        private int _price;
        private string _category;
        private int _listingId;
        private string _createTime;

        public string GetName()
        {
            return _userName;
        }
        public string GetTitle()
        {
            return _title;
        }
        public string GetDescription()
        {
            return _description;
        }
        public int GetPrice()
        {
            return _price;
        }
        public string GetCategory()
        {
            return _category;
        }
        public int GetListingId()
        {
            return _listingId;
        }
        public string GetCreateTime()
        {
            return _createTime;
        }
        public string[] GetListingData()
        {
            return new string[] { _title, _description, _price.ToString(), _createTime, _category, _userName };
        }
    }
}
