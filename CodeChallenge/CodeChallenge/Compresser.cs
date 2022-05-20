using System.Text.RegularExpressions;

namespace CodeChallenge
{
    public class Compresser
    {

        /// <summary>
        /// Compress a string replacing the duplicated chars by a number that specify how many duplicated chars are.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>compressed input</returns>
        /// <exception cref="Exception">Not alphabetic input</exception>
        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (!IsValid(input))
            {
                throw new Exception("Only Alphabetic characters are available");
            }

            string result = string.Empty;

            char currentLetter = input.FirstOrDefault();
            int counter = 0;

            foreach (char item in input)
            {
                if (currentLetter == item)
                {
                    counter++;
                }
                else
                {
                    result = Concat(result, currentLetter, counter);
                    counter = 1;
                    currentLetter = item;
                }
            }

            result = Concat(result, currentLetter, counter);

            return result;
        }

        private static string Concat(string result, char currentLetter, int counter)
        {
            result += currentLetter;
            if (counter > 1)
            {
                result += counter;
            }

            return result;
        }

        private static bool IsValid(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
    }
}