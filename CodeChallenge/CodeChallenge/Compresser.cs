using System.Text.RegularExpressions;

namespace CodeChallenge
{
    public class Compresser
    {

        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            
            var isOnlyAlphabetic = Regex.IsMatch(input, @"^[a-zA-Z]+$");
            if (!isOnlyAlphabetic)
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
                    result += currentLetter;
                    if (counter > 1)
                    {
                        result += counter;
                    }
                    counter = 1;
                    currentLetter = item;
                }
            }
            result += currentLetter;
            if (counter > 1)
            {
                result += counter;
            }


            return result;
        }
    }
}