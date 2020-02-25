using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_opj_prog
{
    class Board
    {
        public List<Square> boardList;

        public Board()
        {
            boardList = new List<Square>();

            for (int i = 0; i <= 9; i++)
            {
                Square newsquare = new Square(Player.Piece.E);
                boardList.Add(newsquare);
            }
        }

        public List<Square> GetCurrentGameState()
        {
            return boardList;
        }

    
        public bool IsPositionAvailable(int pos)
        {
            if (pos > boardList.Count - 1 || pos < 1)
            {
                return false;
            }
            if (boardList[pos-1].CurrentPiece == Player.Piece.E) 
            {
                return true; 
            }
            else 
            {
                return false;       
            }
        }

        public void UpdateBoard(int pos, Player currentplayer)
        {
            boardList[pos-1].CurrentPiece = currentplayer.PlayerPiece;
        }
            
    }
}
