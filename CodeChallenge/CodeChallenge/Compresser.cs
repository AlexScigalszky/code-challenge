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

            var stillCount = (char item, char currentLetter) => currentLetter == item;

            return ProcessTheInput(input, stillCount);
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


            var stillCount = (char item, char currentLetter) => currentLetter == item && !char.IsDigit(item);

            return ProcessTheInput(input, stillCount);
        }

        /// <summary>
        /// Compress a string replacing the duplicated chars by a number that specify how many duplicated chars are.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>compressed input</returns>
        /// <exception cref="Exception">Not alphabetic input</exception>
        public static bool TryCompress(string input, out string? output)
        {
            if (string.IsNullOrEmpty(input))
            {
                output = input;
                return false;
            }

            try
            {
                output = Compress(input);
                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }

        private static string ProcessTheInput(string input, Func<char, char, bool> stillCount)
        {
            string result = string.Empty;
            char currentLetter = input.FirstOrDefault();
            int counter = 0;

            foreach (char item in input)
            {
                if (stillCount(currentLetter, item))
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