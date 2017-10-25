namespace JustChess.Engine
{
    using System;
    using System.Collections.Generic;

    using JustChess.Board;
    using JustChess.Board.Contracts;
    using JustChess.Common;
    using JustChess.Engine.Contracts;
    using JustChess.Figures.Contracts;
    using JustChess.InputProviders.Contracts;
    using JustChess.Movements.Contracts;
    using JustChess.Movements.Strategies;
    using JustChess.Players;
    using JustChess.Players.Contracts;
    using JustChess.Renderers.Contracts;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private int currentPlayerIndex;

        public IEnumerable<IPlayer> Players
        {
            get => new List<IPlayer>(players);
        }

        public StandardTwoPlayerEngine(
            IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.movementStrategy = new NormalMovementStrategy();
            this.board = new Board();

        }

        public void Initialize(
            IGameInitializationStrategy gameInitializationStrategy)
        {
            // TODO: remove using JustChess.Players and use the input for players.
            this.players = new List<IPlayer>
            {
                new Player("Gosho",ChessColor.Black),
                new Player("Pesho", ChessColor.White),
            }; //this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);
            this.SetFirstPlayerIndex();

            gameInitializationStrategy.Initialize(this.players, this.board);

            this.renderer.RenderBoard(this.board);
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }


        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsOwnFigure(figure, to);

                    var availableMovements = figure.Move(movementStrategy);
                    foreach (var movement in availableMovements)
                    {
                        movement.ValidateMove(figure, board, move);
                    }

                    board.MoveFigureAtPosition(figure, from, to);

                    // TODO: On every move check if we are in check
                    // TODO: Check castle - check if castle is valid
                    // TODO: If not castle - move figure (check pawn for an-pasan)
                    // TODO: Check check
                    // TODO: If in check - check checkmate
                    // TODO: If in check - check draw
                    // TODO: Continue

                    this.renderer.RenderBoard(this.board);
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }
            }
        }


        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }


        private IPlayer GetNextPlayer()
        {
            currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }
            return this.players[this.currentPlayerIndex];
        }


        private void CheckIfPlayerOwnsFigure(
            IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(
                    string.Format("Position {0}{1} is empty!", from.Col, from.Row));
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(
                    string.Format("Figure at {0}{1} is not yours!", from.Col, from.Row));
            }
        }


        private void CheckIfToPositionIsOwnFigure(
            IFigure figure, Position to)
        {
            var figureAtToPosiiton = this.board.GetFigureAtPosition(to);
            if (figureAtToPosiiton != null && figure.Color == figureAtToPosiiton.Color)
            {
                throw new InvalidOperationException(
                    string.Format("You already have a figure at {0}{1}!", to.Col, to.Row));
            }
        }


    }
}
