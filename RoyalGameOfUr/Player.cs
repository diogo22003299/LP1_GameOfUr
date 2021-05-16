using System;
using System.Collections.Generic;
using System.Text;

namespace Royal_Game_of_Ur
{
    /// <summary>
    /// This class determines the players and their statistics
    /// </summary>
    public class Player
    {
        private const int startingPieces = 7;
        /** \brief Stores the player ID*/
        public int PlayerId { get; private set; }
        /** \brief Number of pieces left of the player*/
        public int NumPieces { get; private set; }
        /** \brief Statistic of the player's complete pieces*/
        public int CompletedPieces { get; set; }
        /** \brief Stack of the pieces*/
        public Stack<Piece> Pieces { get; set; }
        /** \brief List of the pieces*/
        public List<Piece> InGamePieces { get; set; }

        public Player(int playerId)
        {
            PlayerId = playerId;
            NumPieces = startingPieces;
            CompletedPieces = 0;

            Pieces = new Stack<Piece>(startingPieces);
            InGamePieces = new List<Piece>(startingPieces);

            InitializePieces();
        }

        /// <summary>
        /// Updates the number of pieces of each player
        /// </summary>
        public void UpdateNumberOfPieces()
        {
            NumPieces = Pieces.Count + InGamePieces.Count;
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
