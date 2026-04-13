using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public static class UIHelper
    {
        public static void WriteColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void WriteLineColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void TypeEffect(string message, int delayMs = 30)
        {
            // Clear the current line first to prevent leftover characters
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;

            // Write spaces to clear the line
            Console.Write(new string(' ', Console.WindowWidth - currentLeft - 1));

            // Go back to original position
            Console.SetCursorPosition(currentLeft, currentTop);

            // Type out the message character by character
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }

            // Clear any remaining characters after the message
            int remaining = Console.WindowWidth - Console.CursorLeft - 1;
            if (remaining > 0)
            {
                Console.Write(new string(' ', remaining));
            }

            Console.WriteLine();
        }

        public static void PrintBorder()
        {
            WriteLineColor(new string('═', 60), ConsoleColor.Cyan);
        }

        public static void PrintHeader(string title)
        {
            PrintBorder();
            WriteLineColor($"  {title}", ConsoleColor.Yellow);
            PrintBorder();
        }
    }
}