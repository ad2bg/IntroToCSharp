namespace JustChess.Common.Console
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using JustChess.Figures;
    using JustChess.Figures.Contracts;

    public static class ConsoleHelpers
    {
        private static IDictionary<Type, string[]> patterns =
            new Dictionary<Type, string[]>
        {
            {typeof(Pawn), new string[]
                {
                    "         ",
                    "         ",
                    "    █    ",
                    "   ███   ",
                    "   ███   ",
                    "    █    ",
                    "   ███   ",
                    "  █████  ",
                    "         "
                }
            },
            { typeof(Rook), new string[]
                {
                    "         ",
                    "  █ █ █  ",
                    "   ███   ",
                    "   ███   ",
                    "   ███   ",
                    "   ███   ",
                    "  █████  ",
                    "  █████  ",
                    "         "
                }
            },
            {typeof(Knight), new string[]
                {
                    "         ",
                    "    ██   ",
                    "   ████  ",
                    "  ███ █  ",
                    "   █ ██  ",
                    "    ███  ",
                    "   ███   ",
                    "  █████  ",
                    "         "
                }
            },
            {typeof(Bishop), new string[]
                {
                    "         ",
                    "    █    ",
                    "   ███   ",
                    "  ██ ██  ",
                    "  █   █  ",
                    "   █ █   ",
                    "    █    ",
                    "  ██ ██  ",
                    "         "
                }
            },
            {typeof(King), new string[]
                {
                    "         ",
                    "    █    ",
                    "   ███   ",
                    " ██ █ ██ ",
                    " ███ ███ ",
                    " ███████ ",
                    "  █████  ",
                    "  █████  ",
                    "         "
                }
            },
            {typeof(Queen), new string[]
                {
                    "         ",
                    "    █    ",
                    "  █ █ █  ",
                    "   █ █   ",
                    " █ ███ █ ",
                    "  █ █ █  ",
                    "  ██ ██  ",
                    "  █████  ",
                    "         "
                }
            }
        };

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Brown:
                    return ConsoleColor.DarkYellow;
                default:
                    throw new InvalidOperationException("Cannot conver chess color");
            }
        }

        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;

            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void PrintFigure(
            IFigure figure, ConsoleColor backgroundColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            var figurePattern = patterns[figure.GetType()];


            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern[0].Length; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    if (figurePattern[i][j] == '█')
                    {
                        Console.BackgroundColor = figure.Color.ToConsoleColor();
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                    }
                    Console.Write(" ");
                }
            }
        }

        public static void PrintEmptySquare(
            ConsoleColor backgroundColor, int top, int left)
        {
            Console.BackgroundColor = backgroundColor;
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }

        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command.Split(new[] { '-' });
            if (positionAsStringParts.Length!=2)
            {
                throw new InvalidOperationException("Invaid command!");
            }

            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPosition = Position.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }

        public static void ClearRow(int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write(new String(' ', Console.WindowWidth));
        }
    }
}
