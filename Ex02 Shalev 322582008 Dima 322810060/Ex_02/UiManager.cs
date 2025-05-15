using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;


namespace Ex_02
{
    public class UiManager
    {
        private int m_NumberOfGuesses;

        public UiManager()
        {
            m_NumberOfGuesses = GetGuessesNumber();
        }
        public int GetNumberOfGuesses()
        {
            return m_NumberOfGuesses;
        }
        public void SetNumberOfGuesses(int numberOfGuesses)
        {
            m_NumberOfGuesses = numberOfGuesses;
        }

        public void quitGame()
        {
            Console.WriteLine("Goodbye!");
        }

        public void PrintGame(Result[] i_Results, Guess[] i_UserGuesses, bool i_PrintEmptyBoard)
        {
            Ex02.ConsoleUtils.Screen.Clear();

            Console.WriteLine("Current board status:\n");
            Console.WriteLine(" Pins:           Result:");

            for (int i = 0; i < m_NumberOfGuesses; i++)
            {
                Console.Write("|");

                // Print guess for this row, if available and we're not printing an empty board
                if (!i_PrintEmptyBoard && i < i_UserGuesses.Length && i_UserGuesses[i] != null)
                {
                    string guess = i_UserGuesses[i].GuessValue;
                    foreach (char character in guess)
                    {
                        Console.Write($" {character} ");
                    }

                    for (int j = guess.Length; j < 4; j++)
                    {
                        Console.Write("   ");
                    }
                }
                else
                {
                    Console.Write("   ".PadRight(4 * 3));
                }

                Console.Write("|    |");

                // Print result for this row, if available and we're not printing an empty board
                if (!i_PrintEmptyBoard && i < i_Results.Length && i_Results[i] != null)
                {
                    string result = i_Results[i].ResultValue;
                    foreach (char character in result)
                    {
                        Console.Write($" {character} ");
                    }

                    for (int j = result.Length; j < 4; j++)
                    {
                        Console.Write("   ");
                    }
                }
                else
                {
                    Console.Write("   ".PadRight(4 * 3));
                }

                Console.WriteLine("|");
                Console.WriteLine("-----------------------------");
            }

            Console.WriteLine("Please type your next guess (A B C D E F G H) or 'Q' to quit:");
        }


        public int GetGuessesNumber()
        {
            Console.WriteLine("Please enter the number of guesses you want to have (4-10):");

            string input = Console.ReadLine();
            int numberOfGuesses;

            while (!int.TryParse(input, out numberOfGuesses) || numberOfGuesses < 4 || numberOfGuesses > 10)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10:");
                input = Console.ReadLine();
            }

            return numberOfGuesses;
        }

        public void invalidInput()
        {
            Console.WriteLine("Invalid input. Please enter a valid word.");
        }

        public bool gamIsDone(bool gameIsWon)
        {
            if (gameIsWon)
            {
                Console.WriteLine("Congratulations! You won the game!");
            }
            else
            {
                Console.WriteLine("Game over. You lost!");
            }

            while (true)
            {
                Console.WriteLine("Press Enter to play again or 'q' to quit:");
                string input = Console.ReadLine();

                if (input == "")
                {
                    return true; // Player wants to continue playing
                }
                else if (input.ToLower() == "q")
                {
                    Console.WriteLine("Goodbye!");
                    return false; // Player wants to quit
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
       

    }
}
