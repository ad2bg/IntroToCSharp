namespace JustChess.Movements
{
    using System;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;

    public class NormalPawnMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            const string InvalidMove = "Pawn cannot move this way!";

            var color = figure.Color;
            var from = move.From;
            var to = move.To;
            var totalRows = board.TotalRows;
            var totalCols = board.TotalCols;

            // Prevent movement backwards and sideways
            if ((color == ChessColor.White && to.Row <= from.Row) ||
                (color == ChessColor.Black && to.Row >= from.Row))
            {
                throw new InvalidOperationException(InvalidMove);
            }

            // Movement to the next row
            if ((color == ChessColor.White && to.Row == from.Row + 1) ||
                (color == ChessColor.Black && to.Row == from.Row - 1))
            {
                if (Math.Abs(to.Col - from.Col) == 1)
                {
                    var otherFigure = board.GetFigureAtPosition(to);
                    if (otherFigure != null) // It's an oponent's figure
                    {
                        // Capturing the oponent's figure is a valid move
                        return;
                    }
                }
                else if (to.Col == from.Col) // Movement 1 square ahead
                {
                    var otherFigure = board.GetFigureAtPosition(to);
                    if (otherFigure == null)
                    {
                        // It's empty, so this is a valid move
                        return;
                    }
                }
                else
                {
                    // Movement to other columns on the next row is invalid!
                    throw new InvalidOperationException(InvalidMove);
                }
            }

            // Initial movement with two rows
            if (color == ChessColor.White && to.Row == from.Row + 2 && from.Row == 2)
            {
                var otherFigure = board.GetFigureAtPosition(new Position(from.Row + 1, from.Col));
                if (otherFigure != null) // There's a figure being jumped over
                {
                    throw new InvalidOperationException(InvalidMove);
                }
                else
                {
                    // There's no figure being jumped over - this is a valid move
                    return;
                }
            }
            if (color == ChessColor.Black && to.Row == from.Row - 2 && from.Row == totalRows - 1)
            {
                var otherFigure = board.GetFigureAtPosition(new Position(from.Row - 1, from.Col));
                if (otherFigure != null) // There's a figure being jumped over
                {
                    throw new InvalidOperationException(InvalidMove);
                }
                else
                {
                    // There's no figure being jumped over - this is a valid move
                    return;
                }
            }

            throw new InvalidOperationException(InvalidMove);
        }
    }
}
