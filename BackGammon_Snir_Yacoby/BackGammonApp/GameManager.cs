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
                        MakeDoubleMoves(dices, playerOneFirst);
                    }
                    else
                    {
                        MakeMoves(dices, playerOneFirst);
                    }

                    

                    gameBoard.CheckForWinners();
                }

                playerOneFirst = !playerOneFirst;
            }
        }

        private void MakeDoubleMoves(int[] dices, bool playerOneFirst)
        {
            int row, col;
            bool legalMove;
            BasePlayer player;

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
                legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                if(!legalMove)
                {
                    gameUI.PrintIllegalMoveMessage();
                }
            }
            while (!legalMove);

            if (gameBoard.CheckIfPlayerCanStartClearing(player))
            {
                player.CanStartClearing();
            }
            else
            {
                player.StopClearing();
            }

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

                if (gameBoard.CheckIfPlayerCanStartClearing(player))
                {
                    player.CanStartClearing();
                }
                else
                {
                    player.StopClearing();
                }
            }
        }

        private void MakeMoves(int[] dices, bool playerOneFirst)
        {
            int row, col;
            bool legalMove, firstDiceSelected;
            BasePlayer player;

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

            if (gameBoard.CheckIfPlayerCanStartClearing(player))
            {
                player.CanStartClearing();
            }
            else
            {
                player.StopClearing();
            }

            gameUI.DrawBoard(gameBoard.Board, playerOne.EatenPieces, playerTwo.EatenPieces);
            do
            {
                gameUI.WaitForPlayerMove(player, out row, out col);
                if (playerOneFirst)
                {
                    if (!firstDiceSelected)
                    {
                        legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                    }
                    else
                    {
                        legalMove = player.MakeMove(gameBoard.Board, dices[1], row, col);
                    }
                }
                else
                {
                    if (!firstDiceSelected)
                    {
                        legalMove = player.MakeMove(gameBoard.Board, dices[0], row, col);
                    }
                    else
                    {
                        legalMove = player.MakeMove(gameBoard.Board, dices[1], row, col);
                    }
                }

                if (!legalMove)
                {
                    gameUI.PrintIllegalMoveMessage();
                }
            }
            while (!legalMove);

            if (gameBoard.CheckIfPlayerCanStartClearing(player))
            {
                player.CanStartClearing();
            }
            else
            {
                player.StopClearing();
            }
        }
    }
}
