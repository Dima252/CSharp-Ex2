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

        public void PrintGame(Result i_Result, Guess i_WordFromUser, int i_NumberOfIteration, bool i_printEmptyBoard)
        {

            string Result = "";
            string WordFromUser = "";

            if (i_printEmptyBoard != true)
            {
                Result = i_Result.ResultValue;
                WordFromUser = i_WordFromUser.GuessValue;
            }

            Ex02.ConsoleUtils.Screen.Clear();

            Console.WriteLine("Current board status:\n");
            Console.WriteLine(" Pins:           Result:");

            for (int i = 0; i < m_NumberOfGuesses; i++)
            {
                Console.Write("|");

                // Print current guess or empty row
                if (i == i_NumberOfIteration)
                {
                    foreach (char character in WordFromUser)
                    {
                        Console.Write($" {character} ");
                    }
                    for (int j = WordFromUser.Length; j < 4; j++)
                    {
                        Console.Write("   ");
                    }
                }
                else
                {
                    Console.Write("   ".PadRight(4 * 3));
                }

                Console.Write("|    |");

                // Print result for current guess or empty
                if (i == i_NumberOfIteration)
                {
                    foreach (char character in Result)
                    {
                        Console.Write($" {character} ");
                    }
                    for (int j = Result.Length; j < 4; j++)
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

            Console.WriteLine("Please type your next guess (A B C D) or 'Q' to quit:");
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
    }
}
