using System;
using System.Collections.Generic;

namespace Royal_Game_of_Ur
{
    class Game
    {
        // Game Consts
        public int MapWidth { get => 8; }
        public int MapHeight { get => 3; }

        // House IDs of lotus Tiles | Lotus Lands 4-8-14
        private int[] lotusIds = new int[] { 4, 8, 14 };

        // Initialize 2 new players
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public Player CurrentPlayer { get; private set; }

        private Renderer render;

        private Dice dice;

        // Create the game board
        public Tile[,] Board { get; private set; }

        public void GameLoop()
        {
            InitializeMap();

            // Initialize a new bool to determin if the player has landed on a lotus land
            bool lotusLand = false;

            render.RenderBoard();

            CurrentPlayer = PlayerOne;

            // Save players input troughout the game
            ConsoleKey playerInput;
        }

        private void InitializeMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    // Set the sprite for the location on the board
                    Board[x, y].DefaultSprite = y == 1 ? '-' : x < 4 || x > 5 ? '-' : ' ';

                    // Set the Id for the location on the board
                    Board[x, y].Id = y == 1 ? 5 + x : x < 4 ? 4 - x : 20 - x;

                    // Setup Lotus tiles
                    for (int i = 0; i < lotusIds.Length; i++)
                    {
                        if (Board[x, y].Id == lotusIds[i])
                        {
                            Board[x, y].IsLotus = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}