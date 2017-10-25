using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using CommonUtils; // my DLL in project CommonUtilities

namespace Snake
{

    struct Position
    {
        public int row;
        public int col;

        // constructor
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }


    class Snake
    {

        #region Static fields
        static int WindowH;
        static int WindowY;
        static int WindowW;
        static int WindowX;
        static int BufferH;
        static int BufferW;

        static int setWindowX = 5;
        static int setWindowY = 5;

        static int setWindowW = 60;
        static int setWindowH = 30;

        static readonly Random randomGenerator = new Random();

        static ConsoleKeyInfo userInput;



        #endregion Static fields


        static void Main()
        {

            // Set Console window position and size
            ConsoleWindow.WPAS(
                ref WindowX, ref WindowY,
                ref WindowH, ref WindowW,
                ref BufferH, ref BufferW,
                setWindowX, setWindowY,
                setWindowW, setWindowH
                );

            ConsoleWindow.RemoveScrollBars();


        StartGame:
            #region Start Game (Y/N)
            string strStart;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;

                ConsoleWindow.ShowWindowAndBufferInfo();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Obstacles: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("#\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Food: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("@");

                string txt = "";
                txt = txt + "\n";
                txt = txt + " Food changes position every 8 seconds.\n\n";
                txt = txt + " Every bite:        +100 points\n";
                txt = txt + " Every missed bite:  -50 points\n\n\n";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(txt);

                txt = "";
                txt = txt + "             KEYS         NUM      ARROWS\n";
                txt = txt + "        ==============   =====   ===========\n\n";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(txt);
                txt = "";
                txt = txt + "          W        I       8         UP\n\n";
                txt = txt + " Use:   A   S    J   K   4 5 6   LEFT  RIGHT\n\n";
                txt = txt + "          Z        M       2        DOWN\n\n\n";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(txt);

                Console.Write(" Start Game (Y/N): ");
                Console.ForegroundColor = ConsoleColor.White;
                strStart = Console.ReadLine();
                if (strStart.ToUpper() == "N")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    ConsoleWindow.WindowPstn(true, ref WindowX, ref WindowY);
                    ConsoleWindow.WindowSize(true, ref WindowH, ref WindowW);
                    ConsoleWindow.BufferSize(true, ref BufferH, ref BufferW);
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                }
            } while (strStart.ToUpper() != "Y");
            #endregion Start Game (Y/N)

            #region Declarations

            double sleepTime = 100;

            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;

            int lastFoodTime = Environment.TickCount;
            int foodChangeTime = 8000;

            int score = 0;


            // Define Directions
            var directions = new Position[]
            {
                new Position(0,1),  // right
                new Position(0,-1), // left
                new Position(1,0),  // down
                new Position(-1,0)  // up
            };
            int direction = right;

            // Define Obstacles
            var obstacles = new List<Position>
            {
                new Position(Console.WindowHeight/2,Console.WindowWidth/4*1),
                new Position(Console.WindowHeight/2,Console.WindowWidth/4*2),
                new Position(Console.WindowHeight/2,Console.WindowWidth/4*3)
            };

            // Define Queue for snake
            var snakeElements = new Queue<Position>();
            for (int i = 0; i < 6; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            // Define food
            Position food;

            #endregion Declarations

            Console.Clear();

            #region Initialization

            foreach (Position obstacle in obstacles)
            {
                ConsoleUtils.PrintAtXY(
                   obstacle.col, obstacle.row, '#', ConsoleColor.Cyan);
            }


            // Draw Snake
            foreach (Position position in snakeElements)
            {
                ConsoleUtils.PrintAtXY(
                   position.col, position.row, '*', ConsoleColor.Green);
            }


            // Set 'food'
            do
            {
                food = new Position(
                   randomGenerator.Next(0, Console.WindowHeight - 1),
                   randomGenerator.Next(0, Console.WindowWidth));
            }
            while (
                snakeElements.Contains(food) ||
                obstacles.Contains(food));

            lastFoodTime = Environment.TickCount;
            ConsoleUtils.PrintAtXY(
                food.col, food.row, '@', ConsoleColor.Yellow);

            #endregion Initialization


            // MAIN LOOP
            while (true)
            {


                if (Console.KeyAvailable)
                {

                    userInput = Console.ReadKey(true);

                    if (userInput.Key == ConsoleKey.LeftArrow ||
                        userInput.Key == ConsoleKey.NumPad4 ||
                        userInput.Key == ConsoleKey.J ||
                        userInput.Key == ConsoleKey.A)
                    {
                        if (direction != right) direction = left;
                    }


                    if (userInput.Key == ConsoleKey.RightArrow ||
                        userInput.Key == ConsoleKey.NumPad6 ||
                        userInput.Key == ConsoleKey.K ||
                        userInput.Key == ConsoleKey.S)
                    {
                        if (direction != left) direction = right;
                    }


                    if (userInput.Key == ConsoleKey.UpArrow ||
                        userInput.Key == ConsoleKey.NumPad8 ||
                        userInput.Key == ConsoleKey.I ||
                        userInput.Key == ConsoleKey.W)
                    {
                        if (direction != down) direction = up;
                    }


                    if (userInput.Key == ConsoleKey.DownArrow ||
                        userInput.Key == ConsoleKey.NumPad5 ||
                        userInput.Key == ConsoleKey.NumPad2 ||
                        userInput.Key == ConsoleKey.M ||
                        userInput.Key == ConsoleKey.Z ||
                        (int)userInput.Key == 12)
                    {
                        if (direction != up) direction = down;
                    }
                }

                Position snakeDirection = directions[direction];


                Position snakeHead = snakeElements.Last();

                var snakeNewHead = new Position(
                        snakeHead.row + snakeDirection.row,
                        snakeHead.col + snakeDirection.col);

                if (snakeNewHead.col < 0)
                    snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0)
                    snakeNewHead.row = Console.WindowHeight - 2;
                if (snakeNewHead.col >= Console.WindowWidth)
                    snakeNewHead.col = 0;
                if (snakeNewHead.row >= Console.WindowHeight - 1)
                    snakeNewHead.row = 0;


                if (snakeElements.Contains(snakeNewHead) ||
                    obstacles.Contains(snakeNewHead))
                {
                    ConsoleUtils.PrintAtXY(
                        Console.WindowWidth / 2 - 5,
                        Console.WindowHeight / 2 - 1,
                        "Game over!", ConsoleColor.Red);

                    ConsoleUtils.PrintAtXY(
                        Console.WindowWidth / 2 - 9,
                        Console.WindowHeight / 2 + 1,
                        "Your score is: " + score, ConsoleColor.Red);

                    Thread.Sleep(4000);
                    userInput = Console.ReadKey(true);
                    goto StartGame;
                }


                ConsoleUtils.PrintAtXY(
                    snakeHead.col, snakeHead.row,
                    '*', ConsoleColor.Green);


                snakeElements.Enqueue(snakeNewHead);

                ConsoleUtils.PrintAtXY(
                    snakeNewHead.col, snakeNewHead.row,
                    "><v^"[direction], ConsoleColor.Red);


                if (snakeNewHead.row == food.row &&
                    snakeNewHead.col == food.col)
                {

                    score += 100;

                    // feeding Snake
                    do
                    {
                        food = new Position(
                            randomGenerator.Next(0, Console.WindowHeight - 1),
                            randomGenerator.Next(0, Console.WindowWidth));
                    }
                    while (
                        snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;

                    var obstacle = new Position();

                    do
                    {
                        obstacle = new Position(
                            randomGenerator.Next(0, Console.WindowHeight - 1),
                            randomGenerator.Next(0, Console.WindowWidth));
                    }
                    while (snakeElements.Contains(obstacle) ||
                        obstacles.Contains(obstacle) ||
                        (food.row == obstacle.row &&
                         food.col == obstacle.col));
                    obstacles.Add(obstacle);

                    ConsoleUtils.PrintAtXY(
                        obstacle.col, obstacle.row, '#', ConsoleColor.Cyan);

                    sleepTime--;

                }
                else
                {
                    // moving
                    Position last = snakeElements.Dequeue();

                    ConsoleUtils.PrintAtXY(last.col, last.row, ' ');
                }

                if (Environment.TickCount - lastFoodTime >= foodChangeTime)
                {
                    score -= 50;

                    ConsoleUtils.PrintAtXY(food.col, food.row, ' ');

                    do
                    {
                        food = new Position(
                            randomGenerator.Next(0, Console.WindowHeight - 1),
                            randomGenerator.Next(0, Console.WindowWidth));
                    }
                    while (
                        snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;

                }


                ConsoleUtils.PrintAtXY(
                    food.col, food.row, '@', ConsoleColor.Yellow);

                ConsoleUtils.PrintAtXY(
                    0, Console.WindowHeight - 1,
                    String.Format(" Score: {0}", score), ConsoleColor.Yellow);


                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}