using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosPreview
{
    class Helper
    {
        public static void PrintBlock(string str)
        {
            Console.WriteLine("-----------------------\r\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(str + "\r\n");
            Console.ResetColor();
            Console.WriteLine("-----------------------\r\n");
        }
    }
}
