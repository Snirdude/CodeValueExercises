﻿using System;
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
            /*Board[0, 0] = new PieceOnBoard(playerTwo, 14);
            Board[1, 0] = new PieceOnBoard(playerOne, 14);
            Board[1, 6] = new PieceOnBoard(playerOne, 1);
            Board[0, 6] = new PieceOnBoard(playerTwo, 1);*/
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
            PieceOnBoard[,] boardSimulator = CreateCopyOfBoard(Board);
            BasePlayer playerSimulator;
            bool answer = false, legalMove;

            Debug.WriteLine($"Board copy sucessful: {!boardSimulator.Equals(Board)}");

            //if player is Human then
            playerSimulator = new HumanPlayer(player.Type, player.OnBoardPieces, player.EatenPieces, player.ReadyToClear);
            // else player is Computer...

            if (!isDouble)
            {
                legalMove = CheckForOneLegalMove(boardSimulator, playerSimulator, dices[0]);
                if (legalMove)
                {
                    playerSimulator.CheckAndSetIfCanStartClearing(boardSimulator);
                    legalMovesCount++;
                }

                legalMove = CheckForOneLegalMove(boardSimulator, playerSimulator, dices[1]);
                if (legalMove)
                {
                    playerSimulator.CheckAndSetIfCanStartClearing(boardSimulator);
                    legalMovesCount++;
                }

                if (legalMovesCount == 1 && legalMove)
                {
                    legalMove = CheckForOneLegalMove(boardSimulator, playerSimulator, dices[0]);
                    if (legalMove)
                    {
                        playerSimulator.CheckAndSetIfCanStartClearing(boardSimulator);
                        legalMovesCount++;
                    }
                }

                Debug.WriteLine($"legalMovesCount = {legalMovesCount}");

                if (legalMovesCount == 2)
                {
                    answer = true;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (CheckForOneLegalMove(boardSimulator, playerSimulator, dices[0]))
                    {
                        playerSimulator.CheckAndSetIfCanStartClearing(boardSimulator);
                        legalMovesCount++;
                    }
                }

                if (legalMovesCount == 4)
                {
                    answer = true;
                }
            }

            if (playerSimulator.CheckWinner())
            {
                answer = true;
            }

            return answer;
        }

        private bool CheckForOneLegalMove(PieceOnBoard[,] board, BasePlayer player, int roll)
        {
            bool legalMove = false;
            bool helper;

            Debug.WriteLine($"In CheckForOneLegalMove, eaten pieces: {player.EatenPieces}");
            if(player.EatenPieces > 0)
            {
                if(player.Type == ePlayerType.PlayerOne)
                {
                    legalMove = player.MakeMove(board, roll, 1, 0);
                }
                else
                {
                    legalMove = player.MakeMove(board, roll, 2, 0);
                }
            }
            else
            {
                for (int i = 1; i <= 2; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        helper = board[i - 1, j - 1].Player?.Type == player.Type;
                        helper |= board[i - 1, j - 1].Count == 0;
                        helper |= board[i - 1, j - 1].Player?.Type != player.Type && board[i - 1, j - 1].Count == 1;
                        if (helper)
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
            }

            return legalMove;
        }

        private PieceOnBoard[,] CreateCopyOfBoard(PieceOnBoard[,] source)
        {
            PieceOnBoard[,] copy = new PieceOnBoard[2, 12];

            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    copy[i, j] = new PieceOnBoard(source[i, j]);
                }
            }

            return copy;
        }
    }
}
