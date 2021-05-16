using System;
using System.Collections.Generic;
using System.Text;

namespace Royal_Game_of_Ur
{
    class Dice
    {
        // Declare a new Random
        private readonly Random rand;

        // The number of dice
        private readonly int numDice;

        /// <summary>
        /// Dice Constructor
        /// </summary>
        public Dice()
        {
            rand = new Random();
            numDice = 4;
        }

        /// <summary>
        /// Roll The dices with chance based of the original game
        /// </summary>
        /// <returns>Rolled Value</returns>
        public int RollDice()
        {
            int roll = 0;

            for (int i = 0; i < numDice; i++)
            {
                roll += rand.NextDouble() > 0.5f ? 1 : 0;
            }

            return roll;
        }
    }
}
