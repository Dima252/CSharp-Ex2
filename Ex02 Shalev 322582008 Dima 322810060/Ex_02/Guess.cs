using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class Guess
    {
        public string GuessValue { get; set; }
        public Guess()
        {
            GuessValue = Console.ReadLine();
        }
        
        public bool WordIsQuit()
        {
            bool isQuit = false;
            if (GuessValue.ToUpper() == "Q")
            {
                isQuit = true;
            }
            return isQuit;
        }

        public bool IsValidWord()
        {
            if (GuessValue.Length != 4)
            {
                return false;
            }

            int[] countEachAppearance = new int[8];
            string wordInUpperCase = GuessValue.ToUpper();

            foreach (char character in wordInUpperCase)
            {
                if (character < 'A' || character > 'H')
                {
                    return false; // invalid character
                }

                int index = character - 'A';
                countEachAppearance[index]++;

                if (countEachAppearance[index] > 1)
                {
                    return false; // duplicate character
                }
            }

            return true;
        }

    }
}
