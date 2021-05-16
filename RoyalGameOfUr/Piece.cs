using System;
using System.Collections.Generic;
using System.Text;

namespace Royal_Game_of_Ur
{
    public class Piece
    {
        public int PlayerId { get; private set; }

        public char Sprite { get; private set; }

        public int InGameHouse { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Piece(int id)
        {
            PlayerId = id;

            Sprite = PlayerId == 1 ? 'O' : 'T';

            InGameHouse = 0;
        }
    }
}
