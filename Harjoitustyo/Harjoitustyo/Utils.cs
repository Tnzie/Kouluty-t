using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitustyo
{
    public static class Utils
    {
        //makes player to press a key to continue
        public static void ActionBreak(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }
        
        //easier/better ways to change colors on strings, than regular way
        public static void SayLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

        public static void Say(string message, ConsoleColor color) 
        { 
            Console.ForegroundColor = color;
            Console.Write(message);
        }
    }
}
