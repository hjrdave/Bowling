using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n  Welcome to TERMINAL BOWLING");
            Console.WriteLine("\n  A simple C# Bowling Game");
            Console.WriteLine("  Created by David A. Sanders");
            Game.Start();
            Console.ReadKey(true);
        }
    }
}
