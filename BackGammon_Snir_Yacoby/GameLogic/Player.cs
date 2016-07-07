using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public enum ePlayerType
    {
        PlayerOne,
        PlayerTwo,
    }

    public class Player
    {
        public ePlayerType Type { get; private set; }
        public int OnBoardPieces { get; private set; } = 15;
        public int EatenPieces { get; private set; } = 0;
        public bool ReadyToClear { get; private set; } = false;

        public Player(ePlayerType type)
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

        public bool CheckWinner()
        {
            return OnBoardPieces == 0 && EatenPieces == 0;
        }
    }
}
