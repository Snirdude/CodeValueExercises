using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public enum ePlayerType
    {
        PlayerOne,
        PlayerTwo
    }

    public abstract class BasePlayer
    {
        public ePlayerType Type { get; private set; }
        public int OnBoardPieces { get; private set; } = 15;
        public int EatenPieces { get; private set; } = 0;
        public bool ReadyToClear { get; private set; } = false;

        public BasePlayer(ePlayerType type)
        {
            Type = type;
        }

        public void Eaten()
        {
            OnBoardPieces--;
            EatenPieces++;
        }

        public void Saved()
        {
            OnBoardPieces++;
            EatenPieces--;
        }

        public void Cleared()
        {
            OnBoardPieces--;
        }

        public void CanStartClearing()
        {
            ReadyToClear = true;
        }

        public void StopClearing()
        {
            ReadyToClear = false;
        }

        public bool CheckWinner()
        {
            return OnBoardPieces == 0 && EatenPieces == 0;
        }

        public int RollDice()
        {
            return new Random().Next(1, 7);
        }

        public int[] RollDices(out bool isDouble)
        {
            int[] dices = new int[2];
            Random roller = new Random();

            dices[0] = roller.Next(1, 7);
            dices[1] = roller.Next(1, 7);
            isDouble = dices[0] == dices[1];

            return dices;
        }

        public abstract bool MakeMove(PieceOnBoard[,] board, int roll, int fromRow, int fromCol);

        protected void MovePiece(PieceOnBoard[,] board, int roll, int rowIndex, int colIndex)
        {
            if (colIndex != -1)
            {
                board[rowIndex, colIndex].ChangeCount(false);
            }
            else
            {
                Saved();
            }

            GameServices.ChangeIndexes(this, roll, ref rowIndex, ref colIndex);

            if (colIndex < 0) // Player is clearing pieces
            {
                Cleared();
            }
            else if (board[rowIndex, colIndex].Count != 0 && board[rowIndex, colIndex].Player.Type != Type) // Player is eating other player's piece
            {
                board[rowIndex, colIndex].Player.Eaten();
                board[rowIndex, colIndex] = new PieceOnBoard(this, 1);
            }
            else if (board[rowIndex, colIndex].Count != 0) // There are pieces of the player
            {
                board[rowIndex, colIndex].ChangeCount(true);
            }
            else  // No pieces there
            {
                board[rowIndex, colIndex] = new PieceOnBoard(this, 1);
            }
        }

        //For eaten pieces
        internal bool CheckMoveLegality(PieceOnBoard[,] board, int roll)
        {
            bool isLegal;
            PieceOnBoard piece;

            if (Type == ePlayerType.PlayerOne)
            {
                piece = board[0, roll - 1];
            }
            else
            {
                piece = board[1, roll - 1];
            }

            isLegal = piece.Count == 0;
            isLegal |= piece.Player?.Type == Type;
            isLegal |= piece.Player?.Type != Type && piece.Count == 1;

            Debug.WriteLine($"Eaten check move legality: {isLegal}");

            return isLegal;
        }

        //For uneaten pieces
        internal bool CheckMoveLegality(PieceOnBoard[,] board, int roll, int rowIndex, int colIndex)
        {
            bool isLegal;

            isLegal = CheckPieceExists(board, rowIndex, colIndex);
            isLegal &= CheckPlayerMatch(board, rowIndex, colIndex);
            isLegal &= CheckValidTargetSpace(board, roll, rowIndex, colIndex);

            return isLegal;
        }

        internal bool CheckValidTargetSpace(PieceOnBoard[,] board, int roll, int rowIndex, int colIndex)
        {
            bool isValid, subValid;
            PieceOnBoard piece;

            GameServices.ChangeIndexes(this, roll, ref rowIndex, ref colIndex);
            if (ReadyToClear)
            {
                isValid = !(rowIndex > 1 || rowIndex < 0 || colIndex > 11 || colIndex < -6);
            }
            else
            {
                isValid = !(rowIndex > 1 || rowIndex < 0 || colIndex > 11 || colIndex < 0);
            }

            if (colIndex >= 0)
            {
                piece = board[rowIndex, colIndex];
                subValid = piece.Count == 0;
                subValid |= piece.Player?.Type == Type;
                subValid |= piece.Player?.Type != Type && piece.Count == 1;
                isValid &= subValid;
            }

            Debug.WriteLine($"Valid target space: {isValid}");
            return isValid;
        }

        private bool CheckPlayerMatch(PieceOnBoard[,] board, int rowIndex, int colIndex)
        {
            bool match = board[rowIndex, colIndex].Player?.Type == Type;

            Debug.WriteLine($"Check player match: {match}");

            return match;
        }

        private bool CheckPieceExists(PieceOnBoard[,] board, int rowIndex, int colIndex)
        {
            bool pieceExists = board[rowIndex, colIndex].Count > 0;

            Debug.WriteLine($"Check piece exists: {pieceExists}");

            return pieceExists;
        }
    }
}
