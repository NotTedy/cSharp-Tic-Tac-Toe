using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Samarbete med Anna Åman Kujampää
namespace Tic_Tac_Toe_opj_prog
{
    class TicTacToe
    {
        Board board;
        Player player1;
        Player player2;
        Player currentPlayer;


        public void StartGame()
        {
            //In this method we will iterate and ask a player  to place their piece on the board
            //This method will continue to do so untill the game can no longer be continued
            //This method will also write out the current board during each iteration so the user caan have an updated visual.

 

            //declare these instances variables
            player1 = new Player(Player.Piece.X);
            player2 = new Player(Player.Piece.O);
            board = new Board();


            //första spelaren är player1
            currentPlayer = player1;


           
            while (!CheckIfWin() || !CheckIfDraw())
            {

                Console.Clear();
                PrintBoard();

                if (currentPlayer == player1)
                {
                    Console.WriteLine("Write the position: ");
                    //int moveOne = Convert.ToInt32(Console.ReadLine());

                    bool go = true;
                    while(go)
                    {
                        int.TryParse(Console.ReadLine(), out int moveOne);
                        if (board.IsPositionAvailable(moveOne))
                        {
                            board.UpdateBoard(moveOne, currentPlayer);
                            go = false;
                        }

                        else
                        {
                            Console.WriteLine("Try again, that position is already taken!");

                        }

                    }

                }

                else
                {
                    if (CheckIfDraw() == false)
                    {
                        int moveTwo = MakeRandomAIMove();
                        if (board.IsPositionAvailable(moveTwo))
                        {
                            board.UpdateBoard(moveTwo, currentPlayer);

                        }

                    }
                   
                }


                if (CheckIfWin() == true)
                {
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine(currentPlayer.PlayerPiece + " wins");
                    break;
                }
                if (CheckIfDraw() == true)
                {

                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("its a draw!");
                    break;
                }
                ChangePlayer();



                //byter automatiks till en ny spelare så fort en spelare har gjort ett drag.
                //currentPlayer = ChangePlayer(currentPlayer);





            }

          




        }

        public void PrintBoard() //skriv ut kroppen för brädan
        {
            List<string> newList = new List<string>(); //skapar en lista med 9 platser

            int k = 1;

            for (int i = 0; i < 9; i++)
            {
                string k2 = Convert.ToString(k); // för att k inte kan skrivas i vår string-lista.
                if (board.GetCurrentGameState()[i].CurrentPiece == Player.Piece.E) // Om rutan eller indexplatsen i brädet är E (empty) så gör detta för att vis siffror ist
                {
                    newList.Add(k2);
                }
                else
                {
                    //newList.Add(Convert.ToString(board.GetCurrentGameState()[i].CurrentPiece)); // Om den inehåller X eller O så lägg in detta fast 
                    newList.Add(string.Format("{0}", board.GetCurrentGameState()[i].CurrentPiece));
                }
                k++;
            }


            Console.WriteLine(" ______________________");
            Console.WriteLine("|       |       |      |");
            Console.Write("|   " + newList[0]);
            Console.Write("   |   " + newList[1]);
            Console.WriteLine("   |   " + newList[2] + "  |");


            Console.WriteLine("|_______|_______|______|");
            Console.WriteLine("|       |       |      |");


            Console.Write("|   " + newList[3]);
            Console.Write("   |   " + newList[4]);
            Console.WriteLine("   |   " + newList[5] + "  |");


            Console.WriteLine("|_______|_______|______|");
            Console.WriteLine("|       |       |      |");

            Console.Write("|   " + newList[6]);
            Console.Write("   |   " + newList[7]);
            Console.WriteLine("   |   " + newList[8] + "  |");

            Console.WriteLine("|_______|_______|______|");


        }

        public void ChangePlayer()
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }
        }

        public bool CheckIfDraw()
        {
            List<Square> boardList = board.GetCurrentGameState();
            int count = 0;

            for (int i = 0; i < boardList.Count; i++)
            {
                if (boardList[i].CurrentPiece != Player.Piece.E)
                {
                    count++;
                }
            }
            if (count == boardList.Count -1)
            {
                return true;
            }
            return false; 
        }

        public bool CheckIfWin()
        {
            if (Horiziontal() || Vertical() || Diagonal() || AntiDiagonal())
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public bool Horiziontal()
        {
            List<Square> boardList = board.GetCurrentGameState();
            int kvadrat = Convert.ToInt32(Math.Sqrt(boardList.Count));
            int count = 0;

            for (int i = 0; i < boardList.Count; i += kvadrat) //kollar positionerna 0,3,6 
            {
                if (boardList[i].CurrentPiece == currentPlayer.PlayerPiece) //kollar om det finns ett X i ruttorna annars loopar den vidare.
                {
                    //count++;
                    for (int y = i; y < kvadrat + i; y++) //kollar om det  finns X(1,2), (4,5) , (7,8)
                    {
                        if (boardList[y].CurrentPiece == currentPlayer.PlayerPiece)
                        {
                            count++;
                        }
                    }
                }

                if (count == kvadrat)
                {
                    return true;
                }
                count = 0;
            }

            return false;
        }

        public bool Vertical()
        {
            List<Square> boardList = board.GetCurrentGameState();
            int kvadrat = Convert.ToInt32(Math.Sqrt(boardList.Count));
            int count = 0;

            for (int i = 0; i < kvadrat; i++) //kollar position 0, 1, 2
            {
                if (boardList[i].CurrentPiece == currentPlayer.PlayerPiece)
                {

                    for (int j = i; j < boardList.Count; j += kvadrat) //kollar om positon 0 = X kollar den 3, är de 4 kollar den 7
                    {

                        if (boardList[j].CurrentPiece == currentPlayer.PlayerPiece)
                        {
                            count++;
                        }

                    }
                    if (count == kvadrat)
                    {
                        return true;
                    }
                }
                count = 0;
            }

            return false;

        }

        public bool Diagonal()
        {
            List<Square> boardList = board.GetCurrentGameState();
            int kvadrat = Convert.ToInt32(Math.Sqrt(boardList.Count));
            int count = 0;
           
            for (int j = 0; j < boardList.Count; j += kvadrat + 1) //räknar position 0,4,8
            {
                if (boardList[j].CurrentPiece == currentPlayer.PlayerPiece)
                {
                    count++;
                }
                if (count == kvadrat)
                {
                    return true;
                }

            }
            return false;
        }






        public bool AntiDiagonal()
        {
            List<Square> boardList = board.GetCurrentGameState();
            int kvadrat = Convert.ToInt32(Math.Sqrt(boardList.Count));
            int count = 0;

            for (int j = kvadrat-1; j < boardList.Count - kvadrat + 1; j += kvadrat - 1)
            {
                if (boardList[j].CurrentPiece == currentPlayer.PlayerPiece)
                {
                    count++;
                }
                if (count == kvadrat)
                {
                    return true;
                }
            }
            return false;
        }


        public int MakeRandomAIMove()
        {
            List<Square> boardList = board.GetCurrentGameState();

            Random rnd = new Random();
            int choice = rnd.Next(1, boardList.Count);

            while (board.IsPositionAvailable(choice) == false)
            {
                choice = rnd.Next(1, boardList.Count);
               
            }
            return choice;
        }


    }
        
    }
  




