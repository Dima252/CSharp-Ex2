using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class Run
    {
        public Run()
        {
            GameLoop();
        }

        public void GameLoop()
        {
            bool continueGame = true;

            while (continueGame == true)
            {
                UiManager uiManager = new UiManager();
                int NumberOfGuesses = uiManager.GetNumberOfGuesses();
                Guess[] guesses = new Guess[NumberOfGuesses];
                Result[] results = new Result[NumberOfGuesses];
                GeneratedGuess generatedGuess = new GeneratedGuess();

                bool printEmptyBoard = true, gameIsWon = false, gameIsDone = false; // Flag to control printing the empty board

                uiManager.PrintGame(results, guesses,printEmptyBoard); // Print the initial empty board
                printEmptyBoard = false; // Set the flag to false after the first print

                for (int i = 0; i < NumberOfGuesses; i++)
                {
                    guesses[i] = new Guess();

                    if (guesses[i].WordIsQuit() == true)
                    {
                        continueGame = false;
                        uiManager.quitGame();
                        break;
                    }

                    if (guesses[i].IsValidWord() == true)
                    {
                        results[i] = new Result(guesses[i], generatedGuess);
                        uiManager.PrintGame(results, guesses, printEmptyBoard);
                        gameIsWon = results[i].GameIsWon();
                        if (gameIsWon == true || i == NumberOfGuesses - 1)
                        {
                            gameIsDone = true;
                            break;
                        }

                    }
                    else
                    {
                        uiManager.invalidInput();
                        i--; // Decrement the counter to allow for another guess
                    }

                }

                if (gameIsDone == true)
                {
                    continueGame = uiManager.gamIsDone(gameIsWon);
                }

            }

        }


    }
}
