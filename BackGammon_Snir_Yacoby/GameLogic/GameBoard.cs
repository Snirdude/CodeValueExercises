using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameBoard
    {
        private BasePlayer playerOne, playerTwo;
        public PieceOnBoard[,] Board { get; private set; } = new PieceOnBoard[2, 12];
        public bool HasGameEnded { get; private set; } = false;

        public GameBoard(BasePlayer playerOne, BasePlayer playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            Board[0, 0] = new PieceOnBoard(playerOne, 2);
            Board[0, 5] = new PieceOnBoard(playerTwo, 5);
            Board[0, 7] = new PieceOnBoard(playerTwo, 3);
            Board[0, 11] = new PieceOnBoard(playerOne, 5);
            Board[1, 11] = new PieceOnBoard(playerTwo, 5);
            Board[1, 7] = new PieceOnBoard(playerOne, 3);
            Board[1, 5] = new PieceOnBoard(playerOne, 5);
            Board[1, 0] = new PieceOnBoard(playerTwo, 2);
        }

        public void CheckForWinners()
        {
            HasGameEnded = playerOne.CheckWinner() || playerTwo.CheckWinner();
        }

        public bool CheckForAnyLegalMoves(BasePlayer player, int[] dices, bool isDouble)
        {
            int legalMovesCount = 0;
            PieceOnBoard[,] boardSimulator = (PieceOnBoard[,])Board.Clone();
            bool answer = false, legalMove;

            if (!isDouble)
            {
                legalMove = CheckForOneLegalMove(boardSimulator, player, dices[0]);
                if (legalMove)
                {
                    legalMovesCount++;
                }

                legalMove = CheckForOneLegalMove(boardSimulator, player, dices[1]);
                if (legalMovesCount == 1 && legalMove)
                {
                    legalMovesCount++;
                }

                if (legalMovesCount == 1 && legalMove)
                {
                    legalMove = CheckForOneLegalMove(boardSimulator, player, dices[0]);
                    legalMovesCount++;
                }

                if (legalMovesCount == 2)
                {
                    answer = true;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (CheckForOneLegalMove(boardSimulator, player, dices[0]))
                    {
                        legalMovesCount++;
                    }
                }

                if (legalMovesCount == 4)
                {
                    answer = true;
                }
            }

            return answer;
        }

        private bool CheckForOneLegalMove(PieceOnBoard[,] board, BasePlayer player, int roll)
        {
            bool legalMove = false;

            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (board[i - 1, j - 1].Player == player)
                    {
                        legalMove = player.MakeMove(board, roll, i, j);
                        if (legalMove)
                        {
                            break;
                        }
                    }
                }

                if (legalMove)
                {
                    break;
                }
            }

            return legalMove;
        }
    }
}
