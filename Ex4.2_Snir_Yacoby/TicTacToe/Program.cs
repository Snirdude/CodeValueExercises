using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Player1Turn = true;
            TicTacToeGame game = new TicTacToeGame();
            string[] input;
            int row, col;
            bool isLegalMove = true;

            while (!game.isGameOver)
            {
                if (isLegalMove)
                {
                    Console.Clear();
                    game.ShowBoard();
                }
                
                if (Player1Turn)
                {
                    Console.Write("\nPlayer 1, enter row and col seperated by comma: ");
                }
                else
                {
                    Console.Write("\nPlayer 2, enter row and col seperated by comma: ");
                }

                input = Console.ReadLine().Trim().Split(',');
                if(input.Length == 2)
                {
                    if(int.TryParse(input[0].Trim(), out row) && int.TryParse(input[1].Trim(), out col))
                    {
                        // Turn row and col to index
                        row--;
                        col--;

                        if (Player1Turn)
                        {
                            isLegalMove = game.SetMove(row, col, eCellType.X);  
                        }
                        else
                        {
                            isLegalMove = game.SetMove(row, col, eCellType.O);
                        }

                        if (isLegalMove)
                        {
                            Player1Turn = !Player1Turn;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid row and/or col");
                        isLegalMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount of inputs");
                    isLegalMove = false;
                }
            }

            Console.Clear();
            game.ShowBoard();
            Console.WriteLine("Game Over");
        }
    }
}
