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
        private BasePlayer playerOne = new HumanPlayer(ePlayerType.PlayerOne);
        private BasePlayer playerTwo = new HumanPlayer(ePlayerType.PlayerTwo);
        private GameBoard gameBoard;

        public GameManager()
        {
            gameBoard = new GameBoard(playerOne, playerTwo);
        }

        public void Run()
        {
            bool playerOneFirst, isDouble;
            BasePlayer currentPlayer;

            playerOneFirst = gameUI.RunOpeningSequence(playerOne, playerTwo);
            while (!gameBoard.HasGameEnded)
            {
                gameUI.ClearScreen();
                gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
                gameUI.PromptUserForRolls(playerOneFirst);

                currentPlayer = playerOneFirst ? playerOne : playerTwo;

                int[] dices = currentPlayer.RollDices(out isDouble);
                gameUI.DrawDices(dices[0], dices[1]);

                if(!gameBoard.CheckForAnyLegalMoves(currentPlayer, dices, isDouble))
                {
                    gameUI.ShowCannotPlayMessage();
                }
                else
                {
                    if (isDouble)
                    {
                        gameUI.PrintDoubleMessage();
                        MakeDoubleMoves(dices, currentPlayer);
                    }
                    else
                    {
                        MakeMoves(dices, currentPlayer);
                    }

                    gameBoard.CheckForWinners();
                }

                playerOneFirst = !playerOneFirst;
            }

            if (playerOne.CheckWinner())
            {
                gameUI.PrintWinnerMessage(playerOne);
            }
            else
            {
                gameUI.PrintWinnerMessage(playerTwo);
            }
        }

        private void MakeDoubleMoves(int[] dices, BasePlayer player)
        {
            int row, col;
            bool legalMove;

            do
            {
                gameUI.WaitForPlayerMove(player, out row, out col);
                legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                if(!legalMove)
                {
                    gameUI.PrintIllegalMoveMessage();
                }
            }
            while (!legalMove);

            player.CheckAndSetIfCanStartClearing(gameBoard.Board);
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
                    gameUI.WaitForPlayerMove(player, out row, out col);
                    legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                    if (!legalMove)
                    {
                        gameUI.PrintIllegalMoveMessage();
                    }
                }
                while (!legalMove);

                player.CheckAndSetIfCanStartClearing(gameBoard.Board);
            }
        }

        private void MakeMoves(int[] dices, BasePlayer player)
        {
            int row, col;
            bool legalMove, firstDiceSelected;
            
            do
            {
                firstDiceSelected = gameUI.WaitForPlayerMove(player, dices[0], dices[1], out row, out col);
                if (firstDiceSelected)
                {
                    legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                }
                else
                {
                    legalMove = player.MakeMove(gameBoard.Board, dices[1], row, col);
                }

                if (!legalMove)
                {
                    gameUI.PrintIllegalMoveMessage();
                }
            }
            while (!legalMove);

            player.CheckAndSetIfCanStartClearing(gameBoard.Board);
            gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
            do
            {
                gameUI.WaitForPlayerMove(player, out row, out col);
                if (!firstDiceSelected)
                {
                    legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                }
                else
                {
                    legalMove = player.MakeMove(gameBoard.Board, dices[1], row, col);
                }

                if (!legalMove)
                {
                    gameUI.PrintIllegalMoveMessage();
                }
            }
            while (!legalMove);

            player.CheckAndSetIfCanStartClearing(gameBoard.Board);
        }
    }
}
