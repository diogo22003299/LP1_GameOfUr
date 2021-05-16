namespace Royal_Game_of_Ur
{
    public struct Tile
    {
        /** \brief The default sprite of the board tiles*/
        public char DefaultSprite { get; set; }
        /** \brief The id of the individual board tiles*/
        public int Id { get; set; }
        /** \brief Check if the tile is a lotus tile or not*/
        public bool IsLotus { get; set; }
        /** \brief Check where the piece is*/
        public Piece Piece { get; set; }
    }
}
