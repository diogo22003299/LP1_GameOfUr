using System;
using System.Collections.Generic;
using System.Text;

namespace Royal_Game_of_Ur
{
    class Renderer
    {
        private Game game;

        public Renderer(Game game)
        {
            this.game = game;
        }

        /// <summary>
        /// This Method renders the board.
        /// </summary>
        public void RenderBoard()
        {
            Console.Clear();
            for (int y = 0; y < game.MapHeight; y++)
            {
                for (int x = 0; x < game.MapWidth; x++)
                {
                    if (game.Board[x, y].IsLotus)
                        Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(game.Board[x, y].Piece == null ?
                        game.Board[x, y].DefaultSprite : game.Board[x, y].Piece.Sprite);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }

            // Render stats move to other place later!!!!!

            Console.WriteLine($"\n\nTurn number {game.CurrentTurn}");
            Console.WriteLine($"\nPlayer 1 Current Pieces: {game.PlayerOne.NumPieces}");
            Console.WriteLine($"Player 2 Current Pieces: {game.PlayerTwo.NumPieces}");
        }

        /// <summary>
        /// This method renders the choices of the players
        /// </summary>
        /// <param name="movablePieces">The pieces that the player is able to move without going on top of another one</param>
        public void RenderChoice(List<Piece> movablePieces = null)
        {
            if (movablePieces == null)
            {
                RenderRollValue();

                Console.WriteLine("\nChose a Piece to move:");
            }
            else
            {
                for (int i = 0; i < movablePieces.Count; i++)
                {
                    Console.WriteLine($"({i}) Piece in tile {movablePieces[i].InGameHouse}");
                }
            }
        }

        /// <summary>
        /// Renders the text displaying the winner of the game
        /// </summary>
        public void RenderWinner()
        {
            Console.Clear();
            Console.WriteLine($"!!!! Player {game.CurrentPlayer.PlayerId} Wins !!!!");
        }

        /// <summary>
        /// Renders the turn of the current player
        /// </summary>
        public void RenderTurn()
        {
            char turn = game.CurrentTurn % 2 == 0 ? '1' : '2';
            Console.WriteLine($"\nPlayer {turn} playing. \n\n\tPress \"R\" to roll the dices...");
        }

        /// <summary>
        /// Render the text telling the player to chose to move a piece or play a new one
        /// </summary>
        public void RenderPlaceOrMove() => Console.WriteLine("\n- (m) Move Piece\n- (p) Play New Piece");

        /// <summary>
        /// Render the roll value for this turn
        /// </summary>
        public void RenderRollValue() => Console.WriteLine("\nYou rolled a " + game.RollValue);
    }
}
