using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum eCellType
    {
        Empty,
        X,
        O
    };

    class TicTacToeGame
    {
        private eCellType[,] m_GameBoard;
        private bool m_GameOver;

        public TicTacToeGame()
        {
            m_GameBoard = new eCellType[3, 3];
            m_GameOver = false;
        }

        public bool isGameOver
        {
            get
            {
                return m_GameOver;
            }
        }

        public void ShowBoard()
        {
            string hr = "-----------";

            Console.WriteLine(hr);
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    switch (m_GameBoard[i,j])
                    {
                        case eCellType.X:
                            Console.Write(" X ");
                            break;
                        case eCellType.O:
                            Console.Write(" O ");
                            break;
                        case eCellType.Empty:
                            Console.Write("   ");
                            break;
                    }
                    
                    if(j < 2)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();
                Console.WriteLine(hr);
            }
        }

        public bool SetMove(int i_Row, int i_Col, eCellType i_Value)
        {
            bool isLegalMove = false;

            if(i_Row >= 0 && i_Row < 3 && i_Col >= 0 && i_Col < 3 && i_Value != eCellType.Empty)
            {
                if(m_GameBoard[i_Row, i_Col] == eCellType.Empty)
                {
                    m_GameBoard[i_Row, i_Col] = i_Value;
                    checkGameOver();
                    isLegalMove = true;
                }
                else
                {
                    Console.WriteLine("Cell occupied");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            return isLegalMove;
        }

        private void checkGameOver()
        {
            int countOccupiedCells = 0;
            int countX = 0;
            int countO = 0;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(m_GameBoard[i,j] == eCellType.X)
                    {
                        countX++;
                        countOccupiedCells++;
                    }
                    else if (m_GameBoard[i,j] == eCellType.O)
                    {
                        countO++;
                        countOccupiedCells++;
                    }
                }
                
                if(countX == 3 || countO == 3)
                {
                    m_GameOver = true;
                    return;
                }

                countO = 0;
                countX = 0;
            }

            if (countOccupiedCells == 9)
            {
                m_GameOver = true;
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m_GameBoard[j, i] == eCellType.X)
                    {
                        countX++;
                    }
                    else if (m_GameBoard[j, i] == eCellType.O)
                    {
                        countO++;
                    }
                }

                if (countX == 3 || countO == 3)
                {
                    m_GameOver = true;
                    return;
                }

                countO = 0;
                countX = 0;
            }

            for(int i = 0; i < 3; i++)
            {
                if (m_GameBoard[i, i] == eCellType.X)
                {
                    countX++;
                }
                else if (m_GameBoard[i, i] == eCellType.O)
                {
                    countO++;
                }

                if (countX == 3 || countO == 3)
                {
                    m_GameOver = true;
                    return;
                }
            }

            countO = 0;
            countX = 0;

            for (int i = 2; i >= 0; i--)
            {
                if (m_GameBoard[i, i] == eCellType.X)
                {
                    countX++;
                }
                else if (m_GameBoard[i, i] == eCellType.O)
                {
                    countO++;
                }

                if (countX == 3 || countO == 3)
                {
                    m_GameOver = true;
                    return;
                }
            }
        }
    }
}
