using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public static class GameServices
    {
        //Calculating indexes after roll of the dice
        internal static void ChangeIndexes(BasePlayer player, int roll, ref int rowIndex, ref int colIndex)
        {
            Debug.WriteLine($"Player: {player.Type}");
            Debug.WriteLine($"Roll: {roll}");
            Debug.WriteLine($"Indexes before change: row {rowIndex}, col {colIndex}");
            if (player.Type == ePlayerType.PlayerOne)
            {
                if (rowIndex == 0)
                {
                    if (colIndex + roll > 11)
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
    }
}
