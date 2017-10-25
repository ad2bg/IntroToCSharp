namespace JustChess.Movements.Contracts
{
    using System.Collections.Generic;
    using JustChess.Figures.Contracts;

    public interface IMovementStrategy
    {
        IList<IMovement> GetMovements(IFigure figure);
    }
}
