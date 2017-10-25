namespace JustChess.Board
{
    using System;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public class Board : IBoard
    {
        private readonly IFigure[,] board;
        public int TotalRows { get; private set; }
        public int TotalCols { get; private set; }

        private int GetArrayRow(int chessRow) => this.TotalRows - chessRow;
        private int GetArrayCol(char chessCol) => chessCol - 'a';

        public Board(
            int rows = GlobalConstants.StandardGameTotalBoardRows,
            int cols = GlobalConstants.StandardGameTotlaBoardCols)
        {
            TotalRows = rows;
            TotalCols = cols;
            board = new IFigure[rows, cols];
        }


        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(
                figure, GlobalErrorMessages.NullFigureErrorMessage);

            Position.CheckIfValid(position);

            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);
            board[arrRow, arrCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            Position.CheckIfValid(position);

            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);
            board[arrRow, arrCol] = null;
        }


        public IFigure GetFigureAtPosition(Position position)
        {
            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);
            return this.board[arrRow, arrCol];
        }

        public void MoveFigureAtPosition(IFigure figure, Position from, Position to)
        {
            int arrFromRow = GetArrayRow(from.Row);
            int arrFromCol = GetArrayCol(from.Col);
            this.board[arrFromRow, arrFromCol] = null;

            int arrToRow = GetArrayRow(to.Row);
            int arrToCol = GetArrayCol(to.Col);
            this.board[arrToRow, arrToCol] = figure;
        }
    }

}
