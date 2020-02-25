using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_opj_prog
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe run = new TicTacToe(); //här instanserar vi tictactoe klassen
            run.StartGame(); //Metoden med den deklarerade och instansierar variablerna (board, player1, player2, currentplayer)

            
        }
    }

}
