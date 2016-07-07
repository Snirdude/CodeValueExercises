using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;
using System.Threading;

namespace GameConsoleUI
{
    public class GameUI
    {
        public void DrawBoard(PieceOnBoard[,] logicBoard, int playerOneEatenCount, int playerTwoEatenCount)
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

                if(i == 3)
                {
                    Console.Write(" 1 ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Eaten pieces: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("O");
            Console.ResetColor();
            Console.Write($": {playerOneEatenCount} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("O");
            Console.ResetColor();
            Console.WriteLine($": {playerTwoEatenCount} ");
            Console.WriteLine();

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

                if(i == 3)
                {
                    Console.Write(" 2 ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" 1  2  3  4  5  6    7  8  9  10 11 12");
            Console.WriteLine("______________________________________");
        }

        public void PrintDoubleMessage()
        {
            Console.WriteLine("Double! Play twice.");
        }

        public void AnnounceBeginner(bool playerOneFirst)
        {
            if (playerOneFirst)
            {
                Console.WriteLine("Player one goes first - Blue");
            }
            else
            {
                Console.WriteLine("Player two goes first - Red");
            }

            Thread.Sleep(3000);
        }

        private string DrawPiece(PieceOnBoard pieceOnBoard, int i)
        {
            string piece = " ";
            int pieceCount = pieceOnBoard.Count;
            bool firstLayer = pieceCount >= i;
            bool secondLayer = pieceCount >= i + 5;

            if (pieceOnBoard.Player != null && firstLayer)
            {
                if(pieceOnBoard.Player.Type == ePlayerType.PlayerOne)
                {
                    if (secondLayer)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
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
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }

                piece = "O";
            }

            return piece;
        }

        public bool WaitForPlayerMove(Player player, int rollOne, int rollTwo, out int row, out int col)
        {
            int dice;
            bool validInput;
            
            if(player.EatenPieces > 0)
            {
                string input;

                if (player.Type == ePlayerType.PlayerOne)
                {
                    row = 1;
                }
                else
                {
                    row = 2;
                }

                col = -1;
                do
                {
                    Console.WriteLine("Choose dice 1 or 2:");
                    input = Console.ReadLine().Trim();
                    validInput = int.TryParse(input, out dice);
                    validInput &= dice == 1 || dice == 2;
                }
                while (!validInput);
            }
            else
            {
                Console.WriteLine("Available rows: 1-2");
                Console.WriteLine("Available columns: 1-12");
                do
                {
                    string[] input;
                    do
                    {
                        Console.WriteLine("Choose dices 1 or 2 and enter row and col (all seperated by commas):");
                        input = Console.ReadLine().Trim().Split(',');
                        validInput = input.Length == 3;
                    }
                    while (!validInput);

                    validInput &= int.TryParse(input[0], out dice);
                    validInput &= int.TryParse(input[1], out row);
                    validInput &= int.TryParse(input[2], out col);
                    validInput &= dice == 1 || dice == 2;
                }
                while (!validInput);
            }
            
            return dice == 1;
        }

        public void WaitForPlayerMove(Player player, out int row, out int col)
        {
            bool validInput;

            if (player.EatenPieces > 0)
            {
                if (player.Type == ePlayerType.PlayerOne)
                {
                    row = 1;
                }
                else
                {
                    row = 2;
                }

                col = -1;
            }
            else
            {
                string[] input;

                Console.WriteLine("Available rows: 1-2");
                Console.WriteLine("Available columns: 1-12");
                do
                {
                    Console.WriteLine("Enter row and col (all seperated by commas):");
                    input = Console.ReadLine().Trim().Split(',');
                    validInput = input.Length == 2;
                    validInput &= int.TryParse(input[0], out row);
                    validInput &= int.TryParse(input[1], out col);
                }
                while (!validInput);
            }
        }

        public void PromptUserForRolls(bool playerOne)
        {
            if (playerOne)
            {
                Console.Write("Blues, ");
            }
            else
            {
                Console.Write("Reds, ");
            }

            Console.WriteLine("press enter to roll the dices");
            Console.ReadLine();
        }

        public void DrawDices(int rollOne, int rollTwo)
        {
            DrawDice(rollOne);
            DrawDice(rollTwo);
        }

        private void DrawDice(int roll)
        {
            switch (roll)
            {
                case 1:
                    Console.WriteLine("     ");
                    Console.WriteLine("  *  ");
                    Console.WriteLine("     ");
                    break;
                case 2:
                    Console.WriteLine("*    ");
                    Console.WriteLine("     ");
                    Console.WriteLine("    *");
                    break;
                case 3:
                    Console.WriteLine("*    ");
                    Console.WriteLine("  *  ");
                    Console.WriteLine("    *");
                    break;
                case 4:
                    Console.WriteLine("*   *");
                    Console.WriteLine("     ");
                    Console.WriteLine("*   *");
                    break;
                case 5:
                    Console.WriteLine("*   *");
                    Console.WriteLine("  *  ");
                    Console.WriteLine("*   *");
                    break;
                case 6:
                    Console.WriteLine("*   *");
                    Console.WriteLine("*   *");
                    Console.WriteLine("*   *");
                    break;
            }
            Console.WriteLine();
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
