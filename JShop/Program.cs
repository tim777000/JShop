using System;
using JShop.Controllers;

namespace JShop
{
    class Program
    {
        static (string, string[]) GetCmd()
        {
            string line;
            line = Console.ReadLine().Trim();
            string[] lineSplit = line.Split(null, 2);
            if (lineSplit.Length != 2)
            {
                return (null, null);
            }
            string cmd = lineSplit[0];
            string[] data = lineSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries&StringSplitOptions.TrimEntries);
            data[0] = data[0].ToLower();
            return (cmd, data);
        }

        static void Main(string[] args)
        {
            ActionController actionController = new ActionController();
            while (true)
            {
                (string cmd, string[] data) = GetCmd();
                if (cmd == null || data == null)
                {
                    continue;
                }
                Console.WriteLine(actionController.Actions(cmd, data));
            }
        }

    }
}