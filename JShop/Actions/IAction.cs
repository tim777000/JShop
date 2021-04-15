using System;
using JShop.Data;

namespace JShop.Actions
{
    public interface IAction
    {
        public string Execute(DB db, string[] data);
    }
}
