using System;
namespace JShop.Data
{
    public interface DB
    {
        public bool Check(string data);
        public string Create(string[] data);
        public string[] Get(string[] data);
        public string Delete(string[] data);
    }
}
