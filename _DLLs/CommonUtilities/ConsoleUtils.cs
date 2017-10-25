
using System;

namespace CommonUtils
{
    /// <summary>
    /// Utilities for use in Console applications.
    /// </summary>
    /// <includes>
    /// isAltPressed, bool
    /// isCtrlPressed, bool
    /// isShiftPressed, bool
    /// PrintAtXY, void
    /// ReadInt, int
    ///
    /// </includes>
    public static class ConsoleUtils
    {
        /// <summary>
        /// Get Alt key.
        /// </summary>
        /// <param name="cki">ConsoleKeyInfo</param>
        /// <returns>True if pressed.</returns>
        public static bool isAltPressed(this ConsoleKeyInfo cki) =>
            (cki.Modifiers & ConsoleModifiers.Alt) != 0;



        /// <summary>
        /// Get Ctrl key.
        /// </summary>
        /// <param name="cki">ConsoleKeyInfo</param>
        /// <returns>True if pressed.</returns>
        public static bool isCtrlPressed(this ConsoleKeyInfo cki) =>
            (cki.Modifiers & ConsoleModifiers.Control) != 0;



        /// <summary>
        /// Get Shift key.
        /// </summary>
        /// <param name="cki">ConsoleKeyInfo</param>
        /// <returns>True if pressed.</returns>
        public static bool isShiftPressed(this ConsoleKeyInfo cki) =>
            (cki.Modifiers & ConsoleModifiers.Shift) != 0;



        /// <summary>
        /// Sets the cursor position and prints to the Console.
        /// </summary>
        /// <param name="x">X: [0:Console.WindowWidth-1]</param>
        /// <param name="y">Y: [0:Console.WindowHeight-1]</param>
        /// <param name="c">Char to print.</param>
        /// <param name="color">ForegroundColor</param>
        public static void PrintAtXY(
            int x, int y, char? c = null,
            ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }



        /// <summary>
        /// Sets the cursor position and prints to the Console.
        /// </summary>
        /// <param name="x">X: [0:Console.WindowWidth-1]</param>
        /// <param name="y">Y: [0:Console.WindowHeight-1]</param>
        /// <param name="strText">String to print.</param>
        /// <param name="color">ForegroundColor</param>
        public static void PrintAtXY(
            int x, int y, string strText = "",
            ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(strText);
        }



        /// <summary>
        /// Reads an int from the Console.
        /// </summary>
        /// <param name="aVar">int variable</param>
        /// <param name="prompt">Prompt text.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <param name="cls">Clear Screen flag.</param>
        /// <returns></returns>
        public static int ReadInt(
            this int aVar, string prompt = "Enter integer: ",
            int min = int.MinValue, int max = int.MaxValue,
            bool cls = false)
        {
            int input;
            do
            {
                if (cls) Console.Clear();
                Console.Write(prompt);
            }
            while
            (!(int.TryParse(Console.ReadLine(), out input) &&
                min <= input && input <= max));

            return input;
        }



        /// <summary>
        /// Reads a 'double' from the Console.
        /// </summary>
        /// <param name="aVar">double variable</param>
        /// <param name="prompt">Prompt text.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <param name="cls">Clear Screen flag.</param>
        /// <returns></returns>
        public static double ReadDouble(
            this double aVar, string prompt = "Enter a 'double': ",
            double min = double.MinValue, double max = double.MaxValue,
            bool cls = false)
        {
            double input;
            do
            {
                if (cls) Console.Clear();
                Console.Write(prompt);
            }
            while
            (!(double.TryParse(Console.ReadLine(), out input) &&
                min <= input && input <= max));

            return input;
        }
    }
}