namespace JustChess.Movements.Strategies
{
    using System.Collections.Generic;
    using JustChess.Figures.Contracts;
    using JustChess.Movements.Contracts;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private IDictionary<string, IList<IMovement>> movements =
            new Dictionary<string, IList<IMovement>>
        {
            { "Pawn", new List<IMovement>
                {
                    new NormalPawnMovement()
                }
            },
            { "Bishop", new List<IMovement>
                {
                    new NormalBishopMovement()
                }
            }
        };


        public IList<IMovement> GetMovements(IFigure figure)
        {
            return this.movements[figure.GetType().Name];
        }
    }
}
