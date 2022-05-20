﻿namespace CodeChallenge
{
    public class Compresser
    {

        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var isOnlyAlphanumeric = input.Any(x => char.IsLetterOrDigit(x));
            if (!isOnlyAlphanumeric)
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
                    result += $"{currentLetter}{counter}";
                    counter = 0;
                    currentLetter = item;
                }
            }
            result += $"{currentLetter}{counter}";


            return result;
        }
    }
}