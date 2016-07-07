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
        private Player playerOne, playerTwo;
        public PieceOnBoard[,] Board { get; private set; } = new PieceOnBoard[2, 12];
        public bool HasGameEnded { get; private set; } = false;

        public GameBoard(Player playerOne, Player playerTwo)
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

        public int RollDice()
        {
            return new Random().Next(1, 6);
        }

        public int[] RollDices(out bool isDouble)
        {
            int[] dices = new int[2];
            Random roller = new Random();

            dices[0] = roller.Next(1, 6);
            dices[1] = roller.Next(1, 6);
            isDouble = dices[0] == dices[1];

            return dices;
        }

        public bool MakeMove(Player player, int roll, int fromRow, int fromCol)
        {
            bool isLegal;

            if (player.EatenPieces > 0)
            {
                isLegal = CheckMoveLegality(player, roll);
                if (isLegal)
                {
                    if(player.Type == ePlayerType.PlayerOne)
                    {
                        MovePiece(player, roll, 0, -1);
                    }
                    else
                    {
                        MovePiece(player, roll, 1, -1);
                    }
                }
            }
            else
            {
                fromRow--;
                fromCol--;
                isLegal = CheckMoveLegality(player, roll, fromRow, fromCol);
                if (isLegal)
                {
                    MovePiece(player, roll, fromRow, fromCol);
                    HasGameEnded = CheckForWinners();
                }
            }

            return isLegal;
        }

        private bool CheckForWinners()
        {
            return playerOne.CheckWinner() || playerTwo.CheckWinner();
        }

        private void MovePiece(Player player, int roll, int rowIndex, int colIndex)
        {
            if(colIndex != -1)
            {
                Board[rowIndex, colIndex].ChangeCount(false);
            }
            else
            {
                player.Saved();
            }

            ChangeIndexes(player, roll, ref rowIndex, ref colIndex);

            if(colIndex < 0) // Player is clearing pieces
            {
                player.Cleared();
            }
            else if (Board[rowIndex, colIndex].Count != 0 && Board[rowIndex, colIndex].Player.Type != player.Type) // Player is eating other player's piece
            {
                Board[rowIndex, colIndex].Player.Eaten();
                Board[rowIndex, colIndex] = new PieceOnBoard(player, 1);
            }
            else if (Board[rowIndex, colIndex].Count != 0) // There are pieces of the player
            {
                Board[rowIndex, colIndex].ChangeCount(true);
            }
            else  // No pieces there
            {
                Board[rowIndex, colIndex] = new PieceOnBoard(player, 1);
            }
        }

        //Calculating indexes after roll of the dice
        private void ChangeIndexes(Player player, int roll, ref int rowIndex, ref int colIndex)
        {
            Debug.WriteLine($"Player: {player.Type}");
            Debug.WriteLine($"Roll: {roll}");
            Debug.WriteLine($"Indexes before change: row {rowIndex}, col {colIndex}");
            if(player.Type == ePlayerType.PlayerOne)
            {
                if(rowIndex == 0)
                {
                    if(colIndex + roll > 11)
                    {
                        colIndex = 11 - (colIndex + roll) % 12;
                        rowIndex++;
                    }
                    else
                    {
                        colIndex += roll;
                    }
                }
                else
                {
                    colIndex -= roll;
                }
            }
            else
            {
                if (rowIndex == 1)
                {
                    if (colIndex + roll > 11)
                    {
                        colIndex = 11 - (colIndex + roll) % 12;
                        rowIndex--;
                    }
                    else
                    {
                        colIndex += roll;
                    }
                }
                else
                {
                    colIndex -= roll;
                }
            }

            Debug.WriteLine($"Indexes after change: row {rowIndex}, col {colIndex}");
        }

        //For eaten pieces
        private bool CheckMoveLegality(Player player, int roll)
        {
            bool isLegal;
            PieceOnBoard piece;

            if(player.Type == ePlayerType.PlayerOne)
            {
                piece = Board[0, roll];
            }
            else
            {
                piece = Board[1, roll];
            }

            isLegal = piece.Count == 0;
            isLegal |= piece.Player?.Type == player.Type;
            isLegal |= piece.Player?.Type != player.Type && piece.Count == 1;

            Debug.WriteLine($"Eaten check move legality: {isLegal}");

            return isLegal;
        }

        //For uneaten pieces
        private bool CheckMoveLegality(Player player, int roll, int rowIndex, int colIndex)
        {
            bool isLegal;

            isLegal = CheckPieceExists(rowIndex, colIndex);
            isLegal &= CheckPlayerMatch(player, rowIndex, colIndex);
            isLegal &= CheckValidTargetSpace(player, roll, rowIndex, colIndex);

            return isLegal;
        }

        private bool CheckValidTargetSpace(Player player, int roll, int rowIndex, int colIndex)
        {
            bool isValid, subValid;
            PieceOnBoard piece;

            ChangeIndexes(player, roll, ref rowIndex, ref colIndex);
            if (player.ReadyToClear)
            {
                isValid = !(rowIndex > 1 || rowIndex < 0 || colIndex > 11 || colIndex < -6);
            }
            else
            {
                isValid = !(rowIndex > 1 || rowIndex < 0 || colIndex > 11 || colIndex < 0);
            }

            if(colIndex >= 0)
            {
                piece = Board[rowIndex, colIndex];
                subValid = piece.Count == 0;
                subValid |= piece.Player?.Type == player.Type;
                subValid |= piece.Player?.Type != player.Type && piece.Count == 1;
                isValid &= subValid;
            }

            Debug.WriteLine($"Valid target space: {isValid}");
            return isValid;
        }

        private bool CheckPlayerMatch(Player player, int rowIndex, int colIndex)
        {
            bool match = Board[rowIndex, colIndex].Player.Type == player.Type;

            Debug.WriteLine($"Check player match: {match}");

            return match;
        }

        private bool CheckPieceExists(int rowIndex, int colIndex)
        {
            bool pieceExists = Board[rowIndex, colIndex].Count > 0;

            Debug.WriteLine($"Check piece exists: {pieceExists}");

            return pieceExists;
        }
    }
}
