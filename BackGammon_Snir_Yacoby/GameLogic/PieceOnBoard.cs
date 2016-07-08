﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public struct PieceOnBoard
    {
        public BasePlayer Player { get; private set; }
        public int Count { get; private set; }

        public PieceOnBoard(BasePlayer player = null, int count = 0)
        {
            Player = player;
            Count = count;
        }

        public void ChangeCount(bool raise)
        {
            if (raise)
            {
                Count++;
            }
            else
            {
                Count--;
            }
        }
    }
}
