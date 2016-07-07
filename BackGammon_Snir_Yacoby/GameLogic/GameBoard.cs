using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameBoard
    {
        public PieceOnBoard[,] Board { get; private set; } = new PieceOnBoard[2, 12];

        public GameBoard(Player playerOne, Player playerTwo)
        {
            Board[0, 0] = new PieceOnBoard(playerOne, 2);
            Board[0, 5] = new PieceOnBoard(playerTwo, 5);
            Board[0, 7] = new PieceOnBoard(playerTwo, 3);
            Board[0, 11] = new PieceOnBoard(playerOne, 5);
            Board[1, 11] = new PieceOnBoard(playerTwo, 5);
            Board[1, 7] = new PieceOnBoard(playerOne, 3);
            Board[1, 5] = new PieceOnBoard(playerOne, 5);
            Board[1, 0] = new PieceOnBoard(playerTwo, 2);
        }

        public int[] RollDices()
        {
            int[] dices = new int[2];
            Random roller = new Random();

            dices[0] = roller.Next(1, 6);
            dices[1] = roller.Next(1, 6);

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
                    MovePiece(player, roll, -1, -1);
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
                }
            }

            return isLegal;
        }

        private void MovePiece(Player player, int roll, int rowIndex, int colIndex)
        {
            if(rowIndex != -1 && colIndex != -1)
            {
                Board[rowIndex, colIndex].ChangeCount(false);
            }

            ChangeIndexes(player, roll, ref rowIndex, ref colIndex);

            if (Board[rowIndex, colIndex].Count != 0 && Board[rowIndex, colIndex].Player.Type != player.Type)
            {
                Board[rowIndex, colIndex].Player.Eaten();
                Board[rowIndex, colIndex] = new PieceOnBoard(player, 1);
            }
            else if (Board[rowIndex, colIndex].Count != 0)
            {
                Board[rowIndex, colIndex].ChangeCount(true);
            }
            else
            {
                Board[rowIndex, colIndex] = new PieceOnBoard(player, 1);
            }
        }

        private void ChangeIndexes(Player player, int roll, ref int rowIndex, ref int colIndex)
        {
            if(player.Type == ePlayerType.PlayerOne)
            {
                if(rowIndex == 1)
                {
                    colIndex += roll;
                    if(colIndex > 11)
                    {
                        colIndex -= colIndex % 12;
                        rowIndex--;
                    }
                }
                else
                {
                    colIndex -= roll;
                }
            }
            else
            {
                if (rowIndex == 0)
                {
                    colIndex += roll;
                    if (colIndex > 11)
                    {
                        colIndex -= colIndex % 12;
                        rowIndex++;
                    }
                }
                else
                {
                    colIndex -= roll;
                }
            }
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
            isLegal |= piece.Player.Type == player.Type;
            isLegal |= piece.Player.Type != player.Type && piece.Count == 1;

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
            isValid = !(rowIndex > 1 || rowIndex < 0 || colIndex > 11 || colIndex < 0);
            piece = Board[rowIndex, colIndex];
            subValid = piece.Count == 0;
            subValid |= piece.Player.Type == player.Type;
            subValid |= piece.Player.Type != player.Type && piece.Count == 1;
            isValid &= subValid;

            return isValid;
        }

        private bool CheckPlayerMatch(Player player, int rowIndex, int colIndex)
        {
            return Board[rowIndex, colIndex].Player.Type == player.Type;
        }

        private bool CheckPieceExists(int rowIndex, int colIndex)
        {
            return Board[rowIndex, colIndex].Count > 0;
        }
    }
}
