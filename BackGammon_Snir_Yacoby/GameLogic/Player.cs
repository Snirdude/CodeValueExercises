using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public enum ePlayerColor
    {
        Blue,
        White
    }

    public enum ePlayerType
    {
        PlayerOne,
        PlayerTwo,
    }

    public class Player
    {
        public ePlayerType Type { get; private set; }
        public ePlayerColor Color { get; private set; }
        public int OnBoardPieces { get; private set; } = 15;
        public int EatenPieces { get; private set; } = 0;

        public Player(ePlayerType type, ePlayerColor color)
        {
            Type = type;
            Color = color;
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
    }
}
