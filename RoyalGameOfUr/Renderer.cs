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
        }
    }
}