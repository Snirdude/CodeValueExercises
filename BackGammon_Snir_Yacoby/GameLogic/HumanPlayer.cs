using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class HumanPlayer : BasePlayer
    {
        public HumanPlayer(ePlayerType type, int onBoardPieces = 15, int eatenPieces = 0, bool readyToClear = false) : base(type, onBoardPieces, eatenPieces, readyToClear) { }

        public override object Clone()
        {
            return new HumanPlayer(Type, OnBoardPieces, EatenPieces, ReadyToClear);
        }

        public override bool MakeMove(PieceOnBoard[,] board, int roll, int fromRow, int fromCol)
        {
            bool isLegal;

            fromRow--;
            fromCol--;
            if (EatenPieces > 0)
            {
                isLegal = CheckMoveLegality(board, roll);
                if (isLegal)
                {
                    if (Type == ePlayerType.PlayerOne)
                    {
                        MovePiece(board, roll, fromRow, fromCol);
                    }
                    else
                    {
                        MovePiece(board, roll, fromRow, fromCol);
                    }
                }
            }
            else
            {
                isLegal = CheckMoveLegality(board, roll, fromRow, fromCol);
                if (isLegal)
                {
                    MovePiece(board, roll, fromRow, fromCol);
                }
            }

            return isLegal;
        }
    }
}
