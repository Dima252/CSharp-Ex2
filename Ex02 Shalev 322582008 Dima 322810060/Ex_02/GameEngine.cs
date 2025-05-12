using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class GameEngine
    {

        private static readonly Random rng = new Random();
        private string m_GuessedWord;

        public GameEngine()
        {
            m_GuessedWord = GenerateUniqueFourLetterCode();
        }

        public static string GenerateUniqueFourLetterCode()
        {
            int[] usedLetters = new int[8]; // index 0 = 'A', 1 = 'B', ..., 7 = 'H'
            StringBuilder result = new StringBuilder(4);
            int lettersChosen = 0;

            while (lettersChosen < 4)
            {
                int index = rng.Next(0, 8); // Random number from 0 to 7

                if (usedLetters[index] == 0) // Not yet used
                {
                    char letter = (char)('A' + index);
                    result.Append(letter);
                    usedLetters[index]++;
                    lettersChosen++;
                }
            }

            return result.ToString(); // e.g., "CAGD"
        }

        public string CalculateResult(string i_InputByUser)
        {
            string result = string.Empty;

            int correctLettersInTheRightSpace = 0;
            int existingLetters = 0;

            foreach (char letter in i_InputByUser)
            {
                if (m_GuessedWord.Contains(letter) && (m_GuessedWord[letter - 'A'] != i_InputByUser[letter - 'A']))
                {
                    existingLetters++;
                }
            }

            for (int i = 0; i < i_InputByUser.Length; i++)
            {
                if (m_GuessedWord[i] == i_InputByUser[i])
                {
                    correctLettersInTheRightSpace++;
                }
            }

            while(correctLettersInTheRightSpace > 0)
            {
                result += "V";
                correctLettersInTheRightSpace--;
            }

            while (existingLetters > 0)
            {
                result += "X";
                existingLetters--;
            }

            return result;
        }





    }
}
