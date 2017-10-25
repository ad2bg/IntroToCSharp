namespace JustChess.InputProviders
{
    using System;
    using System.Collections.Generic;

    using JustChess.Common;
    using JustChess.Common.Console;
    using JustChess.InputProviders.Contracts;
    using JustChess.Players;
    using JustChess.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter Player {0} name: ";


        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(string.Format(PlayerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }
            return players;
        }

        /// <summary>
        /// Command is in format: a5-c5
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Move GetNextPlayerMove(IPlayer player)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.SetCursorPosition(
                Console.WindowWidth / 2 - player.Name.Length - 1,
                ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write("{0}: ", player.Name);
            string command = Console.ReadLine().Trim().ToLower();
            return ConsoleHelpers.CreateMoveFromCommand(command);
        }
    }
}
