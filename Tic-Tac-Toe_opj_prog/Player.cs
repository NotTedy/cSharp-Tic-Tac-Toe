using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_opj_prog
{
    class Player
    {
        public enum Piece { E, X, O };
        public Piece PlayerPiece { get; private set; }

        public Player(Player.Piece piece)
        {
            PlayerPiece = piece;

        }
    }
}
