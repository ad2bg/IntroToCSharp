namespace JustChess.Figures.Contracts
{
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Movements.Contracts;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
