using GameConsoleUI;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammonApp
{
    class GameManager
    {
        private GameUI gameUI = new GameUI();
        private Player playerOne = new Player(ePlayerType.PlayerOne, ePlayerColor.White);
        private Player playerTwo = new Player(ePlayerType.PlayerTwo, ePlayerColor.Blue);
        private GameBoard gameLogic;

        public GameManager()
        {
            gameLogic = new GameBoard(playerOne, playerTwo);
        }

        public void Run()
        {
            gameUI.DrawBoard(gameLogic.Board);
        }
    }
}
