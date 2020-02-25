using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_opj_prog
{
    class Square
    {
        // we have created a constructor that recieves an argument
        // the argument is retrived from the Player -class
        // we have given the property "CurrentPiece" the value of "E" -this is done within the "square"-constructor

        public Player.Piece CurrentPiece { get; set; }

        public Square(Player.Piece empty)
        {
            CurrentPiece = empty; 
        }
    }
}
