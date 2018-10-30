using System;

namespace _1_TodoConsoleApp
{
    public static class ConsoleEx
    {
        public static void Write(string text, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Write(text);
            //Console.ResetColor;
        }
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(text);
        }
    }

}
