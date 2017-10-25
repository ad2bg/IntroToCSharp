namespace JustChess.Players
{
    using System;
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Figures.Contracts;
    using JustChess.Players.Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;


        public Player(string name, ChessColor color)
        {
            // TODO: validate name length
            this.Name = name;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public string Name { get; private set; }


        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(
                figure, GlobalErrorMessages.NullFigureErrorMessage);
            //TODO: check figure and player color
            figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(
                figure, GlobalErrorMessages.NullFigureErrorMessage);
            //TODO: check figure and player color
            figures.Remove(figure);
        }


        private void CheckIfFigureExists(IFigure figure)
        {
            if (figures.Contains(figure))
            {
                throw new InvalidOperationException(
                    "This player already has this figure!");
            }
        }

        private void CheckIfFigureDoesNotExist(IFigure figure)
        {
            if (!figures.Contains(figure))
            {
                throw new InvalidOperationException(
                    "This player does not have this figure!");
            }
        }
    }
}
