using System;
//
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CommonUtils
{
    /// <summary>
    /// Utilities for the Console window.
    /// </summary>
    /// <includes>
    /// Maximize, void 
    /// Position, void 
    /// WindowPstn, void 
    /// WindowSize, void 
    /// BufferSize, void 
    /// ShowWindowAndBufferInfo, void 
    /// RemoveScrollBars, void 
    /// WPAS (WindowPositionAndSize), void 
    /// 
    /// </includes>
    public static class ConsoleWindow
    {
        #region This code can Maximize the Console window
        // requires using System.Runtime.InteropServices;
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        public static void Maximize()
        {
            // requires using System.Diagnostics;
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
        #endregion This code can Maximize the Console window


        #region Sets the position of the Console Window in a Console Application

        const int SWP_NOSIZE = 0x0001;

        public static void Position(int xpos, int ypos)
        {
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
        }

        // requires using System.Runtime.InteropServices;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        internal static IntPtr MyConsole = GetConsoleWindow();

        // requires using System.Runtime.InteropServices;
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern IntPtr SetWindowPos(
            IntPtr hWnd, int hWndInsertAfter,
            int x, int Y, int cx, int cy, int wFlags);


        #endregion Sets the position of the Console Window in a Console Application


        #region This sets the position of the Console Window in a WinForm Application

        ////const int SWP_NOSIZE = 0x0001;

        ////[System.Runtime.InteropServices.DllImport("kernel32.dll")]
        ////private static extern bool AllocConsole();

        ////[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        ////public static extern IntPtr SetWindowPos(
        ////    IntPtr hWnd, int hWndInsertAfter, 
        ////    int x, int Y, int cx, int cy, int wFlags);

        ////[DllImport("kernel32.dll", SetLastError = true)]
        ////public static extern IntPtr GetConsoleWindow();

        ////[STAThread]
        ////static void Main()
        ////{
        ////    AllocConsole();
        ////    IntPtr MyConsole = GetConsoleWindow();
        ////    int xpos = 1024;
        ////    int ypos = 0;
        ////    SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
        ////    Console.WindowLeft = 0;
        ////    Console.WriteLine("text in my console");

        ////    Application.EnableVisualStyles();
        ////    Application.SetCompatibleTextRenderingDefault(false);
        ////    Application.Run(new Form1());
        //}
        #endregion



        /// <summary>
        /// Console window position on screen.
        /// </summary>
        /// <param name="Restore">
        /// False: Store position to temp X and Y variables.
        /// True: Restore the original window position.
        /// </param>
        /// <param name="tmpWindowX">Temp X variable.</param>
        /// <param name="tmpWindowY">Temp Y variable.</param>
        public static void WindowPstn(
            bool Restore, ref int tmpWindowX, ref int tmpWindowY)
        {
            if (Restore)
            {
                Console.WindowLeft = tmpWindowX;
                Console.WindowTop = tmpWindowY;
            }
            else
            {
                tmpWindowX = Console.WindowLeft;
                tmpWindowY = Console.WindowTop;
            }
        }

        /// <summary>
        /// Console window size on screen.
        /// </summary>
        /// <param name="Restore">
        /// False: Store size to temp H and W variables.
        /// True: Restore the original window size.
        /// </param>
        /// <param name="tmpWindowH">Temp H variable.</param>
        /// <param name="tmpWindowW">Temp W variable.</param>
        public static void WindowSize(
            bool Restore, ref int tmpWindowH, ref int tmpWindowW)
        {
            if (Restore)
            {
                Console.WindowHeight = tmpWindowH;
                Console.WindowWidth = tmpWindowW;
            }
            else
            {
                tmpWindowH = Console.WindowHeight;
                tmpWindowW = Console.WindowWidth;
            }
        }

        /// <summary>
        /// Console buffer size.
        /// </summary>
        /// <param name="Restore">
        /// False: Store size to temp H and W variables.
        /// True: Restore the original buffer size.
        /// </param>
        /// <param name="tmpBufferH">Temp H variable.</param>
        /// <param name="tmpBufferW">Temp W variable.</param>
        public static void BufferSize(
            bool Restore, ref int tmpBufferH, ref int tmpBufferW)
        {
            if (Restore)
            {
                Console.BufferHeight = tmpBufferH;
                Console.BufferWidth = tmpBufferW;
            }
            else
            {
                tmpBufferH = Console.BufferHeight;
                tmpBufferW = Console.BufferWidth;
            }
        }

        /// <summary>
        /// Print the Console window (and buffer) position and size.
        /// </summary>
        /// <param name="showBufferSize">
        /// True: show Buffer Height and Width
        /// </param>
        /// <param name="BufferH">Buffer height</param>
        /// <param name="BufferW">Buffer width</param>
        public static void ShowWindowAndBufferInfo(
            bool showBufferSize = false, int BufferH = 0, int BufferW = 0)
        {
            Console.WriteLine(
                " Window X = {0}\t H = {1}",
                Console.WindowLeft,
                Console.WindowHeight);
            Console.WriteLine(
                " Window Y = {0}\t W = {1}",
                Console.WindowTop,
                Console.WindowWidth);
            Console.WriteLine();

            if (showBufferSize)
            {
                Console.WriteLine(
                    " Buffer H = {0}\t Original H = {1}",
                    Console.BufferHeight, BufferH);
                Console.WriteLine(
                    " Buffer W = {0}\t Original W = {1}",
                    Console.BufferWidth, BufferW);
            }
        }

        /// <summary>
        /// Sets Console buffer size to the window size.
        /// </summary>
        public static void RemoveScrollBars()
        {
            // max BufferHeight & BufferWidth is short.MaxValue-1;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        /// <summary>
        /// Set Console window position and size
        /// </summary>
        /// <param name="tmpWindowX">Temp X variable</param>
        /// <param name="tmpWindowY">Temp Y variable</param>
        /// <param name="tmpWindowH">Temp H variable</param>
        /// <param name="tmpWindowW">Temp W variable</param>
        /// <param name="tmpBufferH">Temp buffer H variable</param>
        /// <param name="tmpBufferW">Temp buffer W variable</param>
        /// <param name="setWindowX">Left</param>
        /// <param name="setWindowY">Top</param>
        /// <param name="setWindowW">Width</param>
        /// <param name="setWindowH">Height</param>
        /// <param name="flagMaximize">
        /// True: Maximize Console window.
        /// </param>
        public static void WPAS(
            ref int tmpWindowX, ref int tmpWindowY,
            ref int tmpWindowH, ref int tmpWindowW,
            ref int tmpBufferH, ref int tmpBufferW,
            int setWindowX, int setWindowY,
            int setWindowW, int setWindowH,
            bool flagMaximize = false)
        {
            WindowPstn(false, ref tmpWindowX, ref tmpWindowY);
            WindowSize(false, ref tmpWindowH, ref tmpWindowW);
            BufferSize(false, ref tmpBufferH, ref tmpBufferW);

            // Position the Console window on the screen
            Position(setWindowX, setWindowY);

            // Size the Console window
            if (flagMaximize)
            {
                // This is not maximizing, 
                // just making the window 
                // with largest size for the screen
                Console.SetWindowSize(
                    Console.LargestWindowWidth,
                    Console.LargestWindowHeight);

                // This is the actual 'Maximize'
                Maximize();
            }
            else
            {
                Console.SetWindowSize(setWindowW, setWindowH);
            }
        }
    }
}