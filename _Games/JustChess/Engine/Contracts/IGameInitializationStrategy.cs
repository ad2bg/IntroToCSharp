namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;
    using JustChess.Board.Contracts;
    using JustChess.Players.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
