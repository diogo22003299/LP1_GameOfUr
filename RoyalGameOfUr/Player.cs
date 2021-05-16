using System;
using System.Collections.Generic;
using System.Text;

namespace Royal_Game_of_Ur
{
    public class Player
    {
        private const int startingPieces = 7;

        public int PlayerId { get; private set; }
        public int NumPices { get; private set; }
        public int CompletedPieces { get; set; }

        public Stack<Piece> Pieces { get; set; }

        public List<Piece> InGamePieces { get; set; }

        public Player(int playerId)
        {
            PlayerId = playerId;
            NumPices = startingPieces;
            CompletedPieces = 0;

            Pieces = new Stack<Piece>(startingPieces);
            InGamePieces = new List<Piece>(startingPieces);

            InitializePieces();
        }

        public void UpdateNumberOfPieces()
        {
            NumPices = Pieces.Count + InGamePieces.Count;
        }

        /// <summary>
        /// Initializes the pieces with the Id of the player
        /// </summary>
        private void InitializePieces()
        {
            for (int i = 0; i < startingPieces; i++)
            {
                Pieces.Push(new Piece(PlayerId));
            }
        }

        /// <summary>
        /// Checks if the player can chose to place a new piece in game with the given rollValue
        /// </summary>
        /// <returns>True / False</returns>
        public bool CheckValidPlacement(int rollVal)
        {
            foreach (Piece piece in InGamePieces)
            {
                // If the player already has a piece in the house he would place the new one
                // Don't give him the choice
                if (piece.InGameHouse == rollVal)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
