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

        // Declare new list to hold movablePieces
        private List<Piece> movablePieces;

        // Create the game board
        public Tile[,] Board { get; private set; }

        // Even = Player 1 turn, Odd = Player 2 turn
        public int CurrentTurn { get; private set; }

        // Saves the rollValue
        public int RollValue { get; private set; }

        /// <summary>
        /// Initializes all game variables
        /// </summary>
        public Game()
        {
            PlayerOne = new Player(1);
            PlayerTwo = new Player(2);
            Board = new Tile[MapWidth, MapHeight];
            render = new Renderer(this);
            dice = new Dice();
            movablePieces = new List<Piece>();
            CurrentTurn = 0;
            RollValue = 0;
        }


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

        /// <summary>
        /// Lets the Player chose what piece he wants to move
        /// </summary>
        /// <returns></returns>
        private bool ChoosePieceToMove()
        {
            render.RenderBoard();

            render.RenderChoice();

            bool available = true;

            movablePieces.Clear();

            for (int i = 0; i < CurrentPlayer.InGamePieces.Count; i++)
            {
                for (int j = 0; j < CurrentPlayer.InGamePieces.Count; j++)
                {
                    if (CurrentPlayer.InGamePieces[i].InGameHouse + RollValue == CurrentPlayer.InGamePieces[j].InGameHouse)
                    {
                        available = false;
                    }
                }
                if (available)
                {
                    movablePieces.Add(CurrentPlayer.InGamePieces[i]);
                }
                available = true;
            }

            render.RenderChoice(movablePieces);

            int userInput;

            // Lock player input to only the right numbers
            while (
                !int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out userInput) ||
                userInput >= movablePieces.Count) { }

            return MovePieces(movablePieces[userInput]);
        }

        private bool MovePieces(Piece pieceToMove)
        {
            if (pieceToMove.InGameHouse + RollValue > 14)
            {
                // Piece comes out Condition
                if (pieceToMove.InGameHouse + RollValue == 15)
                {
                    // Remove the piece from the board
                    Board[pieceToMove.X, pieceToMove.Y].Piece = null;
                    // Remove the peice from the player
                    CurrentPlayer.InGamePieces.Remove(pieceToMove);
                    // Increase the number of pieces the player has completed
                    CurrentPlayer.CompletedPieces++;
                    // Update the player's number of pieces
                    CurrentPlayer.UpdateNumberOfPieces();
                    return false;
                }

                return false;
            }

            // Start on Y = 1 in case it's the second player's turn
            for (int y = CurrentPlayer.PlayerId == 1 ? 0 : 1; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (pieceToMove.InGameHouse == 0)
                    {
                        if (Board[x, y].Id == RollValue)
                        {
                            pieceToMove.InGameHouse = RollValue;
                            // Put the piece in game
                            Board[x, y].Piece = CurrentPlayer.Pieces.Pop();
                            // Give it new coordinates
                            Board[x, y].Piece.X = x;
                            Board[x, y].Piece.Y = y;
                            // Update the player's InGamePiece
                            CurrentPlayer.InGamePieces.Add(Board[x, y].Piece);

                            return Board[x, y].IsLotus;
                        }
                    }
                    else if (Board[x, y].Id == pieceToMove.InGameHouse + RollValue)
                    {
                        if (Board[x, y].Piece == null)
                        {
                            pieceToMove.InGameHouse += RollValue;
                            // Move the piece to the new location on the board
                            Board[x, y].Piece = pieceToMove;
                            // Remove the piece from the previous location
                            Board[pieceToMove.X, pieceToMove.Y].Piece = null;
                            // Update the coordinates
                            Board[x, y].Piece.X = x;
                            Board[x, y].Piece.Y = y;

                            return Board[x, y].IsLotus;
                        }
                        else if (Board[x, y].IsLotus)
                        {
                            // If the enemy piece is in a lotus tile we can't move our piece to that spot!
                            return false;
                        }
                        else
                        {
                            // Reset the enemy piece house
                            Board[x, y].Piece.InGameHouse = 0;

                            // Update the enemy piece lists
                            if (CurrentPlayer.PlayerId == 1)
                            {
                                PlayerTwo.Pieces.Push(Board[x, y].Piece);
                                PlayerTwo.InGamePieces.Remove(Board[x, y].Piece);
                            }
                            else
                            {
                                PlayerOne.Pieces.Push(Board[x, y].Piece);
                                PlayerOne.InGamePieces.Remove(Board[x, y].Piece);
                            }

                            // Remove the enemy piece from the board
                            Board[x, y].Piece = null;

                            // Move the current player's piece to the correct tile
                            Board[x, y].Piece = pieceToMove;
                            Board[pieceToMove.X, pieceToMove.Y].Piece = null;
                            Board[x, y].Piece.X = x;
                            Board[x, y].Piece.Y = y;
                            pieceToMove.InGameHouse += RollValue;

                            // Return false if we where able to eat his pice it's not a lotus house
                            return false;
                        }
                    }
                }
            }
            return false;
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