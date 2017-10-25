namespace JustChess.Renderers
{
    using System;
    using System.Threading;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Common.Console;
    using JustChess.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "JUST CHESS";

        public const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        public const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

        public ConsoleRenderer()
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 80;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }


        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            // TODO: add main menu
            Thread.Sleep(1000);
        }
        
        public void RenderBoard(IBoard board)
        {
            // TODO: Validate Console dimensions
            var boardHeight = board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var boardWidth = board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare;

            var startRowPrint = Console.WindowHeight / 2 - boardHeight / 2;
            var startColPrint = Console.WindowWidth / 2 - boardWidth / 2;

            PrintBorder(board, startRowPrint, startColPrint);

            int counterBW = 0;
            var currentRowPrint = startRowPrint;
            for (int top = 0; top < board.TotalRows; top++)
            {
                var currentColPrint = startColPrint;
                for (int left = 0; left < board.TotalCols; left++)
                {
                    ConsoleColor backgroundColor =
                        counterBW % 2 == 0 ?
                        LightSquareConsoleColor :
                        DarkSquareConsoleColor;

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);
                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);

                    currentColPrint += ConsoleConstants.CharactersPerColPerBoardSquare;

                    counterBW++;
                }
                currentRowPrint += ConsoleConstants.CharactersPerRowPerBoardSquare;

                if (board.TotalCols % 2 == 0) { counterBW++; }
            }
        }

        private static void PrintBorder(IBoard board, int startRowPrint, int startColPrint)
        {
            var boardHeight = board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var boardWidth = board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare;

            Console.BackgroundColor = ConsoleColor.Black;

            // Row numbers
            for (int i = 0; i < board.TotalRows; i++)
            {
                int row = startRowPrint +
                    ConsoleConstants.CharactersPerRowPerBoardSquare * (board.TotalRows - i) -
                    ConsoleConstants.CharactersPerRowPerBoardSquare / 2;
                Console.SetCursorPosition(startColPrint - 1, row); Console.Write(i + 1);
                Console.SetCursorPosition(startColPrint + boardWidth, row); Console.Write(i + 1);
            }
            // Column letters
            for (int i = 0; i < board.TotalCols; i++)
            {
                var col = startColPrint +
                     ConsoleConstants.CharactersPerColPerBoardSquare * i +
                     ConsoleConstants.CharactersPerColPerBoardSquare / 2;
                Console.SetCursorPosition(col, startRowPrint - 1); Console.Write((char)(i + 'A'));
                Console.SetCursorPosition(col, startRowPrint + boardHeight); Console.Write((char)(i + 'A'));
            }

            Console.BackgroundColor = DarkSquareConsoleColor;

            // Vertical bordes
            for (int i = startRowPrint - 2; i < startRowPrint + boardHeight + 2; i++)
            {
                Console.SetCursorPosition(startColPrint - 2, i); Console.Write(" ");
                Console.SetCursorPosition(startColPrint + boardWidth + 1, i); Console.Write(" ");
            }
            // Horizontal borders
            for (int i = startColPrint - 1; i < startColPrint + boardWidth + 1; i++)
            {
                Console.SetCursorPosition(i, startRowPrint - 2); Console.Write(" ");
                Console.SetCursorPosition(i, startRowPrint + boardHeight + 1); Console.Write(" ");
            }
        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.SetCursorPosition(
                Console.WindowWidth / 2 - errorMessage.Length / 2,
                ConsoleConstants.ConsoleRowForPlayerIO);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(errorMessage);
            Thread.Sleep(2000);
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        }


    }
}
