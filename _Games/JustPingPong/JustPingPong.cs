using System;
using CommonUtils; // my DLL in project CommonUtilities


namespace JustPingPong
{
    class JustPingPong
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

        static int setWindowW = 50;
        static int setWindowH = 20;

        static int ballPositionX = 0;
        static int ballPositionY = 0;

        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;

        static int firstPlayerPstn = 0;
        static int secondPlayerPstn = 0;

        static int firstPlayerPad = 6;
        static int secondPlayerPad = 6;

        static int firstPlayerResult = 0;
        static int secondPlayerResult = 0;

        static Random randomGenerator = new Random();

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


            string strStart;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;

                ConsoleWindow.ShowWindowAndBufferInfo();

                Console.Write("Start Game (Y/N): ");
                strStart = Console.ReadLine();
                if (strStart.ToUpper() == "N")
                {
                    RestoreWindowOnExit();
                    return;
                }
                Console.Clear();
            } while (strStart.ToUpper() != "Y");


            SetInitialPositions();

            GameMainLoop();
        }


        static void RestoreWindowOnExit()
        {
            ConsoleWindow.WindowPstn(true, ref WindowX, ref WindowY);
            ConsoleWindow.WindowSize(true, ref WindowH, ref WindowW);
            ConsoleWindow.BufferSize(true, ref BufferH, ref BufferW);
        }

        static void GameMainLoop()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    // clear the keyboard buffer
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    // test keyInfo
                    if (keyInfo.Key == ConsoleKey.A)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.Z)
                    {
                        MoveFirstPlayerDown();
                    }
                }

                SecondPlayerAIMove();
                MoveBall();
                Console.Clear();
                DrawFirstPlayer();
                DrawSecondPlayer();
                DrawBall();
                PrintResult();
                System.Threading.Thread.Sleep(60);
            } // while (true)
        }

        static void SetInitialPositions()
        {
            firstPlayerPstn = (Console.WindowHeight - firstPlayerPad) / 2;
            secondPlayerPstn = (Console.WindowHeight - secondPlayerPad) / 2;
            SetBallInCenter();
        }

        static void SetBallInCenter()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }


        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPstn;
                y < firstPlayerPstn + firstPlayerPad; y++)
            {
                ConsoleUtils.PrintAtXY(1, y, '|');
                ConsoleUtils.PrintAtXY(2, y, '|');
            }
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPstn;
                y < secondPlayerPstn + secondPlayerPad; y++)
            {
                ConsoleUtils.PrintAtXY(Console.WindowWidth - 2, y, '|');
                ConsoleUtils.PrintAtXY(Console.WindowWidth - 3, y, '|');
            }
        }


        static void DrawBall()
        {
            ConsoleUtils.PrintAtXY(ballPositionX, ballPositionY, '@');
        }

        static void PrintResult()
        {
            //ConsoleUtils.PrintAtXY(
            //    Console.WindowWidth / 2 - 1, 0, 
            //    "{0}-{1}");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0}-{1}", firstPlayerResult, secondPlayerResult);
        }


        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPstn + firstPlayerPad < Console.WindowHeight)
            {
                firstPlayerPstn++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPstn > 0)
            {
                firstPlayerPstn--;
            }
        }


        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPstn + secondPlayerPad < Console.WindowHeight)
            {
                secondPlayerPstn++;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPstn > 0)
            {
                secondPlayerPstn--;
            }
        }


        static void SecondPlayerAIMove()
        {
            int randomNumber = randomGenerator.Next(1, 101);
            //if (randomNumber == 0)
            //{
            //    MoveSecondPlayerUp();
            //}
            //if (randomNumber == 1)
            //{
            //    MoveSecondPlayerDown();
            //}

            if (randomNumber < 90)
            {
                if (ballDirectionUp == true)
                {
                    MoveSecondPlayerUp();
                }
                else
                {
                    MoveSecondPlayerDown();
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Common Practices and Code Improvements",
            "RECS0093:Convert 'if' to '&&' expression",
            Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Common Practices and Code Improvements",
            "RECS0033:Convert 'if' to '||' expression",
            Justification = "<Pending>")]
        static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == 0)
            {
                SetBallInCenter();
                ballDirectionRight = true;
                secondPlayerResult++;

                ConsoleKeyInfo keyInfo;
                do
                {
                    Console.SetCursorPosition(
                         Console.WindowWidth / 2 - 9,
                         Console.WindowHeight / 2);
                    Console.Write("Second player wins!");
                    keyInfo = Console.ReadKey(true);
                } while (keyInfo.Key != ConsoleKey.Spacebar);
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallInCenter();
                ballDirectionRight = false;
                firstPlayerResult++;

                ConsoleKeyInfo keyInfo;
                do
                {
                    Console.SetCursorPosition(
                        Console.WindowWidth / 2 - 9,
                        Console.WindowHeight / 2);
                    Console.Write("First player wins!");
                    keyInfo = Console.ReadKey(true);
                } while (keyInfo.Key != ConsoleKey.Spacebar);
            }

            if (ballPositionX < 4)
            {
                if (ballPositionY >= firstPlayerPstn &&
                    ballPositionY < firstPlayerPstn + firstPlayerPad)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= Console.WindowWidth - 4)
            {
                if (ballPositionY >= secondPlayerPstn &&
                    ballPositionY < secondPlayerPstn + secondPlayerPad)
                {
                    ballDirectionRight = false;
                }
            }


            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }

            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }
    }
}