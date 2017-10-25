namespace JustChess.Figures.Contracts
{
    using System.Collections.Generic;
    using JustChess.Common;
    using JustChess.Movements.Contracts;

    public abstract class BaseFigure : IFigure
    {
        // TODO: remove all inheritance and use FigureType enum
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovement> Move(IMovementStrategy strategy);

    }
}
