using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class HumanPlayer : BasePlayer
    {
        public HumanPlayer(ePlayerType type) : base(type) { }

        public override bool MakeMove(PieceOnBoard[,] board, int roll, int fromRow, int fromCol)
        {
            bool isLegal;

            if (EatenPieces > 0)
            {
                isLegal = CheckMoveLegality(board, roll);
                if (isLegal)
                {
                    if (Type == ePlayerType.PlayerOne)
                    {
                        MovePiece(board, roll, 0, -1);
                    }
                    else
                    {
                        MovePiece(board, roll, 1, -1);
                    }
                }
            }
            else
            {
                fromRow--;
                fromCol--;
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
