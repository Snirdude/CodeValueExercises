using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace GameConsoleUI
{
    public class GameUI
    {
        public void DrawBoard(PieceOnBoard[,] logicBoard)
        {
            int i = 0, j = 0;
            
            Console.WriteLine("______________________________________");
            for(i = 1; i <= 5; i++)
            {
                for (j = 0; j < 6; j++)
                {
                    Console.Write("|");
                    Console.Write(DrawPiece(logicBoard[0,j], i));
                    Console.ResetColor();
                    Console.Write("|");
                }

                Console.Write("  ");
                for (; j < 12; j++)
                {
                    Console.Write("|");
                    Console.Write(DrawPiece(logicBoard[0,j], i));
                    Console.ResetColor();
                    Console.Write("|");
                }

                Console.WriteLine();
            }

            Console.WriteLine("                         ");
            for (i = 5; i >= 1; i--)
            {
                for (j = 0; j < 6; j++)
                {
                    Console.Write("|");
                    Console.Write(DrawPiece(logicBoard[1, j], i));
                    Console.ResetColor();
                    Console.Write("|");
                }

                Console.Write("  ");
                for (; j < 12; j++)
                {
                    Console.Write("|");
                    Console.Write(DrawPiece(logicBoard[1, j], i));
                    Console.ResetColor();
                    Console.Write("|");
                }

                Console.WriteLine();
            }
            Console.WriteLine("______________________________________");
        }

        private string DrawPiece(PieceOnBoard pieceOnBoard, int i)
        {
            string piece = " ";
            int pieceCount = pieceOnBoard.Count;
            bool firstLayer = pieceCount >= i;
            bool secondLayer = pieceCount >= i + 5;

            if (pieceOnBoard.Player != null && firstLayer)
            {
                if(pieceOnBoard.Player.Color == ePlayerColor.Blue)
                {
                    if (secondLayer)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }
                else
                {
                    if (secondLayer)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                piece = "O";
            }

            return piece;
        }
    }
}
