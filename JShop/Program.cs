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
            line = lineSplit[0];
            lineSplit = lineSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return (line, lineSplit);
        }

        static void Main(string[] args)
        {
            ActionController actionController = new ActionController();
            while (true)
            {
                (string cmd, string[] data) = GetCmd();
                Console.WriteLine(actionController.Actions(cmd, data));
            }
        }

    }
}