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

            if (!IsAlphabetic(input))
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

        /// <summary>
        /// Compress a string replacing the duplicated chars by a number that specify how many duplicated chars are.
        /// Numbers are not compressed
        /// </summary>
        /// <param name="input"></param>
        /// <returns>compressed input</returns>
        /// <exception cref="Exception">Not alphanumeric input</exception>
        public static string CompressWithNumbers(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (!IsAlphanumeric(input))
            {
                throw new Exception("Only Alphanumeric characters are available");
            }

            string result = string.Empty;

            char currentLetter = input.FirstOrDefault();
            int counter = 0;

            foreach (char item in input)
            {
                if (currentLetter == item && !char.IsDigit(item))
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

        /// <summary>
        /// Compress a string replacing the duplicated chars by a number that specify how many duplicated chars are.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>compressed input</returns>
        /// <exception cref="Exception">Not alphabetic input</exception>
        public static bool TryCompress(string input, out string? ouput)
        {
            if (string.IsNullOrEmpty(input))
            {
                ouput = input;
                return false;
            }

            if (!IsAlphabetic(input))
            {
                ouput = null;
                return false;
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

            ouput = Concat(result, currentLetter, counter);

            return true;
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

        private static bool IsAlphabetic(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        private static bool IsAlphanumeric(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }
    }
}