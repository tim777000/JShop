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
            _catagory = args[4];
            _listingId = Counter();
            _createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private string _userName;
        private string _title;
        private string _description;
        private int _price;
        private string _catagory;
        private int _listingId;
        private string _createTime;
    }
}
