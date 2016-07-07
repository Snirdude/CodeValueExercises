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
        private Player playerOne = new Player(ePlayerType.PlayerOne);
        private Player playerTwo = new Player(ePlayerType.PlayerTwo);
        private GameBoard gameBoard;

        public GameManager()
        {
            gameBoard = new GameBoard(playerOne, playerTwo);
        }

        public void Run()
        {
            bool playerOneFirst, isDouble;

            playerOneFirst = gameUI.RunOpeningSequence(gameBoard.RollDice);
            while (!gameBoard.HasGameEnded)
            {
                gameUI.ClearScreen();
                gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
                gameUI.PromptUserForRolls(playerOneFirst);
                int[] dices = gameBoard.RollDices(out isDouble);
                gameUI.DrawDices(dices[0], dices[1]);
                if (isDouble)
                {
                    gameUI.PrintDoubleMessage();
                    MakeDoubleMoves(dices, playerOneFirst);
                }
                else
                {
                    MakeMoves(dices, playerOneFirst);
                }
                
                playerOneFirst = !playerOneFirst;
            }
        }

        private void MakeDoubleMoves(int[] dices, bool playerOneFirst)
        {
            int row, col;
            bool legalMove;
            Player player;

            if (playerOneFirst)
            {
                player = playerOne;
            }
            else
            {
                player = playerTwo;
            }

            do
            {
                gameUI.WaitForPlayerMove(player, out row, out col);
                if (playerOneFirst)
                {
                    legalMove = gameBoard.MakeMove(playerOne, dices[0], row, col); 
                }
                else
                {
                    legalMove = gameBoard.MakeMove(playerTwo, dices[0], row, col);
                }
            }
            while (!legalMove);

            for(int i = 0; i < 3; i++)
            {
                do
                {
                    gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
                    gameUI.WaitForPlayerMove(player, out row, out col);
                    if (playerOneFirst)
                    {
                        legalMove = gameBoard.MakeMove(playerOne, dices[0], row, col);
                    }
                    else
                    {
                        legalMove = gameBoard.MakeMove(playerTwo, dices[0], row, col);
                    }
                }
                while (!legalMove);
            }
        }

        private void MakeMoves(int[] dices, bool playerOneFirst)
        {
            int row, col;
            bool legalMove, firstDiceSelected;
            Player player;

            if(playerOneFirst)
            {
                player = playerOne;
            }
            else
            {
                player = playerTwo;
            }

            do
            {
                firstDiceSelected = gameUI.WaitForPlayerMove(player, dices[0], dices[1], out row, out col);
                if (playerOneFirst)
                {
                    if (firstDiceSelected)
                    {
                        legalMove = gameBoard.MakeMove(playerOne, dices[0], row, col);
                    }
                    else
                    {
                        legalMove = gameBoard.MakeMove(playerOne, dices[1], row, col);
                    }
                }
                else
                {
                    if (firstDiceSelected)
                    {
                        legalMove = gameBoard.MakeMove(playerTwo, dices[0], row, col);
                    }
                    else
                    {
                        legalMove = gameBoard.MakeMove(playerTwo, dices[1], row, col);
                    }
                }
            }
            while (!legalMove);

            gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
            do
            {
                gameUI.WaitForPlayerMove(player, out row, out col);
                if (playerOneFirst)
                {
                    if (!firstDiceSelected)
                    {
                        legalMove &= gameBoard.MakeMove(playerOne, dices[0], row, col);
                    }
                    else
                    {
                        legalMove &= gameBoard.MakeMove(playerOne, dices[1], row, col);
                    }
                }
                else
                {
                    if (!firstDiceSelected)
                    {
                        legalMove &= gameBoard.MakeMove(playerTwo, dices[0], row, col);
                    }
                    else
                    {
                        legalMove &= gameBoard.MakeMove(playerTwo, dices[1], row, col);
                    }
                }
            }
            while (!legalMove);
        }
    }
}
