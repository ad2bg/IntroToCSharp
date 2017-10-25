namespace JustChess.Movements
{
    using System;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;

    public class NormalBishopMovement : IMovement
    {
        const string InvalidMove = "Bishop cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            int fromRow = move.From.Row;
            int fromCol = move.From.Col;
            int toRow = move.To.Row;
            int toCol = move.To.Col;

            var rowDistance = toRow - fromRow;
            var colDistance = toCol - fromCol;

            // Prevent non-diagonal movement
            if (Math.Abs(rowDistance) != Math.Abs(colDistance))
            {
                throw new InvalidOperationException(InvalidMove);
            }

            // Check for figures obstructing the way to the To position
            if (Math.Abs(rowDistance) >= 2)
            {
                for (int i = 1; i <= Math.Abs(rowDistance) - 1; i++)
                {
                    var iPsn = new Position(
                        fromRow + i * Math.Sign(rowDistance),
                        (char)(fromCol + i * Math.Sign(colDistance)));
                    if (board.GetFigureAtPosition(iPsn) != null)
                    {
                        throw new InvalidOperationException(InvalidMove);
                    }
                }
            }

        }
    }
}
