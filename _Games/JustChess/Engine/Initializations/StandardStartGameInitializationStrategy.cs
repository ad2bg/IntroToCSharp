namespace JustChess.Engine.Initializations
{
    using System;
    using System.Collections.Generic;

    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Engine.Contracts;
    using JustChess.Figures;
    using JustChess.Figures.Contracts;
    using JustChess.Players.Contracts;

    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {

        private const int BoardTotalRowsAndCols = 8;

        private IList<Type> figureTypes;

        public StandardStartGameInitializationStrategy()
        {
            figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            AddArmyToBoardRow(firstPlayer, board, 8);
            AddPawnsToBoardRow(firstPlayer, board, 7);

            AddPawnsToBoardRow(secondPlayer, board, 2);
            AddArmyToBoardRow(secondPlayer, board, 1);
        }

        private void AddPawnsToBoardRow(
            IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private void AddArmyToBoardRow(
            IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var figureType = figureTypes[i];
                var figureInstance =
                    (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(figureInstance);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(figureInstance, position);
            }
        }

        private void ValidateStrategy(
            ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandardGameNumberOfPlayers)
            {
                throw new InvalidOperationException(
                    "Standard Start Game Initialization Strategy must have two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols ||
                board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new IndexOutOfRangeException("Standard Start Game Initialization Strategy must have 8x8 board!");
            }
        }
    }
}
