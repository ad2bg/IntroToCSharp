using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using CommonUtils; // my DLL in project CommonUtilities


namespace JustCars
{
    struct Object
    {
        public int x; // lane
        public int y;
        public char c;
        public ConsoleColor color;

        // constructor
        public Object(int x, int y, char c, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.c = c;
            this.color = color;
        }
    }

    class JustCars
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
        static int setWindowW = 30;
        static int setWindowH = 30;

        static Random randomGenerator = new Random();

        static int playfieldWidth = 6;
        static int livesCount = 5;
        static int score = 0;

        static int maxSpeed = 230;
        static int minSpeed = 80;
        static double speed = minSpeed;

        static double acceleration = 0.4;
        static double maxAcceleration = 1;
        static double minAcceleration = 0.1;

        static int pctNewLife = 1;
        static int spdNewLife = 20;
        static int pctSlowDn = 3;
        static int spdSlowDn = 10;
        static int pctCars = 15;

        static bool bang = false;

        static Object userCar = new Object(
            2, setWindowH - 1, '^', ConsoleColor.Yellow);

        static List<Object> objects = new List<Object>();

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

            do
            {
                ConsoleKeyInfo ckiStart;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ConsoleWindow.ShowWindowAndBufferInfo();

                    ShowGameInstructions();

                    ckiStart = Console.ReadKey(true);
                    if (ckiStart.Key == ConsoleKey.N)
                    {
                        RestoreWindowOnExit();
                        return;
                    }
                } while (ckiStart.Key != ConsoleKey.Y);

                livesCount = 5;
                GameMainLoop();
            } while (true);

        }


        static void ShowGameInstructions()
        {
            string txt = "";
            txt = txt + " Just Cars\n";
            txt = txt + " =========\n\n";
            txt = txt + " Min Speed: {0}\n";
            txt = txt + " Max Speed: {1}\n\n";

            txt = String.Format(txt, minSpeed, maxSpeed);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(txt);

            txt = "";
            txt = txt + "         NUM      ARROWS\n";
            txt = txt + "        =====   ===========\n";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(txt);
            txt = "";
            txt = txt + " Use:   4   6   LEFT  RIGHT\n\n";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(txt);

            Console.Write(" Start Game (Y/N): ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GameMainLoop()
        {
            while (true)
            {
                bang = false;
                score++;

                userCar = MoveUserCar();

                AddObject();

                MoveCars();

                if (livesCount < 0)
                {
                    GameOver();
                    return;
                }

                Console.Clear();

                DrawCerb();

                DrawCars();

                DrawUserCar();

                DrawInfo();

                speed += acceleration;
                if (speed > maxSpeed) speed = maxSpeed;
                Thread.Sleep((int)(10000 / speed));

            } // while (true)
        }

        static Object TestPressedKey(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.LeftArrow ||
                pressedKey.Key == ConsoleKey.NumPad4)
            {
                if (userCar.x >= 1) userCar.x--;
            }

            if (pressedKey.Key == ConsoleKey.RightArrow ||
                pressedKey.Key == ConsoleKey.NumPad6)
            {
                if (userCar.x < playfieldWidth - 1) userCar.x++;
            }

            return userCar;
        }

        static Object MoveUserCar()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                // clear the keyboard buffer
                //while (Console.KeyAvailable) Console.ReadKey(true);

                userCar = TestPressedKey(pressedKey);
            }

            return userCar;
        }

        static void MoveCars()
        {
            var newList = new List<Object>();

            for (int i = 0; i < objects.Count; i++)
            {
                Object car = objects[i];
                var newObject =
                    new Object(car.x, car.y + 1, car.c, car.color);

                Collision(newObject);

                if (car.y + 1 < Console.WindowHeight)
                {
                    newList.Add(newObject);
                }
            }
            objects = newList;
        }

        static void Collision(Object newObject)
        {
            if (newObject.c == '*' &&
                newObject.x == userCar.x &&
                newObject.y == userCar.y)
            {
                SoundGood();
                speed -= spdSlowDn;
                if (speed < minSpeed)
                    speed = minSpeed;
                acceleration -= 0.2;
                if (acceleration < minAcceleration)
                    acceleration = minAcceleration;
            }

            if (newObject.c == '-' &&
                newObject.x == userCar.x &&
                newObject.y == userCar.y)
            {
                SoundGood();
                livesCount++;
                acceleration += 0.1;
                if (acceleration > maxAcceleration)
                    acceleration = maxAcceleration;
            }

            if (newObject.c == '#' &&
            newObject.x == userCar.x &&
            newObject.y == userCar.y)
            {
                SoundBad();
                livesCount--;
                speed += spdNewLife;
                if (speed > maxSpeed) speed = maxSpeed;
                bang = true;
            }
        }


        static void GameOver()
        {
            string txt = "GAME OVER!!!";
            ConsoleUtils.PrintAtXY(8, 10, txt, ConsoleColor.Red);

            txt = "Press [Enter] to exit.";
            ConsoleUtils.PrintAtXY(8, 12, txt, ConsoleColor.Red);

            do { Console.Beep(); }
            while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        static void RestoreWindowOnExit()
        {
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleWindow.WindowPstn(true, ref WindowX, ref WindowY);
            ConsoleWindow.WindowSize(true, ref WindowH, ref WindowW);
            ConsoleWindow.BufferSize(true, ref BufferH, ref BufferW);
        }


        static void AddObject()
        {
            int chance = randomGenerator.Next(0, 100);

            if (chance < pctNewLife)
            {
                AddBonusNewLifeObject();
            }
            else if (chance < pctNewLife + pctSlowDn)
            {
                AddBonusSlowDownObject();
            }
            else if (chance < pctNewLife + pctSlowDn + pctCars)
            {
                AddNewCar();
            }
        }

        static void AddBonusNewLifeObject()
        {
            var newObject = new Object(
                randomGenerator.Next(0, playfieldWidth), 0,
                '-', ConsoleColor.Magenta);
            objects.Add(newObject);
        }

        static void AddBonusSlowDownObject()
        {
            var newObject = new Object(
                randomGenerator.Next(0, playfieldWidth), 0,
                '*', ConsoleColor.Cyan);
            objects.Add(newObject);
        }

        static void AddNewCar()
        {
            objects.Add(new Object(
                randomGenerator.Next(0, playfieldWidth), 0,
                '#', ConsoleColor.Green));
        }

        static void DrawCerb()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                ConsoleUtils.PrintAtXY(
                    playfieldWidth, i, '|');
            }
        }

        static void DrawCars()
        {
            foreach (Object car in objects)
            {
                ConsoleUtils.PrintAtXY(car.x, car.y, car.c, car.color);
            }
        }

        static void DrawUserCar()
        {
            if (bang)
            {
                objects.Clear();
                ConsoleUtils.PrintAtXY(
                    userCar.x, userCar.y, 'X', ConsoleColor.Red);
            }
            else
            {
                ConsoleUtils.PrintAtXY(
                    userCar.x, userCar.y, userCar.c, userCar.color);
            }
        }

        static void DrawInfo()
        {
            ConsoleUtils.PrintAtXY(
                8, 4, "Speed: " + (int)speed, ConsoleColor.White);
            ConsoleUtils.PrintAtXY(
                8, 5, "Acceleration: " + acceleration, ConsoleColor.White);
            ConsoleUtils.PrintAtXY(
                8, 7, "Lives: " + livesCount,
                ((livesCount == 0) ? ConsoleColor.Red : ConsoleColor.White));
            ConsoleUtils.PrintAtXY(
                8, 8, "Score: " + score, ConsoleColor.White);
        }


        static void SoundBad()
        {
            Console.Beep(1500, 100);
            Console.Beep(1000, 100);
        }

        static void SoundGood()
        {
            Console.Beep(1000, 100);
            Console.Beep(1500, 100);
        }
    }
}
